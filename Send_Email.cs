using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace YarlHospitalWPF
{
    public partial class Send_Email : Form
    {
        public Send_Email()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

//        protected override void OnFormClosing(FormClosingEventArgs e)
//{
//    base.OnFormClosing(e);

//    if (e.CloseReason == CloseReason.WindowsShutDown) return;
//    switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
//    {
//        case DialogResult.Yes:
//         MainMenu main = new MainMenu();
//                    main.Show();
//                    this.Close();
//        break;
//                case DialogResult.No:
//                    Send_Email email = new Send_Email();
//                    email.Show();
//                    break;
//                default:
//        break;
//    }        
//}

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("yarlhospital1@gmail.com", "jaffnayarl");
                MailMessage msg = new MailMessage();
                msg.To.Add(textBoxTo.Text);
                msg.From = new MailAddress("yarlhospital1@gmail.com");
                msg.Subject = textBoxMsg.Text;
                msg.Body = textBoxMsg.Text;
                client.Send(msg);
                MessageBox.Show("message send sucessfully.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);

                textBoxMsg.Clear();
                textBoxSubj.Clear();
                textBoxTo.Clear();

                MainMenu main = new MainMenu();
                main.Show();
                this.Close();




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Send_Email_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu main = new MainMenu();
            main.Show();
            this.Close();
        }
    }
}
