using Metoda.Reporting.Lib.Base;
using System.Collections.Generic;

namespace Metoda.Reporting.Models
{
    public class OtherCreditsButImpairedReportTable : ReportTable<OtherCreditsButImpairedItem>
    {
        public OtherCreditsButImpairedReportTable(IList<OtherCreditsButImpairedItem> items = null) 
            : base(items)  
        {
        }
    }
}
