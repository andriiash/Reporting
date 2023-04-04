using Metoda.Reporting.Lib.Base;
using System.Collections.Generic;

namespace Metoda.Reporting.Models
{
    public class InconsistencyBetweenOriginalAndResidualDurationReportTable : ReportTable<InconsistencyBetweenOriginalAndResidualDurationItem>
    {
        public InconsistencyBetweenOriginalAndResidualDurationReportTable(IList<InconsistencyBetweenOriginalAndResidualDurationItem> items = null) 
            : base(items)  
        {
        }
    }
}
