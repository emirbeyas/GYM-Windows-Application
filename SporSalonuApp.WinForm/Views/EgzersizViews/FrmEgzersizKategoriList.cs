using SporSalonuApp.DatabaseAccess;
using SporSalonuApp.Models.EgzersizModels;
using SporSalonuApp.Models.Enums;
using SporSalonuApp.WinForm.Extensions;
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
    public partial class FrmEgzersizKategoriList : Form
    {
        UnitOfWork uow = new UnitOfWork();
        BindingSource source = new BindingSource();

        private void YetkiAyarla()
        {
            btnEkle.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.EgzersizKategorileri && x.Islem == YetkiIslem.Ekleme));
            btnSil.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.EgzersizKategorileri && x.Islem == YetkiIslem.Silme));
            btnDuzenle.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.EgzersizKategorileri && x.Islem == YetkiIslem.Güncelleme));
        }

        public FrmEgzersizKategoriList()
        {
            InitializeComponent();

            YetkiAyarla();
        }

        private void FrmEgzersizKategoriList_Load(object sender, EventArgs e)
        {
            Text = "Egzersiz Kategorileri";
            source.DataSource = uow.EgzersizKategoriRepo.ToList();
            lstAd.DataSource = source;
            lstAd.DisplayMember = "Ad";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmEgzersizKategori kategoriFrm = new FrmEgzersizKategori() { Text = "Yeni Kategori Ekle" };
            if (kategoriFrm.ShowDialog() == DialogResult.OK)
            {
                kategoriFrm.Kategori.Id = Convert.ToInt32(uow.EgzersizKategoriRepo.Add(kategoriFrm.Kategori));
                source.Add(kategoriFrm.Kategori);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (source.Current != null && DialogResult.Yes == MessageBox.Show("Seçili kategoriyi silmek istiyor musunuz?", "Kategori Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                uow.EgzersizKategoriRepo.Remove(source.Current as EgzersizKategori);
                source.Remove(source.Current);
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if(source.Current != null)
            {
                FrmEgzersizKategori kategoriFrm = new FrmEgzersizKategori(source.Current as EgzersizKategori) { Text = "Kategori Düzenle" };
                if(kategoriFrm.ShowDialog() == DialogResult.OK)
                {
                    uow.EgzersizKategoriRepo.Update(kategoriFrm.Kategori);
                    source.ResetBindings(false);
                }
            }
        }
    }
}
