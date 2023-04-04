using Metoda.Reporting.Lib.Base;
using System;
using System.Collections.Generic;

namespace Metoda.Reporting.Models
{
    public class PresenceOfLeadPoolAndNotTotalPoolOrViceVersaReport
        : TabledReport<PresenceOfLeadPoolAndNotTotalPoolOrViceVersaItem,
            PresenceOfLeadPoolAndNotTotalPoolOrViceVersaReportTable>
    {
        public PresenceOfLeadPoolAndNotTotalPoolOrViceVersaReport(string title, string companyName, DateTime refDate, IList<PresenceOfLeadPoolAndNotTotalPoolOrViceVersaReportTable> tableList)
            : base(title, companyName, refDate, tableList)
        {
        }

        public static IList<PresenceOfLeadPoolAndNotTotalPoolOrViceVersaReportTable> GetFakeTable()
        {
            var list = new List<PresenceOfLeadPoolAndNotTotalPoolOrViceVersaReportTable>();

            PresenceOfLeadPoolAndNotTotalPoolOrViceVersaReportTable res;
            var centsitos = new[] { "12345 - Soggetto A", "45687 - Soggetto A", "77295 - Soggetto B" };

            Random random = new Random();
            decimal capAccordato, capUtilizzato, totAccordato, totUtilizzato;

            res = new PresenceOfLeadPoolAndNotTotalPoolOrViceVersaReportTable();
            for (int k = 0; k < centsitos.Length; k++)
            {
                for (int i = 0; i < 7; i++)
                {
                    capAccordato = random.Next(4000, 10000);
                    capUtilizzato = random.Next(1000, 4000);
                    totAccordato = capAccordato - random.Next(300, 500);
                    totUtilizzato = capUtilizzato - random.Next(100, 400);

                    res.Items.Add(new PresenceOfLeadPoolAndNotTotalPoolOrViceVersaItem
                    {
                        CodCensito = centsitos[k],
                        Cubo = $"{random.Next(554900, 554902)} - Sezione informativa – crediti per cassa: operazioni in \"pool\"",
                        CapofilaUtilizzato = capAccordato,
                        CapofilaAccordato = capUtilizzato,
                        TotUtilizzato = totAccordato,
                        TotAccordato = totUtilizzato
                    });
                }

            }
            list.Add(res);
            return list;
        }
    }
}
