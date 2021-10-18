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

using System.Text.RegularExpressions; //for validation 
using YarlHospitalWPF.YarlHospital_Ref;

namespace YarlHospitalWPF
{
    public partial class Appointment : Window
    {
        private string userlevel;
        Service1Client ap = new Service1Client();
        public Appointment(string lvl)
        {
            Loaded += Appointment_Loaded;
            InitializeComponent();
            userlevel = lvl;
        }

        private void Appointment_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dataGridappointment.ItemsSource = ap.Get_Appointment_List();
            }
            catch(Exception ex)
            {

            }
        }

        private void BtnAddAppointment1_Click(object sender, RoutedEventArgs e)
        {

            string aid = txtAID.Text;
            DateTime today = DateTime.Today;
            try
            {
                if ((txtAID.Text == "") | (txtDID.Text == "") | (txtPID.Text == "") || (txtPName.Text == "") | (txtContactNumber.Text == "") | (txtAppointmentDate.Text == "") | (txttime.Text == ""))
                {
                    MessageBox.Show("Please fill all fields to add", "Fields Required", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (!Regex.IsMatch(txtPName.Text, @"^[a-zA-Z]+$"))
                {
                    MessageBox.Show("Please enter a valid patient name", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (!Regex.IsMatch(txtContactNumber.Text, @"^[0-9]{10}$"))
                {
                    MessageBox.Show("Please enter a valid contact number", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                else if (Convert.ToDateTime(txtAppointmentDate.Text) < today)
                {
                    MessageBox.Show("Please select a valid Appointment date", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    ap.Add_Appointment(txtAID.Text,txtDID.Text,txtPID.Text, txtPName.Text, int.Parse(txtContactNumber.Text), txtAppointmentDate.Text, txttime.Text);
                    MessageBox.Show("Information Successfully Added ", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    txtAID.Text = "";
                    txtDID.Text = "";
                    txtPID.Text = "";
                    txtPName.Text = "";
                    txtContactNumber.Text = "";
                    txtAppointmentDate.Text = "";
                    txttime.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Information couldn't be added ", "Fail", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }

        private void BtnUpdateAppointment1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ap.Update_Appoinment(txtAID.Text, txtDID.Text,txtPID.Text, txtPName.Text, int.Parse(txtContactNumber.Text), txtAppointmentDate.Text, txttime.Text);


                MessageBox.Show("Information Successfully Updated ", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void Btnback1_Click(object sender, RoutedEventArgs e)
        {
            MainMenu main = new MainMenu(userlevel);
            main.Show();
            this.Close();

        }

        private void Btnback2_Click(object sender, RoutedEventArgs e)
        {
            MainMenu main = new MainMenu(userlevel);
            main.Show();
            this.Close();
        }

        private void TxtAppointmentID1_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            try
            {
                dataGridappointment.ItemsSource = ap.search_by_AppointmentID(txtAppointmentID.Text);
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnViewAppointment1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddAppointment_Click(object sender, RoutedEventArgs e)
        {
            txtAID.Text = ap.get_max_appointment_id();
        }

        private void BtnViewAppointment_Click(object sender, RoutedEventArgs e)
        {
              try
            {
                var res = ap.view_appointment(txtAID.Text);
                if (txtAID.Text == "")
                {


                    MessageBox.Show("Please enter a valid Appointment ID", "Fill fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                }
                else
                {
                    txtAID.Text = res.Appointment_ID.ToString();
                    txtDID.Text = res.Doctor_ID.ToString();
                    txtPID.Text = res.Patient_ID.ToString();
                    txtPName.Text = res.Full_Name.ToString();
                    txtContactNumber.Text = res.Telephone.ToString();
                    txtAppointmentDate.Text = res.Date.ToString();
                    txttime.Text = res.Time.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter an existing Appointment ID to view", "Inocorrect Appointment ID", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        // private void BtnClear_Click(object sender, RoutedEventArgs e)
        // {
        //     txtAID.Text = "";
        //     txtDID.Text = "";
        //     txtPID.Text = "";
        //     txtPName.Text = "";
        //     txtContactNumber.Text = "";
        //     txtAppointmentDate.Text = "";
        //     txttime.Text = "";
        // }

        private void DataGridappointment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
