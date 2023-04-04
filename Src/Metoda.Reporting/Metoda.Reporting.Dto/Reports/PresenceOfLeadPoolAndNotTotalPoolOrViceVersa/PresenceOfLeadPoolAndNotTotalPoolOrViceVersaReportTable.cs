using Metoda.Reporting.Lib.Base;
using System.Collections.Generic;

namespace Metoda.Reporting.Models
{
    public class PresenceOfLeadPoolAndNotTotalPoolOrViceVersaReportTable : ReportTable<PresenceOfLeadPoolAndNotTotalPoolOrViceVersaItem>
    {
        public PresenceOfLeadPoolAndNotTotalPoolOrViceVersaReportTable(IList<PresenceOfLeadPoolAndNotTotalPoolOrViceVersaItem> items = null) 
            : base(items)  
        {
        }
    }
}
