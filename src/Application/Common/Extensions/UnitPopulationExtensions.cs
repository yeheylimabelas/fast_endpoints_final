// -----------------------------------------------------------------------------------
// UnitPopulationExtensions.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using MSCoip.Application.Common.Exceptions;

namespace MSCoip.Application.Common.Extensions;

/// <summary>
/// Unit Population Extensions
/// </summary>
public static class UnitPopulationExtensions
{
    /// <summary>
    /// Read Xlsx
    /// </summary>
    /// <param name="file"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<(
        string customerCode,
        DataTable updatedUnitPopulations,
        DataTable newUnitPopulations)> UnitPopulationExtensionsXlsx(this IFormFile file, CancellationToken cancellationToken)
    {
        var stream = new MemoryStream();
        await file.CopyToAsync(stream, cancellationToken).ConfigureAwait(false);
        using var wb = new XLWorkbook(stream);

        var sheet1 = wb.Worksheet(1);
        var sheet2 = wb.Worksheet(2);

        static string GetCustomerCodeFromSheet(IXLWorksheet sheet)
        {
            return sheet
                .Column(3)
                .CellsUsed()
                .Skip(1)
                .Select(cell => cell.GetString().Trim())
                .Where(code => !string.IsNullOrEmpty(code))
                .GroupBy(code => code)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();
        }

        var customerCode = GetCustomerCodeFromSheet(sheet1);

        if (string.IsNullOrEmpty(customerCode))
        {
            customerCode = GetCustomerCodeFromSheet(sheet2);
        }

        if (string.IsNullOrEmpty(customerCode))
        {
            throw new BadRequestException("Customer code not found in Excel file");
        }

        var updatedDataTable = new DataTable();
        updatedDataTable.Columns.AddRange(new[]
        {
            new DataColumn("UnitModel", typeof(string)),
            new DataColumn("SerialNumber", typeof(string)),
            new DataColumn("UnitCode", typeof(string))
        });

        var newDataTable = updatedDataTable.Clone();

        static void ReadWorksheet(IXLWorksheet sheet, DataTable table)
        {
            foreach (var row in sheet.RowsUsed().Skip(1))
            {
                table.Rows.Add(
                    row.Cell(6).GetString().Trim(),
                    row.Cell(7).GetString().Trim(),
                    row.Cell(8).GetString().Trim());
            }
        }

        ReadWorksheet(sheet1, updatedDataTable);
        ReadWorksheet(sheet2, newDataTable);

        return (customerCode, updatedDataTable, newDataTable);
    }
}
