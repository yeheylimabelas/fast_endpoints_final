using System.Buffers;
using FluentValidation;
using FluentValidation.AspNetCore;
using JsonApiSerializer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MSCoip.Api.Infrastructures.Filters;
using MSCoip.Api.Infrastructures.Handlers;
using MSCoip.Api.Infrastructures.Middlewares;
using MSCoip.Api.Infrastructures.Processors;
using MSCoip.Application.Common.Extensions;
using MSCoip.Application.Common.Interfaces;
using MSCoip.Application.Common.Models;
using MSCoip.Domain.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NSwag;
using NSwag.Generation.Processors.Security;
using Serilog;
using ZymLabs.NSwag.FluentValidation;

namespace MSCoip.Api;

/// <summary>
/// DependencyInjection
/// </summary>
public static class DependencyInjection
{
  /// <summary>
  /// AddApiServices
  /// </summary>
  /// <param name="services"></param>
  /// <param name="environment"></param>
  /// <param name="appSetting"></param>
  /// <returns></returns>
  public static IServiceCollection AddApiServices(
      this IServiceCollection services,
      IWebHostEnvironment environment,
      AppSetting appSetting)
  {
    AppLoggingExtensions.LoggerFactory = services
        .BuildServiceProvider()
        .GetService<ILoggerFactory>();

    services.AddApplicationInsightsTelemetry();
    services.AddDatabaseDeveloperPageExceptionFilter();
    services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
    services.AddSingleton(appSetting);
    services.AddHttpContextAccessor();
    services.AddScoped<ApiDevelopmentFilterAttribute>();
    services.AddScoped<ApiAuthenticationFilterAttribute>();
    services.AddScoped<ApiAuthorizeFilterAttribute>();

    if (environment.EnvironmentName == EnvironmentConstants.NameTest)
    {
      services.AddLocalPermissions(appSetting);
    }
    else
    {
      services.AddPermissions(appSetting);
    }

    services.AddScoped(provider =>
    {
      var validationRules = provider.GetService<IEnumerable<FluentValidationRule>>();
      var loggerFactory = provider.GetService<ILoggerFactory>();

      return new FluentValidationSchemaProcessor(provider, validationRules, loggerFactory);
    });

    services.AddMvcCore();

    services.AddRouting(options =>
    {
      options.LowercaseUrls = true;
      options.LowercaseQueryStrings = true;
    });

    services
        .AddControllers(options =>
        {
          var serializerSettings = new JsonApiSerializerSettings
          {
            NullValueHandling = NullValueHandling.Include,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc
          };

          var jsonApiFormatter = new NewtonsoftJsonOutputFormatter(
                  serializerSettings,
                  ArrayPool<char>.Shared,
                  new MvcOptions(),
                  new MvcNewtonsoftJsonOptions());

          options.OutputFormatters.RemoveType<NewtonsoftJsonOutputFormatter>();
          options.OutputFormatters.Insert(0, jsonApiFormatter);

          options.EnableEndpointRouting = false;
        })
        .AddNewtonsoftJson(options =>
        {
          options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
          options.SerializerSettings.ContractResolver = new DefaultContractResolver
          {
            NamingStrategy = new CamelCaseNamingStrategy()
          };
        });

    services
        .AddValidatorsFromAssemblyContaining<IApplicationDbContext>()
        .AddFluentValidationClientsideAdapters();

    services.AddCors();

    services.AddOptions();

    services.AddCompressionHandler();

    services.AddHealthCheck(appSetting);

    services.AddApiVersioning(options =>
    {
      options.ReportApiVersions = true;
      options.AssumeDefaultVersionWhenUnspecified = true;
      options.ApiVersionReader = new UrlSegmentApiVersionReader();
    });

    services.AddVersionedApiExplorer(options =>
    {
      options.GroupNameFormat = "'v'VVV";
      options.SubstituteApiVersionInUrl = true;
      options.AssumeDefaultVersionWhenUnspecified = true;
      options.DefaultApiVersion = new ApiVersion(1, 0);
    });

    services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

    services.AddOpenApiDocument(
        (configure, sp) =>
        {
          if (environment.IsProduction())
          {
            configure.OperationProcessors.Insert(0, new MyControllerProcessor());
          }

          configure.Title = appSetting.App.Title;
          configure.Description = appSetting.App.Description;
          configure.Version = appSetting.App.Version;
          configure.AllowNullableBodyParameters = false;

          configure.AddSecurity(
                  "JWT",
                  Enumerable.Empty<string>(),
                  new OpenApiSecurityScheme
                {
                  Type = OpenApiSecuritySchemeType.ApiKey,
                  Name = "Authorization",
                  In = OpenApiSecurityApiKeyLocation.Header,
                  Description = "Type into the text box: Bearer {your JWT token}."
                });

          configure
                  .OperationProcessors
                  .Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));

          configure.PostProcess = document =>
              {
              document.Info.Contact = new OpenApiContact
              {
                Name = appSetting.App.AppContact.Company,
                Email = appSetting.App.AppContact.Email,
                Url = appSetting.App.AppContact.Uri
              };
            };

          // Add the fluent validations schema processor
          var fluentValidationSchemaProcessor = sp.CreateScope()
                  .ServiceProvider
                  .GetRequiredService<FluentValidationSchemaProcessor>();

          configure.SchemaSettings.SchemaProcessors.Add(fluentValidationSchemaProcessor);
        });

    return services;
  }
}
