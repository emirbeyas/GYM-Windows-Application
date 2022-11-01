using SporSalonuApp.DatabaseAccess;
using SporSalonuApp.Models.EgzersizModels;
using SporSalonuApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SporSalonuApp.WinForm.Views.EgzersizViews
{
    public partial class FrmEgzersiz : Form
    {
        UnitOfWork uow = new UnitOfWork();
        public Egzersiz Egzersiz{ get; set; }
        public FrmEgzersiz():this(new Egzersiz()){}
        public FrmEgzersiz(Egzersiz egzersiz)
        {
            InitializeComponent();
            this.Egzersiz = egzersiz;
        }

        private void FrmEgzersiz_Load(object sender, EventArgs e)
        {
            cbxKategori.DataSource   = uow.EgzersizKategoriRepo.ToList();
            cbxKategori.DisplayMember = "Ad";
            cbxKategori.ValueMember = "Id";
            cbxBirim.DataSource = Enum.GetValues(typeof(EgzersizBirimType));


            txtAd.Text = Egzersiz.Ad;
            cbxKategori.SelectedValue = Egzersiz.Kategori.Id;
            cbxBirim.SelectedItem = Egzersiz.BirimType;
            txtAciklama.Text = Egzersiz.Acıklama;
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            Egzersiz.Ad = txtAd.Text;
            Egzersiz.Kategori = cbxKategori.SelectedItem as EgzersizKategori;
            Egzersiz.BirimType = (EgzersizBirimType)cbxBirim.SelectedItem;
            Egzersiz.Acıklama = txtAciklama.Text;
        }
    }
}
