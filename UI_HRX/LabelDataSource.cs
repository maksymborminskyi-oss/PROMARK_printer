using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace UI_HRX
{
    /// <summary>
    /// Спільний інтерфейс джерела даних для етикеток (Excel зараз, локальна БД у майбутньому).
    /// </summary>
    public interface ILabelDataSource
    {
        string SourceName { get; }
        DataTable LoadTable();
    }

    /// <summary>
    /// Завантажувач таблиці змінних для етикеток із файлу Excel (.xlsx).
    /// </summary>
    public class ExcelLabelDataSource : ILabelDataSource
    {
        private readonly string filePath;
        private readonly string sheetName;

        public string SourceName => Path.GetFileName(filePath);

        public ExcelLabelDataSource(string filePath, string sheetName = null)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Шлях до Excel-файлу не може бути порожнім.", nameof(filePath));
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Excel-файл не знайдено.", filePath);

            this.filePath = filePath;
            this.sheetName = string.IsNullOrWhiteSpace(sheetName) ? null : sheetName.Trim();
        }

        public DataTable LoadTable()
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var workbook = new XLWorkbook(stream))
            {
                IXLWorksheet worksheet = sheetName == null
                    ? workbook.Worksheets.FirstOrDefault()
                    : workbook.Worksheet(sheetName);

                if (worksheet == null)
                    throw new InvalidOperationException("У книзі Excel немає жодного аркуша.");

                var table = new DataTable(worksheet.Name);
                IXLRange usedRange = worksheet.RangeUsed();
                if (usedRange == null)
                    return table;

                IXLRangeRow headerRow = usedRange.FirstRow();
                int columnCount = usedRange.ColumnCount();

                for (int c = 1; c <= columnCount; c++)
                {
                    string rawHeader = headerRow.Cell(c).GetFormattedString().Trim();
                    string uniqueName = MakeUniqueColumnName(table, rawHeader, c);
                    table.Columns.Add(uniqueName, typeof(string));
                }

                foreach (IXLRangeRow rangeRow in usedRange.Rows().Skip(1))
                {
                    var values = new object[columnCount];
                    bool hasAnyValue = false;

                    for (int c = 1; c <= columnCount; c++)
                    {
                        string text = rangeRow.Cell(c).GetFormattedString();
                        if (!string.IsNullOrWhiteSpace(text))
                            hasAnyValue = true;

                        values[c - 1] = text;
                    }

                    if (hasAnyValue)
                        table.Rows.Add(values);
                }

                return table;
            }
        }

        private static string MakeUniqueColumnName(DataTable table, string rawName, int columnIndex)
        {
            string baseName = string.IsNullOrWhiteSpace(rawName) ? $"Column{columnIndex}" : rawName;
            string candidate = baseName;
            int suffix = 2;

            while (table.Columns.Contains(candidate))
            {
                candidate = $"{baseName}_{suffix}";
                suffix++;
            }

            return candidate;
        }
    }

    /// <summary>
    /// Допоміжні методи перетворення табличних даних у змінні принтера.
    /// </summary>
    public static class LabelDataHelper
    {
        public static List<PrinterVariable> RowToVariables(DataRow row, bool skipEmpty = true)
        {
            if (row == null)
                throw new ArgumentNullException(nameof(row));

            var result = new List<PrinterVariable>();
            foreach (DataColumn column in row.Table.Columns)
            {
                string value = row[column]?.ToString() ?? string.Empty;
                if (skipEmpty && string.IsNullOrWhiteSpace(value))
                    continue;

                result.Add(new PrinterVariable(column.ColumnName, value));
            }

            return result;
        }

        public static List<string> ColumnToBatchValues(DataTable table, string columnName)
        {
            if (table == null)
                throw new ArgumentNullException(nameof(table));
            if (string.IsNullOrWhiteSpace(columnName) || !table.Columns.Contains(columnName))
                throw new ArgumentException($"Колонку '{columnName}' не знайдено в таблиці.", nameof(columnName));

            return table.Rows
                .Cast<DataRow>()
                .Select(r => r[columnName]?.ToString()?.Trim())
                .Where(v => !string.IsNullOrWhiteSpace(v))
                .ToList();
        }

        public static string[] VariablesToEditorLines(IEnumerable<PrinterVariable> variables)
        {
            if (variables == null)
                return Array.Empty<string>();

            return variables
                .Select(v => $"{v.Name}={EncodeMultiline(v.Value)}")
                .ToArray();
        }

        public static string EncodeMultiline(string value)
        {
            return (value ?? string.Empty)
                .Replace("\r\n", "\n")
                .Replace("\r", "\n")
                .Replace("\n", "\\n");
        }

        public static string DecodeMultiline(string value)
        {
            return (value ?? string.Empty).Replace("\\n", "\n");
        }
    }
}
