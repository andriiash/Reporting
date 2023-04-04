using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Metoda.Reporting.Lib.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Metoda.Reporting.Lib.Base
{
    public abstract class TabledReport<T, RT> : ReportBase, ITabledReport<T, RT> 
        where RT : ReportTable<T>
        where T : IReportTableItem

    {
        public IList<RT> TableList { get; private set; }

        public TabledReport(string title, string companyName, DateTime refDate, IList<RT> tableList)
            : base(title, companyName, refDate)
        {
            TableList = tableList;
        }

        protected override void RenderDetailsTable(Document doc)
        {
            if (TableList.Count > 0)
            {
                Table tableDetals = RenderTable(TableList[0]);

                foreach (var item in TableList)
                {
                    item.PrintToPdf(tableDetals);
                }

                if (TableList.Count > 1)
                {
                    ReportTable<T>.PrintTotalToPdf(
                        tableDetals, 
                        TableList[0].Columns, 
                        TableList.SelectMany(_ => _.Items).ToList(),
                        "Somma totale"
                                );
                }

                doc.Add(tableDetals);
            }
            else
            {
                doc.Add(new Paragraph("NO DATA TO DISPLAY").SetFont(ItalicFont).SetBold().SetFontSize(14f));
            }
        }

        private Table RenderTable(RT pdfTable)
        {
            var columns = pdfTable.Columns.Select(_ => _.DisplayName).ToArray();
            var colWidths = pdfTable.Columns.Select(_ => _.ColWidth).ToArray();
            var borderWidth = new SolidBorder(1.0f);

            Table tableDetals = new Table(UnitValue.CreatePercentArray(colWidths))
               .SetWidth(UnitValue.CreatePercentValue(_tableWidth))
               .SetBorder(borderWidth)
               .SetFontSize(8f)
               .SetTextAlignment(TextAlignment.CENTER)
               .SetVerticalAlignment(VerticalAlignment.MIDDLE)
               .SetFont(RegularFont)
               .SetPaddingTop(10f);

            #region Table Details Header 
            Cell cell;

            for (int i = 0; i < columns.Length; i++)
            {
                cell = new Cell()
                    .SetFont(BoldFont)
                    .Add(new Paragraph(columns[i]).SetMultipliedLeading(0.9f))
                    .SetBorderBottom(borderWidth)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);

                tableDetals.AddHeaderCell(cell);
            }
            #endregion Table Details Header
            return tableDetals;
        }
    }
}
