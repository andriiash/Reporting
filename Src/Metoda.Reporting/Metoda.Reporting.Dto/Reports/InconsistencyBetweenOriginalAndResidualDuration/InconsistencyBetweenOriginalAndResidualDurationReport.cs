using Metoda.Reporting.Lib.Base;
using System;
using System.Collections.Generic;

namespace Metoda.Reporting.Models
{
    public class InconsistencyBetweenOriginalAndResidualDurationReport
        : TabledReport<InconsistencyBetweenOriginalAndResidualDurationItem,
            InconsistencyBetweenOriginalAndResidualDurationReportTable>
    {
        public InconsistencyBetweenOriginalAndResidualDurationReport(string title, string companyName, DateTime refDate, IList<InconsistencyBetweenOriginalAndResidualDurationReportTable> tableList)
            : base(title, companyName, refDate, tableList)
        {
        }

        public static IList<InconsistencyBetweenOriginalAndResidualDurationReportTable> GetFakeTable()
        {
            var list = new List<InconsistencyBetweenOriginalAndResidualDurationReportTable>();

            InconsistencyBetweenOriginalAndResidualDurationReportTable res;
            var centsitos = new[] { "12345 - Soggetto A", "45687 - Soggetto A", "77295 - Soggetto B" };

            Random random = new Random();
            decimal accordato, utilizzato;

            res = new InconsistencyBetweenOriginalAndResidualDurationReportTable();
            for (int k = 0; k < centsitos.Length; k++)
            {

                for (int i = 0; i < 2; i++)
                {
                    accordato = random.Next(4000, 10000);
                    utilizzato = random.Next(1000, 4000);
                    res.Items.Add(new InconsistencyBetweenOriginalAndResidualDurationItem
                    {
                        Accordato = accordato,
                        CodCensito = centsitos[k],
                        Cubo = $"{random.Next(555100, 555202)} - Sezione Informativa",
                        DurataOriginaria = "18 – Oltre 1 anno",
                        DurataResidua = "5 – fino ad un anno",
                        Utilizzato = utilizzato,
                        Sbilancio = accordato - utilizzato
                    });
                }

            }
            
            list.Add(res);
            return list;
        }
    }
}
