using Metoda.Reporting.Lib.Base;
using System.Collections.Generic;

namespace Metoda.Reporting.Models
{
    public class AbsenceRegisteredConnectedReportTable : ReportTable<AbsenceRegisteredConnectedItem>
    {
        public AbsenceRegisteredConnectedReportTable(IList<AbsenceRegisteredConnectedItem> items = null) 
            : base(items)  
        {
        }
    }
}
