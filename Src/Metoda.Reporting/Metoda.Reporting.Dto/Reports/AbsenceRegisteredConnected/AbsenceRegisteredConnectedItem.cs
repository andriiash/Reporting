using Metoda.Reporting.Lib.Attributes;
using Metoda.Reporting.Lib.Base;

namespace Metoda.Reporting.Models
{
    public class AbsenceRegisteredConnectedItem : ReportTableItemBase
    {
        [OutputOrder(1, "Op", 1f)]
        public string Op { get; set; }

        [OutputOrder(2, "Cod.Censito", 2f)]
        public string CodCensito { get; set; }

        [OutputOrder(3, "Fenomeno", 4f)]
        public string Fenomeno { get; set; }

        [OutputOrder(4, "Stato Rapporto", 1.5f)]
        public string StatoRapporto { get; set; }

        [OutputOrder(5, "Valore", 1.5f, isInTotal: true)]
        public decimal Valore { get; set; }
    }
}
