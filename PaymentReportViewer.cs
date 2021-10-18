using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Data.SqlClient;

namespace YarlHospitalWPF
{
    public partial class PaymentReportViewer: Form
    {
      
        public PaymentReportViewer()
        {
            InitializeComponent();
        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {
            PaymentReport pr = new PaymentReport();
            crystalReportViewer2.ReportSource = pr;
            crystalReportViewer2.Refresh();
        }
    }
}
