using iText.Kernel.Events;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Kernel.Geom;

namespace Metoda.Reporting.Lib.PdfHandlers
{
    /*
     * public class TableFooterEventHandler : IEventHandler
    {
        private iText.Layout.Element.Table table;

        public TableFooterEventHandler(iText.Layout.Element.Table table)
        {
            this.table = table;
        }

        public void HandleEvent(Event currentEvent)
        {
            PdfDocumentEvent docEvent = (PdfDocumentEvent)currentEvent;
            PdfDocument pdfDoc = docEvent.GetDocument();
            PdfPage page = docEvent.GetPage();
            int pageNumber = pdfDoc.GetPageNumber(page);
            Rectangle pageSize = page.GetPageSize();
            PdfCanvas canvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);
            new Canvas(canvas, new Rectangle(36, 20, page.GetPageSize().GetWidth() - 72, 50)).Add(table).Close();
        }
    }
    */
}
