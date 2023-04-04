using Metoda.Reporting.Lib.Attributes;
using Metoda.Reporting.Lib.Base;

namespace Metoda.Reporting.Models
{
    public class OtherCreditsButImpairedItem : ReportTableItemBase
    {
        [OutputOrder(1, "Cod. Censito", 2f)]
        public string CodCensito { get; set; }

        [OutputOrder(2, "Cubo", 4f)]
        public string Cubo { get; set; }

        [OutputOrder(3, "Stato Rapporto", 1.5f)]
        public string StatoRapporto { get; set; }

        [OutputOrder(4, "Qualità Credito", 1.5f)]
        public string QualitaCredito { get; set; }

        [OutputOrder(5, "Utilizzato", 1f, isInTotal: true)]
        public decimal Utilizzato { get; set; }
    }
}
