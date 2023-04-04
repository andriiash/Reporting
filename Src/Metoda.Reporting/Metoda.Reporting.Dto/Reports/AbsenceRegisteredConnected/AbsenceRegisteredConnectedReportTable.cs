using iText.Layout.Element;
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

        public override void PrintToPdf(Table table, bool hasTotal = true)
        {
            base.PrintToPdf(table, false);

            if (hasTotal) 
            {
                PrintTotalToPdf(table, Columns, Items, "<What kind of Total should be here?!!!>");
                PrintTotalToPdf(table, Columns, Items, "<and here?!!!>");
            }
        }
    }
}
