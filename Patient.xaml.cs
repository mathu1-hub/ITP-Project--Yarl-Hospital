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

using System.Text.RegularExpressions;
using YarlHospitalWPF.YarlHospital_Ref;

namespace YarlHospitalWPF
{
    /// <summary>
    /// Interaction logic for Patient.xaml
    /// </summary>
    public partial class Patient : Window
    {
        private string userlevel;
        Service1Client pa = new Service1Client();

        public Patient(string lvl)
        {
            InitializeComponent();
            Loaded += Patient_Loaded;
            userlevel = lvl;
        }

        private void Patient_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dataGridpatient.ItemsSource = pa.get_patients();
            }
            catch (Exception ex)
            { }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {

            MainMenu mainmenu = new MainMenu(userlevel);
            mainmenu.Show();
            this.Close();
        }

        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            string pid = txtPID.Text;
            DateTime today = DateTime.Today;

            try
            {

                if ((txtPID.Text == "") | (txtFName.Text == "") | (cmbgender.Text == "") | (txtDOB.Text == "") | (txtAddress.Text == "") | (txtCountry.Text == "") | (txtTelephone.Text == "") | (txtMobile.Text == "") | (txtNICP.Text == "") | (txtemail.Text == ""))
                {
                    MessageBox.Show("Please fill all fields to add", "Fields Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (!Regex.IsMatch(txtFName.Text, @"^[a-zA-Z]+$"))
                {
                    MessageBox.Show("Please enter a valid patient name", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (Convert.ToDateTime(txtDOB.Text) > today)
                {
                    MessageBox.Show("Please select a valid date of birth", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (!Regex.IsMatch(txtemail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    MessageBox.Show("Please enter a valid email address", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (!(IsAllDigits(txtMobile.Text)))
                {
                    MessageBox.Show("Please enter a valid Mobile number", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
                else if (!(IsAllDigits(txtTelephone.Text)))
                {
                    MessageBox.Show("Please enter a valid Telephone number", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
                else if (!Regex.IsMatch(txtNICP.Text, @"^[0-9]{9}V$"))
                {
                    MessageBox.Show("Please enter a valid NIC Number", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    pa.Add_Patient(txtPID.Text, txtFName.Text, txtAddress.Text, txtNICP.Text, cmbgender.Text, txtDOB.Text, txtCountry.Text, int.Parse(txtTelephone.Text), int.Parse(txtMobile.Text), txtemail.Text);
                    MessageBox.Show("Information Successfully Added ", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    txtPID.Text = "";
                    txtFName.Text = "";
                    cmbgender.Text = "";
                    txtDOB.Text = "";
                    txtAddress.Text = "";
                    txtCountry.Text = "";
                    txtTelephone.Text = "";
                    txtMobile.Text = "";
                    txtNICP.Text = "";
                    txtemail.Text = "";
                }
            }
            catch (Exception ex)
            {

            }
        }

        bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        //private void BtnAddPatient_Click(object sender, RoutedEventArgs e)
        //{
        //    txtPID.Text = pa.get_auto_patient_id();
        //}

        private void UpdatePatient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pa.update_patient(txtPID.Text, txtFName.Text, txtAddress.Text, txtNICP.Text, cmbgender.Text, txtDOB.Text, txtCountry.Text, int.Parse(txtTelephone.Text), int.Parse(txtMobile.Text), txtemail.Text);

                MessageBox.Show("Information Successfully Updated ", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void BtnViewPatient_Click(object sender, RoutedEventArgs e)
        {


        }

        private void BtnViewPatient_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var res = pa.view_patient(txtPID.Text);
                if (txtPID.Text == "")
                {
                    MessageBox.Show("Please enter a valid Patient ID", "Fill fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    txtPID.Text = res.Patient_ID.ToString();
                    txtFName.Text = res.Full_Name.ToString();
                    txtAddress.Text = res.Address.ToString();
                    txtNICP.Text = res.NIC.ToString();
                    cmbgender.Text = res.Gender.ToString();
                    txtDOB.Text = res.DOB.ToString();
                    txtCountry.Text = res.Country.ToString();
                    txtTelephone.Text = res.Telephone.ToString();
                    txtMobile.Text = res.Mobile.ToString();
                    txtemail.Text = res.Email.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter an exisiting Patient ID to view", "Fill fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }

        private void Btnback1_Click(object sender, RoutedEventArgs e)
        {
            MainMenu main = new MainMenu(userlevel);
            main.Show();
            this.Close();
        }

        private void TxtPatientID_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                dataGridpatient.ItemsSource = pa.search(txtPatientID.Text);
            }
            catch (Exception ex)
            {

            }
        }

        private void TxtPatientName_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataGridpatient.ItemsSource = pa.search_patient_name(txtPatientName.Text);
        }

        private void ClearPatient_Click(object sender, RoutedEventArgs e)
        {
            txtFName.Text = "";
            cmbgender.Text = "";
            txtDOB.Text = "";
            txtAddress.Text = "";
            txtCountry.Text = "";
            txtTelephone.Text = "";
            txtMobile.Text = "";
            txtNICP.Text = "";
            txtemail.Text = "";
        }

        private void TxtNIC_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataGridpatient.ItemsSource = pa.search_nic(txtNIC.Text);
        }

        private void BtnAddPatient_Click(object sender, RoutedEventArgs e)
        {
            txtPID.Text = pa.get_max_patient_id();
        }
    }
}
