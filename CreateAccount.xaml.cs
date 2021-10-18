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

namespace YarlHospitalWPF
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        Service1Client cre_acc_ref = new Service1Client();
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if(txtfullname.Text == "" || txtemail.Text == "" || txtusername.Text == "" || txtpassword.Password == "" || txtRpassword.Password == "" || SecurityCombo.SelectedIndex == -1 || txtAnswer.Text == "" || cmbtypelogin.SelectedIndex == -1 )
                {
                    MessageBox.Show("please fill all the fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if(txtpassword.Password!=txtRpassword.Password)
                    {
                        MessageBox.Show("Passwords don't match", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        cre_acc_ref.create_account(txtfullname.Text, txtemail.Text, txtusername.Text, txtpassword.Password, txtpassword.Password, SecurityCombo.Text, txtAnswer.Text, cmbtypelogin.Text);
                        MessageBox.Show("Details Added Sucessfully", "Done", MessageBoxButton.OK, MessageBoxImage.Information);

                        txtfullname.Text = "";
                        txtemail.Text = "";
                        txtusername.Text = "";
                        txtpassword.Password = "";
                        txtRpassword.Password = "";
                        SecurityCombo.Text = "";
                        txtAnswer.Text = "";
                        cmbtypelogin.Text = "";


                    }
                    
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            this.Close();

        }

        private void Btnback_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();

            login.Show();

            this.Close();
        }

    }
}
