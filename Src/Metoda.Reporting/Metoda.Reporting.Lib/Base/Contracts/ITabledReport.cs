using System.Collections.Generic;

namespace Metoda.Reporting.Lib.Base.Contracts
{
    public interface ITabledReport<T, RT> : IReportBase
        where RT : IReportTable<T>
        where T : IReportTableItem
    {
        IList<RT> TableList { get; }
    }
}