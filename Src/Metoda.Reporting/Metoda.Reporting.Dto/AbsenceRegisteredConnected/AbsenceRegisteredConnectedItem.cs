using Metoda.Reporting.Lib.Attributes;
using Metoda.Reporting.Lib.Base;
using System;
using System.ComponentModel;

namespace Metoda.Reporting.Models.AbsenceRegisteredConnected
{
    public class AbsenceRegisteredConnectedItem : ReportTableItemBase
    {
        [OutputOrder(1, 2f)]
        [DisplayName("Cod.Censito")]
        public string CodCensito { get; set; }

        [OutputOrder(2, 5f)]
        [DisplayName("Cubo")]
        public string Cubo { get; set; }

        [OutputOrder(3, 1f)]
        [DisplayName("Accordato")]
        public string Accordato { get; set; }

        [OutputOrder(5, 1f)]
        [DisplayName("Delta")]
        public string Delta { get; set; }

        [OutputOrder(4, 1f)]
        [DisplayName("Utilizzato")]
        public string Utilizzato { get; set; }
    }
}
