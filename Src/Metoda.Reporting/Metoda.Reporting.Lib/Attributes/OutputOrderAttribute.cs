using System;
using System.Linq;
using System.Reflection;


namespace Metoda.Reporting.Lib.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class OutputOrderAttribute : Attribute
    {
        public int Order { get; }
        public float ColWidth { get; }
        public int ColSpan { get; }

        public OutputOrderAttribute(int order, float colWidth = 1f, int colSpan = 1)
        {
            Order = order;
            ColWidth = colWidth;    
            ColSpan = colSpan;
        }

        public static IOrderedEnumerable<PropertyInfo> GetOrderedProperties(Type objectType)
        {
            Type type = typeof(OutputOrderAttribute);
            return objectType.GetProperties()
                .Where(p => IsDefined(p, type))
                .OrderBy(p => ((OutputOrderAttribute)p.GetCustomAttribute(type)).Order);
        }
    }
}
