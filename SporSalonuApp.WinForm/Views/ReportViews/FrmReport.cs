using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SporSalonuApp.WinForm.Views.ReportViews
{
    public partial class FrmReport : Form
    {
        public ReportViewer ReportViewer
        {
            get { return reportViewer1; }
        }
        public FrmReport()
        {
            InitializeComponent();
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {

        }
    }
}
