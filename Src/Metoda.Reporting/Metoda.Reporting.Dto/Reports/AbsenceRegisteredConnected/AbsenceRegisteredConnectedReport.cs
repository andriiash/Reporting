using Metoda.Reporting.Lib.Base;
using System;
using System.Collections.Generic;

namespace Metoda.Reporting.Models
{
    public class AbsenceRegisteredConnectedReport : TabledReport<AbsenceRegisteredConnectedItem, AbsenceRegisteredConnectedReportTable>
    {
        public AbsenceRegisteredConnectedReport(string title, string companyName, DateTime refDate, IList<AbsenceRegisteredConnectedReportTable> tableList)
            : base(title, companyName, refDate, tableList)
        {
        }

        public static IList<AbsenceRegisteredConnectedReportTable> GetFakeTable()
        {
            var list = new List<AbsenceRegisteredConnectedReportTable>();

            AbsenceRegisteredConnectedReportTable res;
            var centsitos = new[] { "12345 - Soggetto A", "45687 - Soggetto A", "77295 - Soggetto B" };
            string op = "icona";
            Random random = new Random();
            decimal valore;

            res = new AbsenceRegisteredConnectedReportTable();

            for (int k = 0; k < centsitos.Length; k++)
            {
                valore = random.Next(1000, 4000);
                res.Items.Add(new AbsenceRegisteredConnectedItem
                {
                    Valore = valore,
                    CodCensito = centsitos[k],
                    Fenomeno = "555100 - Crediti per cassa - Rischi Autoliquidanti",
                    StatoRapporto = "138 - Altri Crediti",
                    Op = $"\"{op}\""
                });
            }

            list.Add(res);
            return list;
        }
    }
}
