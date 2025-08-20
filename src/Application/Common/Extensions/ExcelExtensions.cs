// -----------------------------------------------------------------------------------
// ExcelExtensions.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using MSCoip.Application.Common.Exceptions;
using MSCoip.Domain.Constants;

namespace MSCoip.Application.Common.Extensions;

/// <summary>
/// Excel Extension
/// </summary>
public static class ExcelExtensions
{
    /// <summary>
    /// Read Xlsx
    /// </summary>
    /// <param name="file"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<DataTable> FromXlsx(this IFormFile file, CancellationToken cancellationToken)
    {
        var stream = new MemoryStream();
        var dataTable = new DataTable();

        await using (stream.ConfigureAwait(false))
        {
            await file.CopyToAsync(stream, cancellationToken).ConfigureAwait(false);

            using var wb = new XLWorkbook(stream);
            var firstRow = true;

            foreach (var row in wb.Worksheet(1).Rows())
            {
                if (row.IsEmpty())
                {
                    row.Cells().Clear();
                }

                if (!row.Cells().Any())
                {
                    break;
                }

                if (firstRow)
                {
                    foreach (var cell in row.Cells())
                    {
                        dataTable.Columns.Add(cell.Value.ToString());
                    }

                    firstRow = false;
                }
                else
                {
                    dataTable.Rows.Add();
                    var i = 0;

                    for (var j = 1; j <= dataTable.Columns.Count; j++)
                    {
                        var activeCell = $"{(char)(PaginationConstants.CustomRuleAsciiAlphabet + j)}{dataTable.Rows.Count + 1}";

                        var combinePattern = RegexConstants.Pattern.Replace(
                            "{pattern}",
                            RegexConstants.Char + RegexConstants.Numeric + " " + RegexConstants.Symbol);
                        var pattern = new Regex(combinePattern);

                        if (!string.IsNullOrWhiteSpace(row.Cells(activeCell).Select(x => x).FirstOrDefault()?.Value.ToString()))
                        {
                            var isMatch = pattern.IsMatch(
                                row.Cells(activeCell).Select(x => x).FirstOrDefault()?.Value.ToString() ?? string.Empty);

                            if (!isMatch)
                            {
                                throw new BadRequestException($"Only character [{RegexConstants.Char}], numeric [{RegexConstants.Numeric}], and symbol [{RegexConstants.Symbol}] can be accepted in cell {activeCell}");
                            }
                        }

                        dataTable.Rows[^1][i] = row.Cells(activeCell).Select(x => x).FirstOrDefault()?.Value.ToString() ?? string.Empty;

                        i++;
                    }
                }
            }

            stream.Close();
        }

        return dataTable;
    }
}
