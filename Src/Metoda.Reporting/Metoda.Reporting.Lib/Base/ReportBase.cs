using iText.IO.Font;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Metoda.Reporting.Lib.Base.Contracts;
using Metoda.Reporting.Lib.PdfHandlers;
using Metoda.Reporting.Lib.Res;
using System;
using System.IO;

namespace Metoda.Reporting.Lib.Base
{
    public abstract class ReportBase : IReportBase
    {
        public static PdfFont RegularFont = PdfFontFactory.CreateFont(Resource.CALIBRI, PdfEncodings.WINANSI, PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED);
        public static PdfFont BoldFont = PdfFontFactory.CreateFont(Resource.CALIBRIB, PdfEncodings.WINANSI, PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED);
        public static PdfFont ItalicFont = PdfFontFactory.CreateFont(Resource.CALIBRII, PdfEncodings.WINANSI, PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED);
        protected float _tableWidth = 100f;

        public string Title { get; set; }
        public string CompanyName { get; set; }
        public DateTime ReferenceDate { get; set; }

        public ReportBase(string title, string companyName, DateTime refDate)
        {
            Title = title;
            CompanyName = companyName;
            ReferenceDate = refDate;
        }

        //public abstract void ToExcel(string dest);
        public void ToPdf(string dest)
        {
            try
            {
                PdfWriter writer = new PdfWriter(dest);
                PdfDocument pdfDoc = new PdfDocument(writer);
                Document doc = new Document(pdfDoc, PageSize.A4, false);

                doc.SetTopMargin(60f);

                RenderHeader(pdfDoc, doc);

                RenderTitleTable(doc);

                RenderBody(doc);

                RenderFooter(pdfDoc);

                doc.Close();
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (IOException)
            {
                throw;
            }
        }

        private void RenderBody(Document doc)
        {
            RenderSubHeader(doc);

            RenderDetailsTable(doc);

            RenderSubFooter(doc);
        }

        protected virtual void RenderDetailsTable(Document doc)
        {            
        }

        protected virtual void RenderSubHeader(Document doc)
        {           
        }

        protected virtual void RenderSubFooter(Document doc)
        {
        }

        private void RenderTitleTable(Document doc)
        {
            Table table = new Table(2)
                               .SetWidth(UnitValue.CreatePercentValue(_tableWidth))
                               .SetBorder(Border.NO_BORDER)
                               .SetFontSize(11f)
                               .SetFont(BoldFont);
            Cell cell = new Cell(1, 2)
                .SetBorder(Border.NO_BORDER)
                .SetFontSize(12f)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph(Title));
            table.AddCell(cell);

            cell = new Cell()
                .SetBorder(Border.NO_BORDER)
                .SetTextAlignment(TextAlignment.LEFT)
                .Add(new Paragraph(CompanyName));

            table.AddCell(cell);

            cell = new Cell()
                .SetBorder(Border.NO_BORDER)
                .SetTextAlignment(TextAlignment.RIGHT)
                .Add(new Paragraph($"Data Riferimento: {ReferenceDate.ToString("yyyy-MM-dd")}"));

            table.AddCell(cell);

            doc.Add(table);
        }

        private void RenderHeader(PdfDocument pdfDoc, Document doc)
        {
            TableHeaderEventHandler headerHandler = new TableHeaderEventHandler(doc, RegularFont);
            pdfDoc.AddEventHandler(PdfDocumentEvent.START_PAGE, headerHandler);
        }

        private void RenderFooter(PdfDocument pdfDoc)
        {
            Footer footerHandler = new Footer();
            pdfDoc.AddEventHandler(PdfDocumentEvent.END_PAGE, footerHandler);
            footerHandler.WriteTotal(pdfDoc);
        }
    }
}
