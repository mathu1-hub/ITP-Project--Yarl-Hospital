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
    public partial class LoginWindow : Window
    {
        Service1Client login_acc_ref = new Service1Client();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Cmbtypelogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnButton_Click(object sender, RoutedEventArgs e)
        {
            bool valid = true;

            string username = txtUsername.Text;
            string password = txtPassword.Password;
            string userlevel = cmbtypelogin.Text;

            if(username == "" || password == "" || cmbtypelogin.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill the fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                valid = false;

            }
            else
            {
                if(valid)
                {
                    Boolean result = login_acc_ref.login(txtUsername.Text, txtPassword.Password, cmbtypelogin.Text);
                    
                    if(result)
                    {
                        if ((cmbtypelogin.SelectedIndex == 0) || (cmbtypelogin.SelectedIndex == 2))
                        {
                            MainMenu main = new MainMenu(userlevel);
                            main.Show();
                            this.Close();
                        }
                        if(cmbtypelogin.SelectedIndex == 1)
                        {
                            MainMenu main = new MainMenu(userlevel);
                            main.Show();
                            this.Close();
                                
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username or Password is incorrect, Try again!!", "Login Failed",MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

            //if ((cmbtypelogin.SelectedIndex == 0) || (cmbtypelogin.SelectedIndex == 2))
            //{
            //    MainMenu main = new MainMenu();
            //    main.Show();
            //    this.Close();
            //}
            //else
            //{
            //    if (cmbtypelogin.SelectedIndex == 1)
            //    {
            //        MainMenu main = new MainMenu(userlevel);
            //        main.Show();
            //    }
            //}
        }

        private void Btncreate_Click(object sender, RoutedEventArgs e)
        {
            CreateAccount create = new CreateAccount();
            create.Show();
            this.Close();
        }

        private void Btnforgot_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
