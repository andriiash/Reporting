using System;
using iText.Layout.Borders;
using iText.Layout.Element;
using Metoda.Reporting.Lib.Base.Contracts;
using iText.Layout;

namespace Metoda.Reporting.Lib.Base
{
    public abstract class SubHeaderTabledReport<T> : TabledReport<T> where T : IReportTableItem
    {
        public SubHeaderTabledReport(string title, string companyName, DateTime refDate, ReportTable<T> table)
            : base(title, companyName, refDate, table)
        {
        }

        protected override void RenderSubHeader(Document doc)
        {
            SolidBorder sBorder = new SolidBorder(0.5f);
            Table table = new Table(1);
            // no border on the cell
            Cell cell = new Cell(1, 2)
                .SetBorder(Border.NO_BORDER)
                .SetBorderTop(sBorder)
                .SetBorderLeft(sBorder)
                .SetBorderRight(sBorder);

            Paragraph p = new Paragraph("Dati Controparte")
                .SetPaddingLeft(10f);

            cell.Add(p);
            table.AddCell(cell);

            Text dataLabel = new Text("Codice Controparte: ");
            Text dataValue = new Text("CTP123456789012 – Società XY").SetFont(ReportBase.RegularFont);

            cell = new Cell(1, 2)
                .SetBorder(Border.NO_BORDER)
                .SetBorderLeft(sBorder)
                .SetBorderRight(sBorder);

            p = new Paragraph()
                .SetPaddingLeft(20f)
                .Add(dataLabel)
                .Add(dataValue);

            cell.Add(p);
            table.AddCell(cell);

            dataLabel = new Text("NDG: ");
            dataValue = new Text("0000000309169701").SetFont(ReportBase.RegularFont);

            cell = new Cell(1, 2)
                .SetBorder(Border.NO_BORDER)
                .SetBorderLeft(sBorder)
                .SetBorderRight(sBorder)
                .SetBorderBottom(sBorder);

            p = new Paragraph()
                .SetPaddingLeft(20f)
                .Add(dataLabel)
                .Add(dataValue);

            cell.Add(p);
            table.AddCell(cell);

            table.SetMarginBottom(20f);
            doc.Add(table);
        }
    }
}
