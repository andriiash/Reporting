using iText.IO.Image;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Layout;
using iText.Layout.Properties;
using iText.Layout.Renderer;
using Metoda.Reporting.Lib.Res;
using System;

namespace Metoda.Reporting.Lib.PdfHandlers
{
    public class TableHeaderEventHandler : IEventHandler
    {
        private Table _1stPageTable;
        private Table _otherPagesTable;
        private float _tableHeight;
        private Document _doc;
        private PdfFont _font;

        public TableHeaderEventHandler(Document doc, PdfFont font)
        {
            _doc = doc;
            _font = font;            
            _1stPageTable = GetHeaderTable(true);
            _otherPagesTable = GetHeaderTable();
           
            TableRenderer renderer = (TableRenderer)_1stPageTable.CreateRendererSubTree();
            renderer.SetParent(new DocumentRenderer(doc));

            renderer = (TableRenderer)_otherPagesTable.CreateRendererSubTree();
            renderer.SetParent(new DocumentRenderer(doc));

            LayoutResult result = renderer.Layout(new LayoutContext(new LayoutArea(0, PageSize.A4)));
            _tableHeight = result.GetOccupiedArea().GetBBox().GetHeight();
        }

        public void HandleEvent(Event evt)
        {
            PdfDocumentEvent docEvent = (PdfDocumentEvent)evt;
            PdfDocument pdfDoc = docEvent.GetDocument();
            PdfPage page = docEvent.GetPage();
            int pageNum = docEvent.GetDocument().GetPageNumber(page);
            var table = (pageNum == 1) ? _1stPageTable : _otherPagesTable;            
            PdfCanvas canvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);
            PageSize pageSize = pdfDoc.GetDefaultPageSize();
            float coordX = pageSize.GetX() + _doc.GetLeftMargin();
            float coordY = pageSize.GetTop() - _doc.GetTopMargin();
            float width = pageSize.GetWidth() - _doc.GetRightMargin() - _doc.GetLeftMargin();
            float height = GetTableHeight();
            Rectangle rect = new Rectangle(coordX, coordY, width, height);
            
            new Canvas(canvas, rect).Add(table).Close();
        }

        public float GetTableHeight()
        {
            return _tableHeight;
        }

        private Table GetHeaderTable(bool _isFirst = false)
        {
            Table table = new Table(2)
                .SetWidth(UnitValue.CreatePercentValue(100f))
                .SetBorder(Border.NO_BORDER)
                .SetFontSize(11f)
                .SetFont(_font)
                .SetBorderBottom(new SolidBorder(0.5f));

            Cell cell = new Cell()
                .SetBorder(Border.NO_BORDER)
                .SetHorizontalAlignment(HorizontalAlignment.LEFT);

            Image image = new Image(ImageDataFactory.Create(Resource.logo_metoda))
                .SetHeight(24f)
                .SetPaddingLeft(10f);

            cell.Add(image);
            table.AddCell(cell);

            cell = new Cell()
                .SetBorder(Border.NO_BORDER)
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetVerticalAlignment(VerticalAlignment.BOTTOM);

            if (_isFirst)
            {
                Paragraph p = new Paragraph($"Data Stampa: {DateTime.Now.ToString("dd/MM/yyyy")}");
                cell.Add(p);
            }

            table.AddCell(cell);
            table.SetMarginBottom(5f);

            return table;
        }
    }

}