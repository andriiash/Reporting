using Metoda.Reporting.Lib.Base;
using System.Collections.Generic;

namespace Metoda.Reporting.Models
{
    public class GrantedMajorUsedOrNonUsedReportTable : ReportTable<GrantedMajorUsedOrNonUsedItem>
    {
        public GrantedMajorUsedOrNonUsedReportTable(IList<GrantedMajorUsedOrNonUsedItem> items = null) 
            : base(items)  
        {
        }
    }
}
