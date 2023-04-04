using iText.Layout.Element;
using Metoda.Reporting.Lib.Base;
using System.Collections.Generic;

namespace Metoda.Reporting.Models
{
    public class GuaranteesConnectedWithOperationsOfACommercialNatureReportTable : ReportTable<GuaranteesConnectedWithOperationsOfACommercialNatureItem>
    {
        public GuaranteesConnectedWithOperationsOfACommercialNatureReportTable(IList<GuaranteesConnectedWithOperationsOfACommercialNatureItem> items = null) 
            : base(items)  
        {
        }
    }
}
