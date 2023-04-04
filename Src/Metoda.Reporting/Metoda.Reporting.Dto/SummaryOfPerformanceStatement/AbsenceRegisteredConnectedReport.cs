using Metoda.Reporting.Lib.Base;
using System;
using System.Collections.Generic;

namespace Metoda.Reporting.Models
{
    public class AbsenceRegisteredConnectedReport : TabledReport<GrantedMajorUsedOrNonUsedItem>
    {
        public AbsenceRegisteredConnectedReport(IList<ReportTable<GrantedMajorUsedOrNonUsedItem>> tableList)
            : base(
                 title: "ACCORDATO DIVERSO DA UTILIZZATO PER OPERAZIONI IN POOL",
                 companyName: "09999 - Banca di Prova",
                 refDate: new DateTime(2018, 09, 30),
                 tableList: tableList
                 )
        {

        }
    }
}
