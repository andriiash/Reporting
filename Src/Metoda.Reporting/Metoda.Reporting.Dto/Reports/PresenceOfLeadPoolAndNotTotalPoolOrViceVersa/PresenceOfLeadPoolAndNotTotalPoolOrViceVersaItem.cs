using Metoda.Reporting.Lib.Attributes;
using Metoda.Reporting.Lib.Base;

namespace Metoda.Reporting.Models
{
    public class PresenceOfLeadPoolAndNotTotalPoolOrViceVersaItem : ReportTableItemBase
    {
        [OutputOrder(1, "Cod. Censito", 2f)]
        public string CodCensito { get; set; }

        [OutputOrder(2, "Cubo", 4f)]
        public string Cubo { get; set; }

        [OutputOrder(3, "Capofila Accordato", 1f, isInTotal: true)]
        public decimal CapofilaAccordato { get; set; }

        [OutputOrder(4, "Capofila Utilizzato", 1f, isInTotal: true)]
        public decimal CapofilaUtilizzato { get; set; }

        [OutputOrder(5, "Tot. Accordato", 1f, isInTotal: true)]
        public decimal TotAccordato { get; set; }

        [OutputOrder(6, "Tot. Utilizzato", 1f, isInTotal: true)]
        public decimal TotUtilizzato { get; set; }
    }
}
