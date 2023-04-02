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

        protected virtual float[] ColWidths { get; set; } = null;

        public TabledReport(string title, string companyName, DateTime refDate, ReportTable<T> table)
            : base(title, companyName, refDate)
        {
            Table = table;
        }

        protected override void RenderDetailsTable(Document doc)
        {
            var columns = Table.GetColumnArray();
            var colWidths = ColWidths ?? Enumerable.Repeat(1f, columns.Length).ToArray();
            var borderWidth = new SolidBorder(1.0f);

            Table tableDetals = new Table(UnitValue.CreatePercentArray(colWidths))
               .SetWidth(UnitValue.CreatePercentValue(_tableWidth))
               .SetBorder(borderWidth)
               .SetFontSize(8f)
               .SetTextAlignment(TextAlignment.CENTER)
               .SetVerticalAlignment(VerticalAlignment.MIDDLE)
               .SetFont(_regular)
               .SetPaddingTop(10f);

            #region Table Details Header 
            Cell cell;

            for (int i = 0; i < columns.Length; i++)
            {
                cell = new Cell()
                    .SetFont(_bold)
                    .Add(new Paragraph(columns[i]).SetMultipliedLeading(0.9f))
                    .SetBorderBottom(borderWidth)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);

                tableDetals.AddHeaderCell(cell);
            }
            #endregion Table Details Header

            foreach (var item in Table.Items)
            {
                foreach (var val in item.GetValueArray(Table.ItemInfo))
                {
                    cell = new Cell().Add(new Paragraph(val).SetMultipliedLeading(0.9f));
                    tableDetals.AddCell(cell);
                }
            }

            doc.Add(tableDetals);
        }
    }
}
