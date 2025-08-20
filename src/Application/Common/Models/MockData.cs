// -----------------------------------------------------------------------------------
// MockData.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using MSCoip.Domain.Constants;

namespace MSCoip.Application.Common.Models;

/// <summary>
/// MockData
/// </summary>
public static class MockData
{
    /// <summary>
    /// GetUserAttribute
    /// </summary>
    /// <returns></returns>
    public static Dictionary<string, List<string>> GetUserAttribute()
    {
        var result = new Dictionary<string, List<string>>();
        var customers = new List<string> { UserAttributeConstants.All };
        var plants = new List<string> { UserAttributeConstants.All };
        var customerSites = new List<string> { UserAttributeConstants.All };
        var workCenters = new List<string> { UserAttributeConstants.All };
        var abcInds = new List<string> { UserAttributeConstants.All };
        result.Add(UserAttributeConstants.CustomerName, customers);
        result.Add(UserAttributeConstants.PlantFieldName, plants);
        result.Add(UserAttributeConstants.CustomerSiteFieldName, customerSites);
        result.Add(UserAttributeConstants.WorkCenterFieldName, workCenters);
        result.Add(UserAttributeConstants.ABCFieldName, abcInds);
        return result;
    }

    /// <summary>
    /// GetUnitModelsOrCodes
    /// </summary>
    /// <returns></returns>
    public static string[] GetUnitModelsOrCodes()
    {
        return new[]
        {
            "HD785-7",
            "PC2000-8",
            "HD1500-7",
            "HD785-5",
            "GD825A-2",
            "PC3000-6",
            "PC4000-6",
            "PC3000-6E",
            "P420CB-8X4",
            "P360CB-6X4",
            "P360LA-6X4",
            "P410CB-8X4",
            "P460LA-6x4",
            "R580LA-6X4"
        };
    }

    /// <summary>
    /// Get Changelogs data Examples
    /// </summary>
    /// <returns></returns>
    public static List<Changelog> GetChangelogs()
    {
        var changelogs = new List<Changelog>();
        var mockGuids = new List<Guid>
        {
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid()
        };
        var sequence = 1;

        foreach (var guid in mockGuids)
        {
            changelogs.Add(new Changelog
            {
                Id = guid,
                Method = GetDbMethod(),
                KeyValues = "Value",
                NewValues = "Value",
                OldValues = "Value",
                TableName = "Table",
                ChangeDate = DateTime.UtcNow.AddMonths(-1 * sequence)
            });
            sequence += 1;
        }

        return changelogs;
    }

    /// <summary>
    /// Get Db Method Exmaple
    /// </summary>
    /// <returns></returns>
    public static string GetDbMethod()
    {
        string[] types =
        {
            "DELETE",
            "EDIT",
            "ADD"
        };
        var random = new Random();
        return types[random.Next(0, 2)];
    }

    /// <summary>
    /// GetAuthorizedUser
    /// </summary>
    /// <returns></returns>
    public static AuthorizedUser GetAuthorizedUser()
    {
        return new AuthorizedUser
        {
            UserId = Guid.NewGuid(),
            UserName = SystemConstants.Email,
            UserFullName = SystemConstants.Name,
            CustomerCode = UserAttributeConstants.All,
            ClientId = SystemConstants.ClientId,
            RoleLevel = 0
        };
    }

    /// <summary>
    /// GetUserEmailInfo
    /// </summary>
    /// <returns></returns>
    public static UserEmailInfo GetUserEmailInfo()
    {
        return new UserEmailInfo
        {
            Email = SystemConstants.Email,
            FirstName = SystemConstants.Name,
            LastName = SystemConstants.Name
        };
    }

    /// <summary>
    /// GetUserByAttributeAsync
    /// </summary>
    /// <returns></returns>
    public static List<UserClientIdInfo> GetUserByAttribute()
    {
        return
        [
            new ()
            {
                UserId = new Guid("49f140da-707a-459e-4e60-08d708dc37c0"),
                ClientId = "b1a48ae8-3c71-4ae4-4e7b-08d708dc37c0",
                IsCustomer = false
            },
            new ()
            {
                UserId = new Guid("b1a48ae8-3c71-4ae4-4e7b-08d708dc37c0"),
                ClientId = "3ea6f2ac-92aa-4a4c-8725-daa9350be5c8",
                IsCustomer = false
            },
            new ()
            {
                UserId = new Guid("c8374c2f-08f7-4156-4e75-08d708dc37c0"),
                ClientId = "3ea6f2ac-92aa-4a4c-8725-daa9350be5c8",
                IsCustomer = false
            },
            new ()
            {
                UserId = new Guid("6178aba0-dd0a-4615-4e7e-08d708dc37c0"),
                ClientId = "3ea6f2ac-92aa-4a4c-8725-daa9350be5c8",
                IsCustomer = false
            },
            new ()
            {
                UserId = new Guid("647c1e9c-6fe4-4800-25d7-08d771620e86"),
                ClientId = "3ea6f2ac-92aa-4a4c-8725-daa9350be5c8",
                IsCustomer = false
            }

        ];
    }

