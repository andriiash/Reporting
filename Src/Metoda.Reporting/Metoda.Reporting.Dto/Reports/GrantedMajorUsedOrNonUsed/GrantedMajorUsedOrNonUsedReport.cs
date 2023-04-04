using Metoda.Reporting.Lib.Base;
using System;
using System.Collections.Generic;

namespace Metoda.Reporting.Models
{
    public class GrantedMajorUsedOrNonUsedReport : TabledReport<GrantedMajorUsedOrNonUsedItem>
    {
        public GrantedMajorUsedOrNonUsedReport(string title, string companyName, DateTime refDate, IList<ReportTable<GrantedMajorUsedOrNonUsedItem>> tableList)
            : base(title, companyName, refDate, tableList)
        {
        }

        public static IList<ReportTable<GrantedMajorUsedOrNonUsedItem>> GetFakeTable()
        {
            var list = new List<ReportTable<GrantedMajorUsedOrNonUsedItem>>();

            ReportTable<GrantedMajorUsedOrNonUsedItem> res;
            var centsitos = new[] { "12345 - Soggetto A", "45687 - Soggetto A", "77295 - Soggetto B" };

            Random random = new Random();
            decimal accordato, utilizzato;

            res = new ReportTable<GrantedMajorUsedOrNonUsedItem>();

            for (int k = 0; k < centsitos.Length; k++)
            {
                accordato = random.Next(4000, 10000);
                utilizzato = random.Next(1000, 4000);
                res.Items.Add(new GrantedMajorUsedOrNonUsedItem
                {
                    Accordato = accordato,
                    CodCensito = centsitos[k],
                    Cubo = "550200 - Crediti per cassa - Rischi Autoliquidanti",
                    Utilizzato = utilizzato,
                    Sbilancio = accordato - utilizzato
                });
            }

            list.Add(res);
            return list;
        }
    }
}
