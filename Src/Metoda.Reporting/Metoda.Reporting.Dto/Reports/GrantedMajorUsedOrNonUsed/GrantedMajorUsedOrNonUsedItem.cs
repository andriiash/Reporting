using Metoda.Reporting.Lib.Attributes;
using Metoda.Reporting.Lib.Base;

namespace Metoda.Reporting.Models
{
    public class GrantedMajorUsedOrNonUsedItem : ReportTableItemBase
    {
        [OutputOrder(1, "Cod. Censito", 2f)]
        public string CodCensito { get; set; }

        [OutputOrder(2, "Cubo", 5f)]
        public string Cubo { get; set; }

        [OutputOrder(3, "Accordato", 1f, isInTotal: true)]
        public decimal Accordato { get; set; }

        [OutputOrder(5, "Sbilancio", 1f, isInTotal: true)]
        public decimal Sbilancio { get; set; }

        [OutputOrder(4, "Utilizzato", 1f, isInTotal: true)]
        public decimal Utilizzato { get; set; }
    }
}
