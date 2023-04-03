using System;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Linq;
using Metoda.Reporting.Lib.Base.Contracts;
using iText.Layout;

namespace Metoda.Reporting.Lib.Base
{
    public abstract class TabledReport<T> : ReportBase, ITabledReport<T> where T : IReportTableItem
    {
        public ReportTable<T> Table { get; private set; }

        public TabledReport(string title, string companyName, DateTime refDate, ReportTable<T> table)
            : base(title, companyName, refDate)
        {
            Table = table;
        }

        protected override void RenderDetailsTable(Document doc)
        {
            Table tableDetals = RenderTable();
            Table.PrintToPdf(tableDetals);

            doc.Add(tableDetals);
        }

        private Table RenderTable()
        {
            var columns = Table.Columns.Select(_ => _.DisplayName).ToArray();
            var colWidths = Table.Columns.Select(_ => _.ColWidth).ToArray();
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
