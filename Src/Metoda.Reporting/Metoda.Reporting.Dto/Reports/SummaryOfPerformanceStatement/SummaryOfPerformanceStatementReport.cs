using Metoda.Reporting.Lib.Base;
using System;
using System.Collections.Generic;

namespace Metoda.Reporting.Models
{
    public class SummaryOfPerformanceStatementReport : TabledReport<SummaryOfPerformanceStatementItem, SummaryOfPerformanceStatementReportTable>
    {
        public SummaryOfPerformanceStatementReport(string title, string companyName, DateTime refDate, IList<SummaryOfPerformanceStatementReportTable> tableList)
            : base(title, companyName, refDate, tableList, "Totale Prospetto")
        {
        }

        public static IList<SummaryOfPerformanceStatementReportTable> GetFakeTable()
        {
            var list = new List<SummaryOfPerformanceStatementReportTable>();

            SummaryOfPerformanceStatementReportTable res;
            var totals = new[] {
                "Totale Crediti per Cassa",
                "Totale Crediti di Firma",
                "Totale Garanzie Ricevute",
                "Totale Derivati Finanziari",
                "Totale Sezione Informativa"
            };

            Random random = new Random();

            string[][] cubies = new[]{
                new []{
                    "550200 - Rischi Autoliquidanti",
                    "550400 - Rischi a Scadenza",
                    "550600 - Rischi a Revoca",
                    "550800 - Finanziamenti a Procedura Concorsuale e altri Finanziamenti Particolari",
                    "551000 - Sofferenze"
                },
                new []{
                    "552200 - Garanzie Connesse con Operazioni di Natura Commerciale",
                    "552400 - Garanzie Connesse con Operazioni di Natura Finanziaria"
                },
                new []{
                    "553200 - Garanzie Ricevute"
                },
                new []{
                    "553300 - Derivati Finanziari"
                },
                new []{
                    "554800 - Operazioni effettuate per conto di terzi",
                    "554900 - Crediti per cassa: operazioni in “pool” -azienda capofila",
                    "554901 - Crediti per cassa: operazioni in “pool” -altra azienda partecipante",
                    "554902 - Crediti per cassa: operazioni in “pool” – totale",
                    "554800 - Operazioni effettuate per conto di terzi",
                    "555100 - Crediti acquisiti(originariamente) da clientela diversa da intermediari - debitori ceduti",
                    "555150 - Rischi autoliquidanti - crediti scaduti",
                    "555200 - Sofferenze - crediti passati a perdita",
                    "555400 - Sofferenze - crediti ceduti a terzi"
                }
            };

            for (int k = 0; k < totals.Length; k++)
            {
                res = new SummaryOfPerformanceStatementReportTable();

                res.TotalLabel = totals[k];
                foreach (var c in cubies[k])
                    res.Items.Add(new SummaryOfPerformanceStatementItem
                    {
                        Cubi = c,
                        NumSegnMese = random.Next(1,18),
                        TotaleMese = random.Next(1000,10000),
                        NumSegnMesePrec = random.Next(1, 18),
                        TotaleMesePrec = random.Next(1000, 10000),
                    });;
                list.Add(res);
            }
            return list;
        }
    }
}
