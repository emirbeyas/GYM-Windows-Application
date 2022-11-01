using SporSalonuApp.DatabaseAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SporSalonuApp.WinForm.Views.KullanıcıViews
{
    public partial class FrmLogin : Form
    {
        public string KullanıcıAdı { get; set; }
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
                if (uow.KullanıcıRepo.Login(txtKullanıcıadı.Text.Trim(), txtParola.Text.Trim()))
                {
                    this.KullanıcıAdı = txtKullanıcıadı.Text;
                    this.DialogResult = DialogResult.OK;
                }
                else
                    lblError.Visible = true;
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
