﻿using Metoda.Reporting.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Metoda.Reporting.TestGen
{
    public partial class frmMainReports : Form
    {

        string dataFolder = Path.Combine(AppContext.BaseDirectory, "data");
        public frmMainReports()
        {
            InitializeComponent();

            if (!Directory.Exists(dataFolder))
                Directory.CreateDirectory(dataFolder);
        }

        private void btnAgreedOtherThanUsedForPooledTransactions_Click(object sender, EventArgs e)
        {
            try
            {
                string dest = $"{dataFolder}/ACCORDATO_DIVERSO_DA_UTILIZZATO_PER_OPERAZIONI_IN_POOL_{DateTime.Now.Ticks}.pdf";
                var report = new AgreedOtherThanUsedForPooledTransactionsReport(
                 title: "ACCORDATO DIVERSO DA UTILIZZATO PER OPERAZIONI IN POOL",
                 companyName: "09999 - Banca di Prova",
                 refDate: new DateTime(2018, 09, 30),
                 tableList: AgreedOtherThanUsedForPooledTransactionsReport.GetFakeTable());

                report.ToPdf(dest);
                MessageBox.Show("Pdf generation has been completed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrantedMajorUsedOrNonUsed_Click(object sender, EventArgs e)
        {
            try
            {
                string dest = $"{dataFolder}/ACCORDATO_MAGGIORE_DI_UTILIZZATO_O_SENZA_UTILIZZATO_{DateTime.Now.Ticks}.pdf";
                var report = new GrantedMajorUsedOrNonUsedReport(
                 title: "ACCORDATO MAGGIORE DI UTILIZZATO O SENZA UTILIZZATO",
                 companyName: "09999 - Banca di Prova",
                 refDate: new DateTime(2018, 09, 30),
                 tableList: GrantedMajorUsedOrNonUsedReport.GetFakeTable());

                report.ToPdf(dest);
                MessageBox.Show("Pdf generation has been completed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOtherCreditsButImpaired_Click(object sender, EventArgs e)
        {
            try
            {
                string dest = $"{dataFolder}/ALTRI_CREDITI_MA_DETERIORATI_{DateTime.Now.Ticks}.pdf";
                var report = new OtherCreditsButImpairedReport(
                 title: "ALTRI CREDITI MA DETERIORATI",
                 companyName: "09999 - Banca di Prova",
                 refDate: new DateTime(2018, 09, 30),
                 tableList: OtherCreditsButImpairedReport.GetFakeTable());

                report.ToPdf(dest);
                MessageBox.Show("Pdf generation has been completed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAbsenceRegisteredConnected_Click(object sender, EventArgs e)
        {
            try
            {
                string dest = $"{dataFolder}/ASSENZA_CENSITO_COLLEGATO_{DateTime.Now.Ticks}.pdf";
                var report = new AbsenceRegisteredConnectedReport(
                 title: "ASSENZA CENSITO COLLEGATO",
                 companyName: "09999 - Banca di Prova",
                 refDate: new DateTime(2018, 09, 30),
                 tableList: AbsenceRegisteredConnectedReport.GetFakeTable());

                report.ToPdf(dest);
                MessageBox.Show("Pdf generation has been completed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuaranteesConnectedWithOperationsOfACommercialNature_Click(object sender, EventArgs e)
        {
            try
            {
                string dest = $"{dataFolder}/GARANZIE_CONNESSE_CON_OPERAZIONI_DI_NATURA_COMMERCIALE_{DateTime.Now.Ticks}.pdf";
                var report = new GuaranteesConnectedWithOperationsOfACommercialNatureReport(
                 title: "GARANZIE CONNESSE CON OPERAZIONI DI NATURA COMMERCIALE",
                 companyName: "09999 - Banca di Prova",
                 refDate: new DateTime(2018, 09, 30),
                 tableList: GuaranteesConnectedWithOperationsOfACommercialNatureReport.GetFakeTable());

                report.ToPdf(dest);
                MessageBox.Show("Pdf generation has been completed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInconsistencyBetweenOriginalAndResidualDuration_Click(object sender, EventArgs e)
        {
            try
            {
                string dest = $"{dataFolder}/INCONGRUENZA_TRA_DURATA_ORIGINARIA_E_RESIDUA_{DateTime.Now.Ticks}.pdf";
                var report = new InconsistencyBetweenOriginalAndResidualDurationReport(
                 title: "INCONGRUENZA TRA DURATA ORIGINARIA E RESIDUA",
                 companyName: "09999 - Banca di Prova",
                 refDate: new DateTime(2018, 09, 30),
                 tableList: InconsistencyBetweenOriginalAndResidualDurationReport.GetFakeTable());

                report.ToPdf(dest);
                MessageBox.Show("Pdf generation has been completed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPresenceOfLeadPoolAndNotTotalPoolOrViceVersa_Click(object sender, EventArgs e)
        {
            try
            {
                string dest = $"{dataFolder}/PRESENZA_DI_POOL_CAPOFILA_E_NON_POOL_TOTALE_O_VICEVERSA_{DateTime.Now.Ticks}.pdf";
                var report = new PresenceOfLeadPoolAndNotTotalPoolOrViceVersaReport(
                 title: "PRESENZA DI POOL CAPOFILA E NON POOL TOTALE O VICEVERSA",
                 companyName: "09999 - Banca di Prova",
                 refDate: new DateTime(2018, 09, 30),
                 tableList: PresenceOfLeadPoolAndNotTotalPoolOrViceVersaReport.GetFakeTable());

                report.ToPdf(dest);
                MessageBox.Show("Pdf generation has been completed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSummaryOfPerformanceStatement_Click(object sender, EventArgs e)
        {
            try
            {
                string dest = $"{dataFolder}/RIEPILOGO_PROSPETTO_ANDAMENTALE_{DateTime.Now.Ticks}.pdf";
                var report = new SummaryOfPerformanceStatementReport(
                 title: "RIEPILOGO PROSPETTO ANDAMENTALE",
                 companyName: "09999 - Banca di Prova",
                 refDate: new DateTime(2018, 09, 30),
                 tableList: SummaryOfPerformanceStatementReport.GetFakeTable());

                report.ToPdf(dest);
                MessageBox.Show("Pdf generation has been completed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTypeOfActivityIncompatibleWithRisksAtMaturity_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry, It's not implemented yet", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMonthlyReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry, It's not implemented yet", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSufferingsReportedWithOtherPhenomena_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry, It's not implemented yet", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReportingUnlikelyToPayBySubject_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry, It's not implemented yet", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOperationalOverruns_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry, It's not implemented yet", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTrespassing_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry, It's not implemented yet", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       

        private void btnOpenDestFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", dataFolder);
        }

        private void lblQuest2_Click(object sender, EventArgs e)
        {

        }
    }

}
