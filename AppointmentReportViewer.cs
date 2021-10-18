using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YarlHospitalWPF
{
    public partial class AppointmentReportViewer : Form
    {
        public AppointmentReportViewer()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            AppointmentReport appRep = new AppointmentReport();
            crystalReportViewer1.ReportSource = appRep;
            crystalReportViewer1.Refresh();
        }
    }
}
