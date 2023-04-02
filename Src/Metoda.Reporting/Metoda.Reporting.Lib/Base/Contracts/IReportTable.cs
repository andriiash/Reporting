using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Metoda.Reporting.Lib.Base.Contracts
{
    public interface IReportTable<I> where I : IReportTableItem
    {
        IList<I> Items { get; }
        string[] GetColumnArray();
        IOrderedEnumerable<PropertyInfo> ItemInfo { get; }
    }
}
