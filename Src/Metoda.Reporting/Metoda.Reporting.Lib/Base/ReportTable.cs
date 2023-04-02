using Metoda.Reporting.Lib.Attributes;
using Metoda.Reporting.Lib.Base.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Metoda.Reporting.Lib.Base
{

    public class ReportTable<T> : IReportTable<T> where T : IReportTableItem
    {
        public IOrderedEnumerable<PropertyInfo> ItemInfo { get; private set; }
        public IList<T> Items { get; private set; }

        //     public 

        public ReportTable(IList<T> items = null)
        {
            Items = items ?? new List<T>();
            ItemInfo = OutputOrderAttribute.GetOrderedProperties(typeof(T));
        }

        public string[] GetColumnArray()
        {
            return ItemInfo.Select(_ => _.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName).ToArray();
        }

        public static IReportTable<T> GetReport(IList<T> items)
        {
            IReportTable<T> report = new ReportTable<T>(items);
            return report;
        }
    }

    public class TableWithHeaderFooter
    {
        private string[] header;  // array of header row cells
        private string[][] rows;  // 2D array of table cells
        private string[] footer;  // array of footer row cells
        private int[] columnWidths;  // array of column widths
        private int total;  // the total value of a specific column

        public TableWithHeaderFooter(string[] header, string[][] rows, string[] footer, int[] columnWidths, int total)
        {
            this.header = header;
            this.rows = rows;
            this.footer = footer;
            this.columnWidths = columnWidths;
            this.total = total;
        }

        public void PrintTable()
        {
            int numColumns = header.Length;

            // Print header
            Console.WriteLine("+" + new string('-', columnWidths.Sum(x => x + 3) - 1) + "+");
            Console.Write("|");
            for (int i = 0; i < numColumns; i++)
            {
                Console.Write(" {0,-" + (columnWidths[i] + 1) + "} |", header[i]);
            }
            Console.WriteLine();

            // Print rows
            for (int i = 0; i < rows.Length; i++)
            {
                Console.WriteLine("+" + new string('-', columnWidths.Sum(x => x + 3) - 1) + "+");
                Console.Write("|");
                for (int j = 0; j < numColumns; j++)
                {
                    Console.Write(" {0,-" + (columnWidths[j] + 1) + "} |", rows[i][j]);
                }
                Console.WriteLine();
            }

            // Print footer
            Console.WriteLine("+" + new string('-', columnWidths.Sum(x => x + 3) - 1) + "+");
            Console.Write("|");
            for (int i = 0; i < numColumns; i++)
            {
                Console.Write(" {0,-" + (columnWidths[i] + 1) + "} |", footer[i]);
            }
            Console.WriteLine();

            // Print total
            Console.WriteLine("+" + new string('-', columnWidths.Sum(x => x + 3) - 1) + "+");
            Console.Write("|");
            for (int i = 0; i < numColumns; i++)
            {
                if (i == total)
                {
                    Console.Write(" {0,-" + (columnWidths[i] + 1) + "} |", "Total");
                }
                else
                {
                    Console.Write(" {0,-" + (columnWidths[i] + 1) + "} |", "");
                }
            }
            Console.WriteLine();
        }
    }



}


