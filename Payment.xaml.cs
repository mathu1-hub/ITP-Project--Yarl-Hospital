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
    public partial class Payment : Window
    {
        private string userlevel;
        Service1Client pay_ref = new Service1Client();
        public Payment(string lvl)
        {
            InitializeComponent();
            Loaded += Payment_Loaded;
            userlevel = lvl;
        }

        private void Payment_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridPayment.ItemsSource = pay_ref.get_all_payment();
        }

        private void btnLogout1_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Confirm Log out", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Hide();
                MainMenu log = new MainMenu();
                log.Show();
            }
            else
            {
                this.Show();
            }

        }

        private void txtPaymentID_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataGridPayment.ItemsSource = pay_ref.search_PaymentID(txtPaymentID.Text);
        }

        private void btnAddPayment_Click(object sender, RoutedEventArgs e)
        {
            txtinsrtPaymentID.Text = pay_ref.get_max_payment_id();
        }

        private void txtBalanceAmount_SelectionChanged(object sender, RoutedEventArgs e)
        {
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string payid = txtinsrtPaymentID.Text;
            try
            {
                if ((txtinsrtPaymentID.Text == "") | (txtdate.Text == "") | (cmbpaytype.Text == "") | (txtTotalAmount.Text == "") | (txtPaidAmount.Text == "") | (txtBalanceAmount.Text == ""))
                {
                    MessageBox.Show("Please fill all fields to add", "Fields Required", MessageBoxButton.OK, MessageBoxImage.Error);
                }


                else
                {

                    pay_ref.add_new_payment(txtinsrtPaymentID.Text, txtdate.Text, cmbpaytype.Text, int.Parse(txtTotalAmount.Text), int.Parse(txtPaidAmount.Text), int.Parse(txtBalanceAmount.Text));

                    MessageBox.Show("Information Successfully Added ", "Success", MessageBoxButton.OK, MessageBoxImage.Information);


                    txtinsrtPaymentID.Text = "";
                    txtdate.Text = "";
                    cmbpaytype.Text = "";
                    txtTotalAmount.Text = "";
                    txtPaidAmount.Text = "";
                    txtBalanceAmount.Text = "";

                }
            }
            catch (Exception ex)
            { }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                pay_ref.update_payment(txtinsrtPaymentID.Text, txtdate.Text, cmbpaytype.Text, int.Parse(txtTotalAmount.Text), int.Parse(txtPaidAmount.Text), int.Parse(txtBalanceAmount.Text));


                MessageBox.Show("Information Successfully Updated ", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            { }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            string payid = txtinsrtPaymentID.Text;
            try
            {
                if (payid == "")
                {
                    MessageBox.Show("Please Enter Values", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (payid == txtinsrtPaymentID.Text)
                {
                    if (MessageBox.Show("Do you want to Delete this Record?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        pay_ref.delete_payment(txtinsrtPaymentID.Text);
                        MessageBox.Show("Information Successfully Deleted ", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                        txtinsrtPaymentID.Text = "";
                        txtdate.Text = "";
                        txtBalanceAmount.Text = "";
                        txtPaidAmount.Text = "";
                        txtTotalAmount.Text = "";
                        cmbpaytype.Text = "";


                    }
                    else
                    {
                        pay_ref.delete_payment(txtinsrtPaymentID.Text);
                    }


                }


            }
            catch (Exception ex)
            { }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtinsrtPaymentID.Text = "";
            txtdate.Text = "";
            cmbpaytype.Text = "";
            txtTotalAmount.Text = "";
            txtPaidAmount.Text = "";
            txtBalanceAmount.Text = "";
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            MainMenu main = new MainMenu(userlevel);
            main.Show();
            this.Close();
        }

        private void dataGridPayment_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void BbtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtinsrtPaymentID.Text = "";
            txtdate.Text = "";
            cmbpaytype.Text = "";
            txtTotalAmount.Text = "";
            txtPaidAmount.Text = "";
            txtBalanceAmount.Text = "";
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = pay_ref.View_Payment(txtinsrtPaymentID.Text);
                if(txtinsrtPaymentID.Text == "")
                {
                    MessageBox.Show("Please enter valid Payment ID", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    txtinsrtPaymentID.Text = result.Payment_ID.ToString();
                    txtdate.Text = result.Date.ToString();
                    cmbpaytype.Text = result.Type.ToString();
                    txtTotalAmount.Text = result.Total_Amount.ToString();
                    txtPaidAmount.Text = result.Paid_Amount.ToString();
                    txtBalanceAmount.Text = result.Balance_Amount.ToString();
                }




            }
            catch(Exception ex)
            {

            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            string payid = txtinsrtPaymentID.Text;
            try
            {
                if (payid == "")
                {
                    MessageBox.Show("Please Enter Values", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (payid == txtinsrtPaymentID.Text)
                {
                    if (MessageBox.Show("Do you want to Delete this Record?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        pay_ref.delete_payment(txtinsrtPaymentID.Text);
                        MessageBox.Show("Information Successfully Deleted ", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                        txtinsrtPaymentID.Text = "";
                        txtdate.Text = "";
                        txtBalanceAmount.Text = "";
                        txtPaidAmount.Text = "";
                        txtTotalAmount.Text = "";
                        cmbpaytype.Text = "";


                    }
                    else
                    {
                        pay_ref.View_Payment(txtinsrtPaymentID.Text);
                    }


                }


            }
            catch (Exception ex)
            { }
        }

        private void TxtBalanceAmount_TextChanged(object sender, TextChangedEventArgs e)
        {

           
        }

        private void TxtBalanceAmount_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void TxtBalanceAmount_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void TxtPaidAmount_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(txtTotalAmount.Text) - Convert.ToInt32(txtPaidAmount.Text);
                txtBalanceAmount.Text = a.ToString();
            }
            catch(Exception ex)
            {
               
            }
            
        }
    }
}
