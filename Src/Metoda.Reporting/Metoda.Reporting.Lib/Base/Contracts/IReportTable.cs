using iText.Layout.Element;
using Metoda.Reporting.Lib.Attributes;
using System.Collections.Generic;

namespace Metoda.Reporting.Lib.Base.Contracts
{
    public interface IReportTable<I> where I : IReportTableItem
    {
        IList<ReportColumn> Columns { get; }
        IList<I> Items { get; }
        void PrintToPdf(Table table);
    }
}
