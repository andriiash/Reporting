using Metoda.Reporting.Lib.Base;
using System;
using System.Collections.Generic;

namespace Metoda.Reporting.Models
{
    public class AgreedOtherThanUsedForPooledTransactionsReport : TabledReport<AgreedOtherThanUsedForPooledTransactionsItem>
    {
        public AgreedOtherThanUsedForPooledTransactionsReport(string title, string companyName, DateTime refDate, IList<ReportTable<AgreedOtherThanUsedForPooledTransactionsItem>> tableList)
            : base(title, companyName, refDate, tableList)
        {
        }

        public static IList<ReportTable<AgreedOtherThanUsedForPooledTransactionsItem>> GetFakeTable()
        {
            var list = new List<ReportTable<AgreedOtherThanUsedForPooledTransactionsItem>>();

            ReportTable<AgreedOtherThanUsedForPooledTransactionsItem> res;
            var centsitos = new[] { "12345 - Soggetto A", "45687 - Soggetto A", "77295 - Soggetto B" };

            Random random = new Random();
            decimal accordato, utilizzato;

            for (int k = 0; k < centsitos.Length; k++)
            {
                res = new ReportTable<AgreedOtherThanUsedForPooledTransactionsItem>();
                for (int i = 0; i < 20; i++)
                {
                    accordato = random.Next(4000, 10000);
                    utilizzato = random.Next(1000, 4000);
                    res.Items.Add(new AgreedOtherThanUsedForPooledTransactionsItem
                    {
                        Accordato = accordato,
                        CodCensito = centsitos[k],
                        Cubo = $"{random.Next(554900, 554902)} - Sezione Informativa – Crediti per Cassa: Operazioni in pool – Azienda capofila",
                        Utilizzato = utilizzato,
                        Sbilancio = accordato - utilizzato
                    });
                }
                list.Add(res);
            }

            return list;
        }
    }
}
