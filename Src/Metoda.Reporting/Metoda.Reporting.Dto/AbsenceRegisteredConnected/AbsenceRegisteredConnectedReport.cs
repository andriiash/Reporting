using Metoda.Reporting.Lib.Base;
using System;

namespace Metoda.Reporting.Models.AbsenceRegisteredConnected
{
    public class AbsenceRegisteredConnectedReport : TabledReport<AbsenceRegisteredConnectedItem>
    {
        protected override float[] ColWidths { get; set; } = new float[] { 2f, 5f, 1f, 1f, 1f };

        public AbsenceRegisteredConnectedReport(ReportTable<AbsenceRegisteredConnectedItem> table)
            : base(
                 title: "ACCORDATO DIVERSO DA UTILIZZATO PER OPERAZIONI IN POOL",
                 companyName: "09999 - Banca di Prova",
                 refDate: new DateTime(2018, 09, 30),
                 table: table
                 )
        {

        }
    }
}
