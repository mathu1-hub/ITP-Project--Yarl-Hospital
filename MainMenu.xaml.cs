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

namespace YarlHospitalWPF
{
    public partial class MainMenu : Window
    {
        private string username;
        private string userlevel;

        public MainMenu(string lvl)
        {
            InitializeComponent();
            userlevel = lvl;

            if (lvl.Equals("Receptionist"))
            {
                btnTreatment.Visibility = System.Windows.Visibility.Hidden;
                btnDrug.Visibility = System.Windows.Visibility.Hidden;
                btnReport.Visibility = System.Windows.Visibility.Hidden;
            }

        }

        public MainMenu()
        {
            InitializeComponent();
           // Loaded += timeLoaded;

        }

        public MainMenu(string username, string userlevel)
        {

            this.username = username;
            this.userlevel = userlevel;
        }

        private void btnPatient_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = new Patient(userlevel);
            patient.Show();
            this.Close();  
        }

        private void btnAppointment_Click(object sender, RoutedEventArgs e)
        {
            Appointment Appointment = new Appointment(userlevel);
            Appointment.Show();
            this.Close();
        }

        private void btnDrug_Click(object sender, RoutedEventArgs e)
        {
            Drugs drugForm = new Drugs(userlevel);
            drugForm.Show();
            this.Close();
        }

        private void btnTreatment_Click(object sender, RoutedEventArgs e)
        {
            Treatment treatmentForm = new Treatment(userlevel);
            treatmentForm.Show();
            this.Close();
        }

        private void btnDoctor_Click(object sender, RoutedEventArgs e)
        {
            Doctor doctorForm = new Doctor(userlevel);
            doctorForm.Show();
            this.Close();
        }

        private void btnPayment_Click(object sender, RoutedEventArgs e)
        {
            Payment paymentform = new Payment(userlevel);
            paymentform.Show();
            this.Close();
        }

        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            Report report_form = new Report(userlevel);
            report_form.Show();
            this.Close();
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if(MessageBox.Show("Are you sure you want to log out?", "Confirm to Log out", MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Hide();
                LoginWindow login = new LoginWindow();
                login.Show();
            }
            else
            {
                this.Show();

            }

        }

        private void BtnReport_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEmail_Click(object sender, RoutedEventArgs e)
        {
            Send_Email email = new Send_Email();
            email.ShowDialog();
            this.Close();
        }
    }
}
