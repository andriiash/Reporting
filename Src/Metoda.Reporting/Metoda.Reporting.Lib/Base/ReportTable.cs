using iText.IO.Font;
using iText.Kernel.Font;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Metoda.Reporting.Lib.Attributes;
using Metoda.Reporting.Lib.Base.Contracts;
using Metoda.Reporting.Lib.Res;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Metoda.Reporting.Lib.Base
{

    public class ReportTable<T> : IReportTable<T> where T : IReportTableItem
    {
        public IList<ReportColumn> Columns { get; private set; }
        public IList<T> Items { get; private set; }
        public string TotalLabel { get; set; }

        public ReportTable(IList<T> items = null, string totalLabel = "Totale")
        {
            Items = items ?? new List<T>();
            Columns = OutputOrderAttribute.GetReportColumns(typeof(T));
            TotalLabel = totalLabel;
        }

        public virtual void PrintToPdf(Table table, bool hasTotal = true)
        {
            var propInfos = Columns.Select(_ => _.PropInfo).ToList();

            foreach (var item in Items)
            {
                foreach (var val in item.GetValueArray(propInfos))
                {
                    Cell cell = new Cell()
                        .Add(new Paragraph(val.Item2).SetMultipliedLeading(0.9f))
                        .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                        .SetTextAlignment(val.Item1);

                    table.AddCell(cell);
                }
            }

            if (hasTotal)
            {
                PrintTotalToPdf(table, Columns, Items, TotalLabel);
            }
        }

        public static void PrintTotalToPdf(Table table, IList<ReportColumn> cols, IList<T> items, string totalLabel)
        {
            var boldFont = PdfFontFactory.CreateFont(Resource.CALIBRIB, PdfEncodings.WINANSI, PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED);
            
            var borderWidth = new SolidBorder(1.0f);
            var totalCols = cols.TakeWhile(c => !c.IsInTotal);

            Cell cell = new Cell(1, totalCols.Count())
                    .SetFont(boldFont)
                    .Add(new Paragraph(totalLabel))
                    .SetBorderBottom(borderWidth)
                    .SetBorderTop(borderWidth)
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                    .SetPaddingRight(10f);

            table.AddCell(cell);

            var sumColsForTotal = cols.SkipWhile(c => !c.IsInTotal);

            foreach (var column in sumColsForTotal)
            {
                string cellText = GetCellValue(column, items);

                cell = new Cell()
                    .SetFont(boldFont)
                    .Add(new Paragraph(cellText).SetMultipliedLeading(0.9f))
                    .SetBorderBottom(borderWidth)
                    .SetBorderTop(borderWidth)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);

                table.AddCell(cell);
            }
        }

        private static string GetCellValue(ReportColumn column, IList<T> items)
        {
            //if (!column.IsInTotal)
            //{
            //    throw new Exception($"'{column.DisplayName}' of {typeof(T)} class is not in the totol.");
            //}

            Type valListType = typeof(List<>).MakeGenericType(column.PropInfo.PropertyType);
            IList valList = (IList)Activator.CreateInstance(valListType);

            foreach (var item in items)
            {
                object propValue = column.PropInfo.GetValue(item);
                valList.Add(propValue);
            }

            if (column.PropInfo.PropertyType == typeof(int))
            {
                return valList.Cast<int>().Sum().ToString(new System.Globalization.CultureInfo("it-IT"));
            }
            else if (column.PropInfo.PropertyType == typeof(decimal))
            {
                return valList.Cast<decimal>().Sum().ToString("N2", new System.Globalization.CultureInfo("it-IT"));
            }
            else if (column.PropInfo.PropertyType == typeof(long))
            {
                return valList.Cast<long>().Sum().ToString(new System.Globalization.CultureInfo("it-IT"));
            }

            return string.Empty;
        }
    }
}


