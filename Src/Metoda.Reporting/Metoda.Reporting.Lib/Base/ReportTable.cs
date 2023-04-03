using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Metoda.Reporting.Lib.Attributes;
using Metoda.Reporting.Lib.Base.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace Metoda.Reporting.Lib.Base
{

    public class ReportTable<T> : IReportTable<T> where T : IReportTableItem
    {
        protected readonly bool _hasTotal;
        public IList<ReportColumn> Columns { get; private set; }
        public IList<T> Items { get; private set; }

        public ReportTable(IList<T> items = null, bool hasTotal = false)
        {
            _hasTotal = hasTotal;
            Items = items ?? new List<T>();
            Columns = OutputOrderAttribute.GetReportColumns(typeof(T));
        }

        public void PrintToPdf(Table table)
        {
            var propInfos = Columns.Select(_ => _.PropInfo).ToList();

            foreach (var item in Items)
            {
                foreach (var val in item.GetValueArray(propInfos))
                {
                    Cell cell = new Cell().Add(new Paragraph(val).SetMultipliedLeading(0.9f));
                    table.AddCell(cell);
                }
            }

            if (_hasTotal)
            {
                PrintTotalToPdf(table);
            }
        }

        protected virtual void PrintTotalToPdf(Table table)
        {
            var borderWidth = new SolidBorder(1.0f);
            var totalCols = Columns.TakeWhile(c => !c.IsInTotal);

            Cell cell = new Cell(1, totalCols.Count())
                    .SetFont(ReportBase.BoldFont)
                    .Add(new Paragraph("Total"))
                    .SetBorderBottom(borderWidth)
                    .SetBorderTop(borderWidth)
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                    .SetPaddingRight(10f);

            table.AddCell(cell);

            var sumColsForTotal = Columns.SkipWhile(c => !c.IsInTotal);

            foreach (var column in sumColsForTotal)
            {
                string cellText = GetCellValue(column);

                cell = new Cell()
                    .SetFont(ReportBase.BoldFont)
                    .Add(new Paragraph(cellText).SetMultipliedLeading(0.9f))
                    .SetBorderBottom(borderWidth)
                    .SetBorderTop(borderWidth)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);

                table.AddCell(cell);
            }
        }

        private string GetCellValue(ReportColumn column)
        {
            //if (!column.IsInTotal)
            //{
            //    throw new Exception($"'{column.DisplayName}' of {typeof(T)} class is not in the totol.");
            //}

            Type valListType = typeof(List<>).MakeGenericType(column.PropInfo.PropertyType);
            IList valList = (IList)Activator.CreateInstance(valListType);

            foreach (var item in Items)
            {
                object propValue = column.PropInfo.GetValue(item);
                valList.Add(propValue);
            }

            if (column.PropInfo.PropertyType == typeof(int))
            {
                return valList.Cast<int>().Sum().ToString();
            }
            else if (column.PropInfo.PropertyType == typeof(decimal))
            {
                return valList.Cast<decimal>().Sum().ToString();
            }
            else if (column.PropInfo.PropertyType == typeof(long))
            {
                return valList.Cast<long>().Sum().ToString();
            }

            return string.Empty;
        }
    }
}


