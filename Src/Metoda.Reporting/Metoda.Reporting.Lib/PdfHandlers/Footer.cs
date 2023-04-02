using iText.Kernel.Events;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Xobject;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Metoda.Reporting.Lib.PdfHandlers
{
    public class Footer : IEventHandler
    {
        protected PdfFormXObject placeholder;
        protected float side = 20;
        // protected float x = 300;
        protected float y = 25;
        protected float space = 4.5f;
        protected float descent = 3;

        public Footer()
        {
            placeholder = new PdfFormXObject(new Rectangle(0, 0, side, side));
        }

        public virtual void HandleEvent(Event evt)
        {
            PdfDocumentEvent docEvent = (PdfDocumentEvent)evt;
            PdfDocument pdf = docEvent.GetDocument();
            PdfPage page = docEvent.GetPage();
            int pageNumber = pdf.GetPageNumber(page);
            Rectangle pageSize = page.GetPageSize();
            PdfCanvas pdfCanvas = new PdfCanvas(page);
            Canvas canvas = new Canvas(pdfCanvas, pageSize);
            canvas.SetFontSize(8);
            Paragraph p = new Paragraph($"Pag. {pageNumber} di");


            var offsetX = pageSize.GetWidth() - 2 * side - descent;
            //canvas.ShowTextAligned(p, x, y, TextAlignment.RIGHT);

            canvas.ShowTextAligned(p, offsetX, y, TextAlignment.RIGHT);

            canvas.Close();
            pdfCanvas.AddXObjectAt(placeholder, offsetX + space, y - descent);
            pdfCanvas.Release();
        }

        public void WriteTotal(PdfDocument pdfDoc)
        {
            Canvas canvas = new Canvas(placeholder, pdfDoc);
            canvas.SetFontSize(8);
            canvas.ShowTextAligned(pdfDoc.GetNumberOfPages().ToString(), 0, descent, TextAlignment.LEFT);
            canvas.Close();
        }
    }
}