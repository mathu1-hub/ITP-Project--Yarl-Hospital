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
    public partial class PatientReportViewer : Form
    {
        public PatientReportViewer()
        {
            InitializeComponent();
        }

       
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            PatientReports pa = new PatientReports();
            crystalReportViewer1.ReportSource = pa;
            crystalReportViewer1.Refresh();
        }
    }
}
