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
    public partial class DrugReportViewer : Form
    {
        public DrugReportViewer()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            DrugReport drug = new DrugReport();
            crystalReportViewer1.ReportSource = drug;
            crystalReportViewer1.Refresh();


        }
    }
}