    /// <summary>
    /// GetAuthorizedUser
    /// </summary>
    /// <returns></returns>
    public static List<UserManagementUser> GetListMechanics()
    {
        var result = new List<UserManagementUser>
        {
            new ()
            {
                UserId = new Guid("49f140da-707a-459e-4e60-08d708dc37c0"),
                UserName = "80107002@unitedtractors.com",
                Email = "80107002@unitedtractors.com",
                FirstName = "Agus",
                LastName = "LISANTO"
            },
            new ()
            {
                UserId = new Guid("b1a48ae8-3c71-4ae4-4e7b-08d708dc37c0"),
                UserName = "70316028@unitedtractors.com",
                Email = "inengahsuarma54@gmail.com",
                FirstName = "I NENGAH",
                LastName = "I NENGAH"
            },
            new ()
            {
                UserId = new Guid("c8374c2f-08f7-4156-4e75-08d708dc37c0"),
                UserName = "81300006@unitedtractors.com",
                Email = "81300006@unitedtractors.com",
                FirstName = "HENDRAWAN",
                LastName = "HENDRAWAN"
            },
            new ()
            {
                UserId = new Guid("6178aba0-dd0a-4615-4e7e-08d708dc37c0"),
                UserName = "80101070@unitedtractors.com",
                Email = "saiful.ongisnade2016@gmail.com",
                FirstName = "SAIFUL",
                LastName = "HADI"
            }
        };

        return result;
    }

    /// <summary>
    /// RandomNum
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static int RandomNum(int min, int max)
    {
        var random = new Random();
        return random.Next(min, max);
    }

    /// <summary>
    /// RandomUnitModel
    /// </summary>
    /// <returns></returns>
    public static string RandomUnitModel()
    {
        var names = GetUnitModelsOrCodes();
        var random = new Random();
        return names[random.Next(0, names.Length)];
    }

