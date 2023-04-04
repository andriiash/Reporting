using Metoda.Reporting.Lib.Attributes;
using Metoda.Reporting.Lib.Base;

namespace Metoda.Reporting.Models
{
    public class InconsistencyBetweenOriginalAndResidualDurationItem : ReportTableItemBase
    {
        [OutputOrder(1, "Cod.Censito", 1.5f)]
        public string CodCensito { get; set; }

        [OutputOrder(2, "Cubo", 2.5f)]
        public string Cubo { get; set; }

        [OutputOrder(3, "Durata Originaria", 1.5f)]
        public string DurataOriginaria { get; set; }

        [OutputOrder(4, "Durata Residua", 1.5f)]
        public string DurataResidua { get; set; }

        [OutputOrder(5, "Accordato", 1f, isInTotal: true)]
        public decimal Accordato { get; set; }

        [OutputOrder(6, "Utilizzato", 1f, isInTotal: true)]
        public decimal Utilizzato { get; set; }

        [OutputOrder(7, "Sbilancio", 1f, isInTotal: true)]
        public decimal Sbilancio { get; set; }
    }
}
