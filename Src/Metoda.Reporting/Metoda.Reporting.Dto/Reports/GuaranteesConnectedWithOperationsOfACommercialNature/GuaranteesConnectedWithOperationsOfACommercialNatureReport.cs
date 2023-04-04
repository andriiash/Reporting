using Metoda.Reporting.Lib.Base;
using System;
using System.Collections.Generic;

namespace Metoda.Reporting.Models
{
    public class GuaranteesConnectedWithOperationsOfACommercialNatureReport : TabledReport<GuaranteesConnectedWithOperationsOfACommercialNatureItem, GuaranteesConnectedWithOperationsOfACommercialNatureReportTable>
    {
        public GuaranteesConnectedWithOperationsOfACommercialNatureReport(string title, string companyName, DateTime refDate, IList<GuaranteesConnectedWithOperationsOfACommercialNatureReportTable> tableList)
            : base(title, companyName, refDate, tableList)
        {
        }

        public static IList<GuaranteesConnectedWithOperationsOfACommercialNatureReportTable> GetFakeTable()
        {
            var list = new List<GuaranteesConnectedWithOperationsOfACommercialNatureReportTable>();

            GuaranteesConnectedWithOperationsOfACommercialNatureReportTable res;
            
            var centsito = "12345 - Soggetto A";
            Random random = new Random();
            decimal utilizzato;

            res = new GuaranteesConnectedWithOperationsOfACommercialNatureReportTable();

            for (int k = 0; k < 10; k++)
            {
                utilizzato = random.Next(1000, 4000);
                res.Items.Add(new GuaranteesConnectedWithOperationsOfACommercialNatureItem
                {
                    Utilizzato = utilizzato,
                    CodCensito = centsito,
                    Localizzazione = "00155 - <descrizione>",
                    ImportOrExport = "1 - <descrizione>",
                    Divisa = "1 - Euro",
                    StatoRapporto = "134 - <descrizione>"
                });
            }

            list.Add(res);
            return list;
        }
    }
}
