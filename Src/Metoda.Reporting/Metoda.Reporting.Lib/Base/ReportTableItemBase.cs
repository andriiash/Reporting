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
            return itemInfo.Select(_ =>
            _.PropertyType == typeof(decimal)
                ? ((decimal)(_.GetValue(this) ?? 0)).ToString("N2", new System.Globalization.CultureInfo("it-IT"))
                : _.GetValue(this)?.ToString()).ToArray();
        }
    }
}
