using iText.Layout.Element;
using Metoda.Reporting.Lib.Base;
using System.Collections.Generic;

namespace Metoda.Reporting.Models
{
    public class SummaryOfPerformanceStatementReportTable : ReportTable<SummaryOfPerformanceStatementItem>
    {
        public SummaryOfPerformanceStatementReportTable(IList<SummaryOfPerformanceStatementItem> items = null)
            : base(items)
        {
        }        
    }
}
