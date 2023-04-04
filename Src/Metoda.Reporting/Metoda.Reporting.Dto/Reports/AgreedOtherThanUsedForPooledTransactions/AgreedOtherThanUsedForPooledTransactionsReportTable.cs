using Metoda.Reporting.Lib.Base;
using System.Collections.Generic;

namespace Metoda.Reporting.Models
{
    public class AgreedOtherThanUsedForPooledTransactionsReportTable : ReportTable<AgreedOtherThanUsedForPooledTransactionsItem>
    {
        public AgreedOtherThanUsedForPooledTransactionsReportTable(IList<AgreedOtherThanUsedForPooledTransactionsItem> items = null) 
            : base(items)  
        {
        }
    }
}
