using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Metoda.Reporting.Lib.Base.Contracts
{
    public interface IReportTableItem
    {
        ValueTuple<TextAlignment, string>[] GetValueArray(IList<PropertyInfo> itemInfo);
    }
}
