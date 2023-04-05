using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using iText.Layout.Properties;
using Metoda.Reporting.Lib.Base.Contracts;

namespace Metoda.Reporting.Lib.Base
{
    public abstract class ReportTableItemBase : IReportTableItem
    {
        public ValueTuple<TextAlignment, string>[] GetValueArray(IList<PropertyInfo> itemInfo)
        {
            return itemInfo.Select(_ =>             
                new ValueTuple<TextAlignment, string>( 
                    _.PropertyType == typeof(decimal) || _.PropertyType == typeof(int)
                                        ? TextAlignment.CENTER 
                                        : TextAlignment.LEFT,
                    _.PropertyType == typeof(decimal)
                                        ? ((decimal)(_.GetValue(this) ?? 0)).ToString("N2", new System.Globalization.CultureInfo("it-IT"))
                                        : _.GetValue(this)?.ToString())).ToArray();
        }
    }
}
