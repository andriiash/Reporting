using Metoda.Reporting.Lib.Attributes;
using Metoda.Reporting.Lib.Base;

namespace Metoda.Reporting.Models
{
    public class SummaryOfPerformanceStatementItem : ReportTableItemBase
    {
        [OutputOrder(1, "Cubi", 6f)]
        public string Cubi { get; set; }

        [OutputOrder(2, "N° Segn. Mese", 1f, isInTotal: true)]
        public int NumSegnMese { get; set; }

        [OutputOrder(3, "Totale Mese", 1f, isInTotal: true)]
        public decimal TotaleMese { get; set; }

        [OutputOrder(4, "N° Segn Mese Prec.", 1f, isInTotal: true)]
        public int NumSegnMesePrec { get; set; }

        [OutputOrder(5, "Totale Mese Prec.", 1f, isInTotal: true)]
        public decimal TotaleMesePrec { get; set; }
    }
}
