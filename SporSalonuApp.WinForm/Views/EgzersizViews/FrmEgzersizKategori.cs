using SporSalonuApp.Models.EgzersizModels;
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
    public partial class FrmEgzersizKategori : Form
    {
        public EgzersizKategori Kategori{ get; set; }

        public FrmEgzersizKategori():this(new EgzersizKategori()){}

        public FrmEgzersizKategori(EgzersizKategori kategori)
        {
            InitializeComponent();
            this.Kategori = kategori;
        }

        private void FrmEgzersizKategori_Load(object sender, EventArgs e)
        {
            txtKategoriAd.Text = Kategori.Ad;
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            Kategori.Ad = txtKategoriAd.Text;
        }
    }
}
