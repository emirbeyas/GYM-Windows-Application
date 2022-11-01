using SporSalonuApp.Models.UyeModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SporSalonuApp.WinForm.Views.UyeViews
{
    public partial class FrmUye : Form
    {
        public Uye Uye { get; set; }

        public FrmUye():this(new Uye()){}
        public FrmUye(Uye uye)
        {
            InitializeComponent();
            this.Uye = uye;
        }

        private void FrmUye_Load(object sender, EventArgs e)
        {
            txtAd.Text = Uye.Ad;
            txtSoyad.Text = Uye.Soyad;
            dtpDTarih.Value = Uye.DogumTarih;
            dtpKayıtTarih.Value = Uye.KayıtTarih;
            dtpUyelikSonTarih.Value = Uye.UyelikSonTarih;
            txtTelNo.Text = Uye.TelefonNo;
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            Uye.Ad = txtAd.Text;
            Uye.Soyad = txtSoyad.Text;
            Uye.DogumTarih = dtpDTarih.Value;
            Uye.KayıtTarih = dtpKayıtTarih.Value;
            Uye.UyelikSonTarih = dtpUyelikSonTarih.Value;
            Uye.TelefonNo = txtTelNo.Text;
        }
    }
}
