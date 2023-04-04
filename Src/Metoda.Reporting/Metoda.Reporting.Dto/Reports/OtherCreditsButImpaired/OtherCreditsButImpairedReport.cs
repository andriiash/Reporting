using Metoda.Reporting.Lib.Base;
using System;
using System.Collections.Generic;

namespace Metoda.Reporting.Models
{
    public class OtherCreditsButImpairedReport : TabledReport<OtherCreditsButImpairedItem>
    {
        public OtherCreditsButImpairedReport(string title, string companyName, DateTime refDate, IList<ReportTable<OtherCreditsButImpairedItem>> tableList)
            : base(title, companyName, refDate, tableList)
        {

        }

        public static IList<ReportTable<OtherCreditsButImpairedItem>> GetFakeTable()
        {
            var list = new List<ReportTable<OtherCreditsButImpairedItem>>();

            ReportTable<OtherCreditsButImpairedItem> res;
            var centsitos = new[] { "12345 - Soggetto A", "45687 - Soggetto A", "77295 - Soggetto B" };

            Random random = new Random();
            decimal utilizzato;

            res = new ReportTable<OtherCreditsButImpairedItem>();

            for (int i = 0; i < 5; i++)
                for (int k = 0; k < centsitos.Length; k++)
                {
                    utilizzato = random.Next(1000, 4000);
                    res.Items.Add(new OtherCreditsButImpairedItem
                    {
                        CodCensito = centsitos[k],
                        Cubo = "550200 - Crediti per cassa - Rischi Autoliquidanti",
                        StatoRapporto = "138 - Altri Crediti",
                        QualitaCredito = "1 - Deteriorato",
                        Utilizzato = utilizzato
                    });
                }

            list.Add(res);
            return list;
        }
    }
}
