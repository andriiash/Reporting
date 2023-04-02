using iText.IO.Font;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Metoda.Reporting.Lib.Base;
using Metoda.Reporting.Lib.Base.Contracts;
using Metoda.Reporting.Lib.PdfHandlers;
using Metoda.Reporting.Lib.Res;
using System;
using System.IO;
using System.Linq;
using static iText.Kernel.Font.PdfFontFactory;

namespace Metoda.Reporting.Lib
{
    public class ReportGenerator
    {
        //public abstract void ToExcel<T>(string dest);

        //public static void ToPdf<T>(string dest, IReport<T> report) where T : IReportTableItem
        //{
        //    try
        //    {
        //        PdfWriter writer = new PdfWriter(dest);
        //        PdfDocument pdfDoc = new PdfDocument(writer);
        //        Document doc = new Document(pdfDoc, PageSize.A4, false);

        //        doc.SetTopMargin(60f);

        //        float tableWidth = 100f;
        //        SolidBorder sBorder = new SolidBorder(0.5f);


        //        FontProgram fontProgram = FontProgramFactory.CreateFont(Resource.CALIBRI);
        //        PdfFont regular = PdfFontFactory.CreateFont(fontProgram, PdfEncodings.WINANSI, EmbeddingStrategy.PREFER_EMBEDDED);
        //        PdfFont bold = PdfFontFactory.CreateFont(Resource.CALIBRIB, PdfEncodings.WINANSI, EmbeddingStrategy.PREFER_EMBEDDED);
        //        PdfFont italic = PdfFontFactory.CreateFont(Resource.CALIBRII, PdfEncodings.WINANSI, EmbeddingStrategy.PREFER_EMBEDDED);

        //        TableHeaderEventHandler headerHandler = new TableHeaderEventHandler(doc, regular);
        //        pdfDoc.AddEventHandler(PdfDocumentEvent.START_PAGE, headerHandler);

        //        Table table = new Table(2)
        //           .SetWidth(UnitValue.CreatePercentValue(tableWidth))
        //           .SetBorder(Border.NO_BORDER)
        //           .SetFontSize(11f)
        //           .SetFont(bold);

        //        Cell cell = new Cell(1, 2)
        //            .SetBorder(Border.NO_BORDER)
        //            .SetFontSize(12f)
        //            .SetTextAlignment(TextAlignment.CENTER)
        //            .Add(new Paragraph(report.Title));

        //        table.AddCell(cell);

        //        cell = new Cell()
        //            .SetBorder(Border.NO_BORDER)
        //            .SetTextAlignment(TextAlignment.LEFT)
        //            .Add(new Paragraph(report.Title));

        //        table.AddCell(cell);

        //        cell = new Cell()
        //            .SetBorder(Border.NO_BORDER)
        //            .SetTextAlignment(TextAlignment.RIGHT)
        //            .Add(new Paragraph($"Data Riferimento: {report.ReferenceDate.ToString("dd/MM/yyyy")}"));

        //        table.AddCell(cell);

        //        // no border on the cell
        //        cell = new Cell(1, 2)
        //            .SetBorder(Border.NO_BORDER)
        //            .SetBorderTop(sBorder)
        //            .SetBorderLeft(sBorder)
        //            .SetBorderRight(sBorder);

        //        Paragraph p = new Paragraph("Dati Controparte")
        //            .SetPaddingLeft(10f);

        //        cell.Add(p);
        //        table.AddCell(cell);

        //        Text dataLabel = new Text("Codice Controparte: ");
        //        Text dataValue = new Text("CTP123456789012 – Società XY").SetFont(regular);

        //        cell = new Cell(1, 2)
        //            .SetBorder(Border.NO_BORDER)
        //            .SetBorderLeft(sBorder)
        //            .SetBorderRight(sBorder);

        //        p = new Paragraph()
        //            .SetPaddingLeft(20f)
        //            .Add(dataLabel)
        //            .Add(dataValue);

        //        cell.Add(p);
        //        table.AddCell(cell);

        //        dataLabel = new Text("NDG: ");
        //        dataValue = new Text("0000000309169701").SetFont(regular);

        //        cell = new Cell(1, 2)
        //            .SetBorder(Border.NO_BORDER)
        //            .SetBorderLeft(sBorder)
        //            .SetBorderRight(sBorder)
        //            .SetBorderBottom(sBorder);

        //        p = new Paragraph()
        //            .SetPaddingLeft(20f)
        //            .Add(dataLabel)
        //            .Add(dataValue);

        //        cell.Add(p);
        //        table.AddCell(cell);

        //        table.SetMarginBottom(20f);
        //        doc.Add(table);

        //        var columns = report.Table.GetColumnArray();
        //        var colWidths = Enumerable.Repeat(1f, columns.Length).ToArray();
        //        var borderWidth = new SolidBorder(1.0f);

        //        Table tableDetals = new Table(UnitValue.CreatePercentArray(colWidths))
        //           .SetWidth(UnitValue.CreatePercentValue(tableWidth))
        //           .SetBorder(borderWidth)
        //           .SetFontSize(8f)
        //           .SetTextAlignment(TextAlignment.CENTER)
        //           .SetVerticalAlignment(VerticalAlignment.MIDDLE)
        //           .SetFont(regular)
        //           .SetPaddingTop(10f);

        //        #region Table Details Header 

        //        for (int i = 0; i < columns.Length; i++)
        //        {
        //            cell = new Cell()
        //                .SetFont(bold)
        //                .Add(new Paragraph(columns[i]).SetMultipliedLeading(0.9f))
        //                .SetBorderBottom(borderWidth)
        //                .SetVerticalAlignment(VerticalAlignment.MIDDLE);

        //            tableDetals.AddHeaderCell(cell);
        //        }
        //        #endregion Table Details Header

        //        foreach (var item in report.Table.Items)
        //        {
        //            foreach (var val in item.GetValueArray(report.Table.ItemInfo))
        //            {
        //                cell = new Cell().Add(new Paragraph(val).SetMultipliedLeading(0.9f));
        //                tableDetals.AddCell(cell);
        //            }
        //        }

        //        doc.Add(tableDetals);

        //        Footer footerHandler = new Footer();
        //        pdfDoc.AddEventHandler(PdfDocumentEvent.END_PAGE, footerHandler);
        //        footerHandler.WriteTotal(pdfDoc);

        //        doc.Close();
        //    }
        //    catch (FileNotFoundException)
        //    {
        //        throw;
        //    }
        //    catch (IOException)
        //    {
        //        throw;
        //    }
        //}
    }
}
