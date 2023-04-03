using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Metoda.Reporting.Lib.Base.Contracts;

namespace Metoda.Reporting.Lib.Base
{
    public abstract class ReportTableItemBase : IReportTableItem
    {
        public string[] GetValueArray(IList<PropertyInfo> itemInfo)
        {
            return itemInfo.Select(_ => _.GetValue(this)?.ToString()).ToArray();
        }
    }
}
