using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace Metoda.Reporting.Lib.Attributes
{
    public class ReportColumn
    {
        public int Order { get; }

        public string DisplayName { get; }

        public float ColWidth { get; }
        public int ColSpan { get; }
        public bool IsInTotal { get; }
        public PropertyInfo PropInfo { get; set; }

        public ReportColumn(int order, string displayName, float colWidth = 1f, int colSpan = 1, bool isInTotal = false)
        {            
            Order = order;
            DisplayName = displayName;
            ColWidth = colWidth;
            ColSpan = colSpan;
            IsInTotal = isInTotal;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class OutputOrderAttribute : Attribute
    {
        public ReportColumn Column { get; }

        public OutputOrderAttribute(int order, string displayName, float colWidth = 1f, int colSpan = 1, bool isInTotal = false)
        {
            Column = new ReportColumn(order, displayName, colWidth, colSpan, isInTotal);
        }

        public static IList<ReportColumn> GetReportColumns(Type objectType)
        {
            Type type = typeof(OutputOrderAttribute);
            var props = objectType.GetProperties()
                .Where(p => IsDefined(p, type))
                .OrderBy(p => ((OutputOrderAttribute)p.GetCustomAttribute(type)).Column.Order);

            IList<ReportColumn> columns = new List<ReportColumn>();

            foreach (var prop in props)
            {
                var col = ((OutputOrderAttribute)prop.GetCustomAttribute(type)).Column;
                col.PropInfo = prop;
                columns.Add(col);
            }

            return columns;
        }

        public static IOrderedEnumerable<PropertyInfo> GetOrderedProperties(Type objectType)
        {
            Type type = typeof(OutputOrderAttribute);
            return objectType.GetProperties()
                .Where(p => IsDefined(p, type))
                .OrderBy(p => ((OutputOrderAttribute)p.GetCustomAttribute(type)).Column.Order);
        }
    }
}
