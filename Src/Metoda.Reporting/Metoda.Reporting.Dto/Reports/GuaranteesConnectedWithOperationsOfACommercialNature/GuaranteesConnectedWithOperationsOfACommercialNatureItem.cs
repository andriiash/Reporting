using Metoda.Reporting.Lib.Attributes;
using Metoda.Reporting.Lib.Base;

namespace Metoda.Reporting.Models
{
    public class GuaranteesConnectedWithOperationsOfACommercialNatureItem : ReportTableItemBase
    {
        [OutputOrder(1, "Cod.Censito", 2f)]
        public string CodCensito { get; set; }

        [OutputOrder(2, "Localizzazione", 2f)]
        public string Localizzazione { get; set; }

        [OutputOrder(3, "Divisa", 1f)]
        public string Divisa { get; set; }

        [OutputOrder(4, "Import/Export", 2f)]
        public string ImportOrExport { get; set; }

        [OutputOrder(5, "StatoRapporto", 2f)]
        public string StatoRapporto { get; set; }

        [OutputOrder(5, "Utilizzato", 1.5f, isInTotal: true)]
        public decimal Utilizzato { get; set; }
    }
}
