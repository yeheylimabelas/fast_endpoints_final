// // -----------------------------------------------------------------------------------
// // GetSyncsQuery.cs 2024
// // Copyright DAD RnD. All rights reserved.
// // DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// // -----------------------------------------------------------------------------------

// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading;
// using System.Threading.Tasks;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Logging;
// using MSCoip.Application.Common.Behaviors;
// using MSCoip.Application.Common.Extensions;
// using MSCoip.Application.Common.Interfaces;
// using MSCoip.Application.Common.Vms;

// namespace MSCoip.Application.Sync.Queries;

// /// <summary>
// /// Query to get JSON string of Sync Data
// /// </summary>
// [RetryPolicy(RetryCount = 4, SleepDuration = 1000)]
// [TimeoutPolicy(Duration = 300)]
// public class GetSyncsQuery : IRequest<DocumentRootJson<SyncVm>>
// {
//     /// <summary>
//     /// Gets or sets request Date of synchronize
//     /// </summary>
//     public string Date { get; set; }

//     /// <summary>
//     /// Gets or sets request JobId
//     /// </summary>
//     public string JobId { get; set; }

//     /// <summary>
//     /// Gets or sets request CustomerCode
//     /// </summary>
//     public string[] CustomerCode { get; set; }

//     /// <summary>
//     /// Gets or sets a value indicating whether the request is internal
//     /// </summary>
//     public bool IsInternal { get; set; }

//     /// <summary>
//     /// Handling GetSyncsQuery
//     /// </summary>
//     public class GetSyncQueryHandler : IRequestHandler<GetSyncsQuery, DocumentRootJson<SyncVm>>
//     {
//         private readonly IApplicationDbContext _context;
//         private readonly IMapper _mapper;
//         private readonly IUserAuthorizationService _userAuthorizationService;

//         /// <summary>
//         /// Initializes a new instance of the <see cref="GetSyncQueryHandler"/> class.
//         /// </summary>
//         /// <param name="_mapper">Set mapper to perform object mapping</param>
//         /// <param name="_logger">Set logger to perform logging</param>
//         /// <param name="_userAuthorizationService"></param>
//         /// <param name="serviceProvider"></param>
//         public GetSyncQueryHandler(
//             IMapper _mapper,
//             ILogger<GetSyncQueryHandler> _logger,
//             IUserAuthorizationService _userAuthorizationService,
//             IServiceProvider serviceProvider)
//         {
//             IServiceScope scope = serviceProvider.CreateScope();
//             _context = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
//             this._mapper = _mapper;
//             this._userAuthorizationService = _userAuthorizationService;
//         }

//         /// <summary>
//         /// Handle
//         /// </summary>
//         /// <param name="request">
//         /// The encapsulated request body
//         /// </param>
//         /// <param name="cancellationToken">
//         /// The cancellation token to perform cancel the operation
//         /// </param>
//         /// <returns>A JSON String</returns>
//         public async Task<DocumentRootJson<SyncVm>> Handle(GetSyncsQuery request, CancellationToken cancellationToken)
//         {
//             var user = _userAuthorizationService.GetAuthorizedUser().UserName;

//             var date = DateTime.Parse(request.Date).Date;
//             DateTime startDate = date.AddDays(-6);

//             var result = new SyncVm
//             {
//                 ChecksheetMaster = [],
//                 SyncChecksheetValue = [],
//                 SyncDate = DateTimeOffset.UtcNow.ToString("yyyyMMddHHmmss")
//             };

//             List<Guid?> masterChecksheet = null;

//             if (!request.IsInternal)
//             {
//                 masterChecksheet = await _context.MasterChecksheetCustomer
//                     .Where(x => request.CustomerCode.Contains(x.CustomerCode))
//                     .Select(x => x.UnitApplicationId)
//                     .ToListAsync(cancellationToken)
//                     .ConfigureAwait(false);
//             }

//             result.ChecksheetMaster = await _context.ChecksheetMaster
//                 .AsNoTracking()
//                 .Where(x => request.IsInternal || masterChecksheet.Contains(x.UnitApplicationId))
//                 .OrderBy(e => e.Sequence)
//                 .ProjectTo<ChecksheetMasterDetailVm>(_mapper.ConfigurationProvider)
//                 .ToListAsync(cancellationToken)
//                 .ConfigureAwait(false);

//             result.SyncChecksheetValue =
//             string.IsNullOrEmpty(user) ? [] : await _context.ChecksheetValue
//                 .AsNoTracking()
//                 .Where(c =>
//                     c.Job.UpdatedDate.Value >= startDate &&
//                     request.CustomerCode.Contains(c.Job.Customer.Code) &&
//                     user.Equals(c.CreatedBy) &&
//                     (request.JobId == null || c.JobId == Guid.Parse(request.JobId)))
//                 .OrderBy(c => c.Job.UpdatedDate)
//                 .GroupBy(c => c.Job.Customer.Code)
//                 .Select(c => new SyncChecksheetValueVm
//                 {
//                     Id = Guid.NewGuid(),
//                     CustomerCode = c.Key,
//                     ChecksheetValue = c.Select(x => _mapper.Map<ChecksheetValueDetailVm>(x)).ToList(),
//                 })
//                 .ToListAsync(cancellationToken)
//                 .ConfigureAwait(false);

//             return JsonApiExtensions.ToJsonApi(result);
//         }
//     }
// }

// /// <summary>
// /// GetSyncQueryValidator
// /// </summary>
// public class GetSyncQueryValidator : AbstractValidator<GetSyncsQuery>
// {
//     /// <summary>
//     /// Initializes a new instance of the <see cref="GetSyncQueryValidator"/> class.
//     /// GetSyncQueryValidator
//     /// </summary>
//     public GetSyncQueryValidator()
//     {
//         RuleFor(v => v.Date)
//             .NotEmpty().WithMessage("{PropertyName} is required");

//         RuleFor(v => v.CustomerCode)
//             .NotEmpty().WithMessage("{PropertyName} is required");
//     }
// }
