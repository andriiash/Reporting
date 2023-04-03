using Metoda.Reporting.Lib.Base;
using Metoda.Reporting.Models.AbsenceRegisteredConnected;
using System;
using System.Windows.Forms;

namespace Metoda.Reporting.TestGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReport1_Click(object sender, EventArgs e)
        {
            try
            {
                string dest = $"G:/pdf_temp/AbsenceRegisteredConnectedReport_{DateTime.Now.Ticks}.pdf";
                var report = new AbsenceRegisteredConnectedReport(GetTable());
                report.ToPdf(dest);
                MessageBox.Show("Pdf generation has been completed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ReportTable<AbsenceRegisteredConnectedItem> GetTable()
        {
            var res = new ReportTable<AbsenceRegisteredConnectedItem>(hasTotal: true);

            Random random = new Random();
            decimal accordato, utilizzato;

            for (int i = 0; i < 20; i++)
            {
                accordato = random.Next(4000, 10000);
                utilizzato = random.Next(1000, 4000);
                res.Items.Add(new AbsenceRegisteredConnectedItem
                {
                    Accordato = accordato,
                    CodCensito = $"{accordato} - Soggetto A",
                    Cubo = $"{random.Next(1000, 10000)} - Soggetto A",
                    Utilizzato = utilizzato,
                    Delta = (accordato - utilizzato)
                });
            }

            return res;
        }
    }
}
