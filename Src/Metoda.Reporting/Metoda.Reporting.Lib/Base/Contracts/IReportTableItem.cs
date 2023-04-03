using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Metoda.Reporting.Lib.Base.Contracts
{
    public interface IReportTableItem
    {
        string[] GetValueArray(IList<PropertyInfo> itemInfo);
    }
}