    /// <summary>
    /// RandomString
    /// </summary>
    /// <param name="length"></param>
    /// <returns></returns>
    public static string RandomString(int length = 50)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[new Random().Next(s.Length)]).ToArray());
    }

    /// <summary>
    /// RandomTimeSpan
    /// </summary>
    /// <param name="length"></param>
    /// <returns></returns>
    public static TimeSpan RandomTimeSpan(int length = 86400)
    {
        return new TimeSpan(0, 0, 0, new Random().Next(length));
    }

    /// <summary>
    /// GetWorkCenters
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<KeyValuePair<string, string>> GetWorkCenters()
    {
        return new List<KeyValuePair<string, string>>
        {
            new ("M-ADRTP", "FMC Adaro Tutupan"),
            new ("FM-BDIPM", "FMC Bendili PAMA"),
            new ("FM-BIUPM", "FMC Batukajang PAMA"),
            new ("FM-BKJBU", "FMC Batukajang BUMA"),
            new ("FM-BKJSJ", "FMC Batukajang SIMS"),
            new ("FM-BNEPM", "FMC Bontang East Block Site - KITADIN"),
            new ("FM-DMIPM", "FMC Damai Pama"),
            new ("FM-JBYPM", "FMC Jembayan PAMA"),
            new ("FM-JKTMB", "FMC Jakarta On Road Mayasari Bhakti"),
            new ("FM-JKTTJ", "FMC Jakarta On Road Trans Jakarta"),
            new ("FM-LTIBU", "FMC Lati Buma"),
            new ("FM-MLWSM", "FMC Muaralawa SIMS"),
            new ("FM-SRKVL", "FMC Soroako"),
            new ("FM-TJGBU", "FMC Tanjung Buma"),
            new ("FM-TJGSI", "FMC Tanjung Sis"),
            new ("FM-BGLKP", "FMC Bengalon KPP"),
            new ("FM-BGLKW", "FMC Bengalon KWN"),
            new ("FM-MTBPM", "FMC MTBU Pama"),
            new ("FM-TBGKW", "FMC Tabang KWN")
        };
    }

    /// <summary>
    /// Fill
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="value"></param>
    /// <param name="count"></param>
    public static void Fill(this Stream stream, byte value, int count)
    {
        var buffer = new byte[64];

        for (var i = 0; i < buffer.Length; i++)
        {
            buffer[i] = value;
        }

        while (count > buffer.Length)
        {
            stream.Write(buffer, 0, buffer.Length);
            count -= buffer.Length;
        }

        stream.Write(buffer, 0, count);
    }

    /// <summary>
    /// CreateChecksheetMaster
    /// </summary>
    /// <returns></returns>
    public static List<ChecksheetMaster> CreateChecksheetMasters()
    {
        var result = new List<ChecksheetMaster>
        {
            new ChecksheetMaster
            {
                Id = Guid.NewGuid(),
                Sector = RandomString(4),
                Parameter = RandomString(5),
                AssessmentArea = RandomString(6),
                UnitApplication = RandomString(7),
                Klausul = RandomString(4),
                Description = RandomString(5),
                OperationStandard = new[] { "OPStandard1" },
                Guidance = new[] { "Guidance1" },
                Score = [ 1, 3, 5],
                Weight = 0.67f,
                Sequence = 1,
                CreatedBy = SystemConstants.Name
            },
            new ChecksheetMaster
            {
                Id = Guid.NewGuid(),
                Sector = RandomString(4),
                Parameter = RandomString(5),
                AssessmentArea = RandomString(6),
                UnitApplication = RandomString(7),
                Klausul = RandomString(4),
                Description = RandomString(5),
                OperationStandard = new[] { "OPStandard2" },
                Guidance = new[] { "Guidance2" },
                Score = [1, 3],
                Weight = 0.67f,
                Sequence = 2,
                CreatedBy = SystemConstants.Name
            },
            new ChecksheetMaster
            {
                Id = Guid.NewGuid(),
                Sector = RandomString(4),
                Parameter = RandomString(5),
                AssessmentArea = RandomString(6),
                UnitApplication = RandomString(7),
                Klausul = RandomString(4),
                Description = RandomString(5),
                OperationStandard = new[] { "OPStandard3" },
                Guidance = new[] { "Guidance3" },
                Score = [5],
                Weight = 0.67f,
                Sequence = 3,
                CreatedBy = SystemConstants.Name
            }
        };
        return result;
    }

    /// <summary>
    /// CreateCustomers
    /// </summary>
    /// <returns></returns>
    public static List<Customer> CreateCustomers()
    {
        var result = new List<Customer>
        {
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Customer1",
                Code = "CUST123",
                CreatedBy = SystemConstants.Name,
            },
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Customer2",
                Code = RandomString(8),
                CreatedBy = SystemConstants.Name,
            },
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Customer3",
                Code = RandomString(8),
                CreatedBy = SystemConstants.Name,
            }
        };
        return result;
    }

    /// <summary>
    /// CreateJobs
    /// </summary>
    /// <param name="IdCustomer">The ID of the customer.</param>
    /// <returns>A list of ChecksheetValue objects.</returns>
    public static List<Domain.Entities.Job> CreateJobs(Guid IdCustomer)
    {

        var result = new List<Domain.Entities.Job>
        {
            new Domain.Entities.Job
            {
                Id = Guid.NewGuid(),
                CustomerId = IdCustomer,
                Number = RandomNum(10_000_000, 99_999_999).ToString(CultureInfo.InvariantCulture),
                Status = "2",
                PlantArea = "Blp",
                PlanExecutionDate = DateTimeOffset.UtcNow,
                MainJob = "MiniMini",
                CreatedByName = "uhuy",
                AverageSpeed = 21,
                CreatedBy = SystemConstants.Name
            },
            new Domain.Entities.Job
            {
                Id = Guid.NewGuid(),
                CustomerId = IdCustomer,
                Number = RandomNum(10_000_000, 99_999_999).ToString(CultureInfo.InvariantCulture),
                Status = "2",
                PlantArea = "Blp",
                PlanExecutionDate = DateTimeOffset.UtcNow,
                MainJob = "MiniMini",
                CreatedByName = "uhuy",
                AverageSpeed = 12,
                CreatedBy = SystemConstants.Name
            },
            new Domain.Entities.Job
            {
                Id = Guid.NewGuid(),
                CustomerId = IdCustomer,
                Number = RandomNum(10_000_000, 99_999_999).ToString(CultureInfo.InvariantCulture),
                Status = "2",
                PlantArea = "Blp",
                PlanExecutionDate = DateTimeOffset.UtcNow,
                MainJob = "MiniMini",
                CreatedByName = "uhuy",
                AverageSpeed = 30,
                CreatedBy = SystemConstants.Name
            }
        };
        return result;
    }

    /// <summary>
    /// CreateChecksheetValue
    /// </summary>
    /// <param name="IdJob">The ID of the job.</param>
    /// <returns>A list of ChecksheetValue objects.</returns>
    public static List<AdditionalJob> CreateAdditionalJobs(Guid IdJob)
    {
        var result = new List<AdditionalJob>
        {
            new AdditionalJob
            {
                Id = Guid.NewGuid(),
                JobId = IdJob,
                Desc = RandomString(8),
                CreatedBy = SystemConstants.Name,
                Parameter = RandomString(5)
            },
            new AdditionalJob
            {
                Id = Guid.NewGuid(),
                JobId = IdJob,
                Desc = RandomString(8),
                CreatedBy = SystemConstants.Name,
                Parameter = RandomString(5)
            },
            new AdditionalJob
            {
                Id = Guid.NewGuid(),
                JobId = IdJob,
                Desc = RandomString(8),
                CreatedBy = SystemConstants.Name,
                Parameter = RandomString(5)
            }
        };
        return result;
    }

    /// <summary>
    /// CreateChecksheetValue
    /// </summary>
    /// <param name="IdJob">The ID of the job.</param>
    /// <returns>A list of ChecksheetValue objects.</returns>
    public static List<ChecksheetValue> CreateChecksheetValues(Guid IdJob)
    {
        var result = new List<ChecksheetValue>
        {
            new ChecksheetValue
            {
                Id = Guid.NewGuid(),
                JobId = IdJob,
                Sector = RandomString(4),
                Parameter = RandomString(5),
                AssessmentArea = RandomString(6),
                UnitApplication = RandomString(7),
                Klausul = RandomString(4),
                Description = RandomString(5),
                OperationStandard = new[] { "OPStandard1" },
                Guidance = new[] { "Guidance1" },
                Score = [ 1, 3, 5],
                FinalScore = [0.67f],
                Weight = 0.67f,
                Sequence = 1,
                CreatedBy = SystemConstants.Name
            },
            new ChecksheetValue
            {
                Id = Guid.NewGuid(),
                JobId = IdJob,
                Sector = RandomString(4),
                Parameter = RandomString(5),
                AssessmentArea = RandomString(6),
                UnitApplication = RandomString(7),
                Klausul = RandomString(4),
                Description = RandomString(5),
                OperationStandard = new[] { "OPStandard2" },
                Guidance = new[] { "Guidance2" },
                Score = [1, 3],
                Weight = 0.67f,
                FinalScore = [0.67f],
                Comment = "Komen 2",
                Recommendation = "Rekomendasi 2",
                Image = "Image 2",
                Sequence = 2,
                CreatedBy = SystemConstants.Name
            },
            new ChecksheetValue
            {
                Id = Guid.NewGuid(),
                JobId = IdJob,
                Sector = RandomString(4),
                Parameter = RandomString(5),
                AssessmentArea = RandomString(6),
                UnitApplication = RandomString(7),
                Klausul = RandomString(4),
                Description = RandomString(5),
                OperationStandard = new[] { "OPStandard3" },
                Guidance = new[] { "Guidance3" },
                Score = [5],
                FinalScore = [0.67f],
                Weight = 0.67f,
                Sequence = 3,
                CreatedBy = SystemConstants.Name
            }
        };
        return result;
    }

    /// <summary>
    /// CreateUnitPopulations
    /// </summary>
    /// <param name="IdCustomer">The ID of the customer.</param>
    /// <param name="Code">The code for the unit population.</param>
    /// <returns></returns>
    public static List<Equipment> CreateUnitPopulations(Guid IdCustomer, string Code)
    {
        var result = new List<Equipment>
        {
            new Equipment
            {
                Id = Guid.NewGuid(),
                UnitModel = RandomUnitModel(),
                SerialNumber = RandomString(9),
                UnitCode = RandomNum(1_000, 9_999).ToString(CultureInfo.InvariantCulture),
                CustomerCode = Code,
                PlantCode = "JKT",
                CustomerId = IdCustomer
            },
            new Equipment
            {
                Id = Guid.NewGuid(),
                UnitModel = RandomUnitModel(),
                SerialNumber = RandomString(9),
                UnitCode = RandomNum(1_000, 9_999).ToString(CultureInfo.InvariantCulture),
                CustomerCode = Code,
                PlantCode = "JKT",
                CustomerId = IdCustomer
            },
            new Equipment
            {
                Id = Guid.NewGuid(),
                UnitModel = RandomUnitModel(),
                SerialNumber = RandomString(9),
                UnitCode = RandomNum(1_000, 9_999).ToString(CultureInfo.InvariantCulture),
                CustomerCode = Code,
                PlantCode = "JKT",
                CustomerId = IdCustomer
            }
        };
        return result;
    }
}
