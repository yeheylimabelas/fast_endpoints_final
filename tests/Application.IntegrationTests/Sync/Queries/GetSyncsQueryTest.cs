// // -----------------------------------------------------------------------------------
// // GetSyncsQueryTest.cs 2024
// // Copyright DAD RnD. All rights reserved.
// // DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// // -----------------------------------------------------------------------------------

// using System.Globalization;
// using FluentValidation.TestHelper;
// using MSCoip.Application.Common.Exceptions;
// using MSCoip.Application.Common.Extensions;
// using MSCoip.Application.Common.Vms;
// using MSCoip.Application.Sync.Queries;
// using Shouldly;

// namespace MSCoip.Application.IntegrationTests.Sync.Queries;

// using static Testing;

// /// <summary>
// /// GetSyncsQueryTest
// /// </summary>
// public class GetSyncsQueryTest : BaseTestFixture
// {
//     private GetSyncQueryValidator _validator;

//     /// <summary>
//     /// SetUp
//     /// </summary>
//     [SetUp]
//     public void SetUp()
//     {
//         _validator = new GetSyncQueryValidator();
//     }

//     /// <summary>
//     /// Tests that the GetSyncsQuery requires minimum fields.
//     /// </summary>
//     [Test]
//     public void ShouldRequireMinimumFields()
//     {
//         var query = new GetSyncsQuery();

//         FluentActions.Invoking(() =>
//             SendAsync(query)).Should().ThrowAsync<ValidationException>();
//     }

//     /// <summary>
//     /// ShouldHaveErrorWhenStartDateIsMissing
//     /// </summary>
//     [Test]
//     public void ShouldHaveErrorWhenStartDateIsMissing()
//     {
//         var model = new GetSyncsQuery
//         {
//             Date = null,
//             CustomerCode = ["12278"]
//         };

//         var result = _validator.TestValidate(model);
//         result.ShouldHaveValidationErrorFor(x => x.Date);
//     }

//     /// <summary>
//     /// ShouldHaveErrorWhenCustomerCodeIsMissing
//     /// </summary>
//     [Test]
//     public void ShouldHaveErrorWhenCustomerCodeIsMissing()
//     {
//         var model = new GetSyncsQuery
//         {
//             Date = DateTimeOffset.UtcNow.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
//             CustomerCode = null
//         };

//         var result = _validator.TestValidate(model);
//         result.ShouldHaveValidationErrorFor(x => x.CustomerCode);
//     }

//     /// <summary>
//     /// ShouldNotHaveErrorWhenStartDateIsExist
//     /// </summary>
//     [Test]
//     public void ShouldNotHaveErrorWhenStartDateIsExist()
//     {
//         var model = new GetSyncsQuery
//         {
//             Date = DateTimeOffset.UtcNow.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
//             CustomerCode = ["12278"]
//         };

//         var result = _validator.TestValidate(model);
//         result.ShouldNotHaveValidationErrorFor(x => x.Date);
//     }

//     /// <summary>
//     /// Tests that the GetSyncsQuery returns the expected results.
//     /// </summary>
//     /// <returns>A task that represents the asynchronous operation.</returns>
//     [Test]
//     public async Task ShouldReturnSyncs()
//     {
//         var command = new GetSyncsQuery
//         {
//             Date = "2024-11-6",
//             CustomerCode = ["12279"]
//         };

//         var query = await SendAsync(command).ConfigureAwait(false);
//         query.ShouldBeOfType<DocumentRootJson<SyncVm>>();
//         query.Data.Id.Should().NotBeEmpty();
//         query.Data.ChecksheetMaster.Should().NotBeNullOrEmpty();
//     }
// }
