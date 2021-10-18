using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using YarlHospitalWPF.YarlHospital_Ref;


namespace YarlHospitalWPF
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        Service1Client rep_ref = new Service1Client();
        private string userlevel;
        public Report(string lvl)
        {
            InitializeComponent();

            userlevel = lvl;
        }

        private void Btnback_Click(object sender, RoutedEventArgs e)
        {
            MainMenu main = new MainMenu();
            main.Show();
            this.Close();
        }

        private void BtnPaymentReport_Click(object sender, RoutedEventArgs e)
        {
            PaymentReportViewer payreport = new PaymentReportViewer();
            payreport.ShowDialog();
            
        }

        private void BtnLogout1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDrugReport_Click(object sender, RoutedEventArgs e)
        {
            DrugReportViewer drugview = new DrugReportViewer();
            drugview.ShowDialog();
        }

        private void BtnAppointmentReport_Click(object sender, RoutedEventArgs e)
        {
            AppointmentReportViewer appointmentReport = new AppointmentReportViewer();
            appointmentReport.ShowDialog();
        }

        private void BtnPatienreport_Click(object sender, RoutedEventArgs e)
        {
            PatientReportViewer patient = new PatientReportViewer();
            patient.ShowDialog();
        }
    }
}
