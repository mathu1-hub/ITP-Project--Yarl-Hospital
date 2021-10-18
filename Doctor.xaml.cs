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

using YarlHospitalWPF.YarlHospital_Ref;
using System.Text.RegularExpressions;

namespace YarlHospitalWPF
{
    public partial class Doctor : Window
    {
        private string userlevel;
        Service1Client doc_ser_cli = new Service1Client();

        public Doctor(string lvl)
        {
            InitializeComponent();
            Loaded += Doctor_Loaded;
            userlevel = lvl;
        }

        private void Doctor_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dataGriddoctor.ItemsSource = doc_ser_cli.get_doctor_list();

            }
            catch(Exception ex)
            {

            }
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainmenu = new MainMenu(userlevel);//////////
            mainmenu.Show();
            this.Close();
        }

        private void btnback_Click_1(object sender, RoutedEventArgs e)
        {
            MainMenu mainmenu = new MainMenu(userlevel);
            mainmenu.Show();
            this.Close();            
        }

        private void btnback1_Click(object sender, RoutedEventArgs e)
        {
            MainMenu main = new MainMenu(userlevel);
            main.Show();
            this.Close();
        }

        private void BtnAddDoctor_Click(object sender, RoutedEventArgs e)
        {
            txtDID.Text =  doc_ser_cli.get_max_doctor_id();
        }

        private void AddDoctor_Click(object sender, RoutedEventArgs e)
        {
            string docId = txtDID.Text;
            DateTime today = DateTime.Today;
            try
            {
                if ((txtDID.Text == "") || (txtName.Text == "") || (txtSpecialist.Text == "") || (cmbgender.Text == "") || (txtDOB.Text == "") || (txtAddress.Text == "") || (txtCountry.Text == "") || (txtMobile.Text == "") || (txtNICD.Text == "") || (txtemail.Text == ""))
                {
                    MessageBox.Show("Please fill all fields to add", "Fields Required", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (!Regex.IsMatch(txtName.Text, @"^[a-zA-z]+$"))
                   
                {
                    MessageBox.Show("Please enter a valid patient name", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (Convert.ToDateTime(txtDOB.Text) > today)
                {
                    MessageBox.Show("Please select a valid date of birth", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if(cmbgender.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Gender", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
               else if(!(IsAllDigits(txtMobile.Text)))
                {
                    MessageBox.Show("Please enter a valid Mobile number", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
                else if (!Regex.IsMatch(txtNICD.Text, @"^[0-9]{9}V$"))
                {
                    MessageBox.Show("Please enter a valid NIC Number", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (!Regex.IsMatch(txtemail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    MessageBox.Show("Please enter a valid email address", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                else
                {
                    doc_ser_cli.add_Doctor(txtDID.Text, txtName.Text, txtSpecialist.Text, cmbgender.Text, txtDOB.Text, txtAddress.Text, txtCountry.Text, int.Parse(txtMobile.Text), txtNICD.Text, txtemail.Text);
                    MessageBox.Show("Information Successfully Added ", "Success", MessageBoxButton.OK, MessageBoxImage.Information);


                    txtDoctorID.Text = "";
                    txtName.Text = "";
                    txtSpecialist.Text = "";
                    cmbgender.Text = "";
                    txtDOB.Text = "";
                    txtAddress.Text = "";
                    txtCountry.Text = "";
                    txtMobile.Text = "";
                    txtNICD.Text = "";
                    txtemail.Text = "";

                }
            }
            catch(Exception ex)
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


        
        private void TxtDoctorID_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataGriddoctor.ItemsSource = doc_ser_cli.search_DoctorId(txtDoctorID.Text);
        }

        private void ClearDoctor_Click(object sender, RoutedEventArgs e)
        {
            txtDoctorID.Text = "";
            txtDoctorName.Text = "";
            txtSpecialist.Text = "";
            cmbgender.Text = "";
            txtDOB.Text = "";
            txtAddress.Text = "";
            txtCountry.Text = "";
            txtMobile.Text = "";
            txtNIC.Text = "";
            txtemail.Text = "";
        }

        private void TxtDoctorName_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataGriddoctor.ItemsSource = doc_ser_cli.search_DoctorName(txtDoctorName.Text);
        }

        private void TxtNIC_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataGriddoctor.ItemsSource = doc_ser_cli.search_DoctorNIC(txtNIC.Text);
        }

        private void BtnViewDoctor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var res = doc_ser_cli.View_Doctor(txtDID.Text);
                if (txtDID.Text == "")
                {
                    MessageBox.Show("Please Enter Doctor Id ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {

                    txtDID.Text = res.Doctor_ID.ToString();
                    txtName.Text = res.Doctor_Name.ToString();
                    txtSpecialist.Text = res.Specialist.ToString();
                    cmbgender.Text = res.Gender.ToString();
                    txtDOB.Text = res.DOB.ToString();
                    txtAddress.Text = res.Address.ToString();
                    txtCountry.Text = res.Country.ToString();
                    txtMobile.Text = res.Mobile.ToString();
                    txtNICD.Text = res.NIC.ToString();
                    txtemail.Text = res.Email.ToString();

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateDoctor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                doc_ser_cli.Update_doctor(txtDoctorID.Text, txtDoctorName.Text, txtSpecialist.Text, cmbgender.Text, txtDOB.Text, txtAddress.Text, txtCountry.Text, int.Parse(txtMobile.Text), txtNIC.Text, txtemail.Text);

                MessageBox.Show("Information Updated Sucessfully", "Sucessfully", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}   
