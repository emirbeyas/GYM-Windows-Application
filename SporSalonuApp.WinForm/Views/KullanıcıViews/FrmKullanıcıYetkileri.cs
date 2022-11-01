using SporSalonuApp.DatabaseAccess;
using SporSalonuApp.Models.Enums;
using SporSalonuApp.Models.KullanıcıModels;
using SporSalonuApp.WinForm.Models;
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
    public partial class FrmKullanıcıYetkileri : Form
    {
        public Kullanıcı Kullanıcı{ get; set; }

        private void YetkiAyarla()
        {
            if(!Program.Kullanıcı.Yetkiler.FirstOrDefault(x=>x.Tablo == DbTablo.KullanıcıYetkileri && x.Islem == YetkiIslem.Güncelleme).YetkiliMi)
            {
                chkEkle.Enabled = chkGuncelle.Enabled = chkListele.Enabled = chkSil.Enabled = false;
            }
        }

        public FrmKullanıcıYetkileri(string kullanıcıadı)
        {
            InitializeComponent();
            this.Text = kullanıcıadı + " Yetki Ayarları";
            using(UnitOfWork uow = new UnitOfWork())
            {
                Kullanıcı = uow.KullanıcıRepo.GetItem(kullanıcıadı);
            }
            if(Kullanıcı == null)
            {
                MessageBox.Show("Kullanıcı Bulunamadı!");
                this.Close();
            }

            YetkiAyarla();
        }

        private void FrmKullanıcıYetkileri_Load(object sender, EventArgs e)
        {
            cbxTablolar.DisplayMember = "Name";
            cbxTablolar.ValueMember = "Id";
            cbxTablolar.DataSource = new List<ComboBoxModel>
            {
                new ComboBoxModel{Id = (int)DbTablo.Uyeler, Name="Üye İşlemleri"},
                new ComboBoxModel{Id = (int)DbTablo.UyeOlculeri, Name="Üye Ölçü İşlemleri"},
                new ComboBoxModel{Id = (int)DbTablo.UyeProgramları, Name="Üye Program İşlemleri"},
                new ComboBoxModel{Id = (int)DbTablo.Odemeler, Name="Ödeme İşlemleri"},
                new ComboBoxModel{Id = (int)DbTablo.ProgramEgzersizleri, Name="Program Egzersiz İşlemleri"},
                new ComboBoxModel{Id = (int)DbTablo.Egzersizler, Name="Egzersiz İşlemleri"},
                new ComboBoxModel{Id = (int)DbTablo.EgzersizKategorileri, Name="Egzersiz Kategori İşlemleri"},
                new ComboBoxModel{Id = (int)DbTablo.Kullanıcılar, Name="Kullanıcı İşlemleri"},
                new ComboBoxModel{Id = (int)DbTablo.KullanıcıYetkileri, Name="Kullanıcı Yetki İşlemleri"},
            };
            
        }

        private void cbxTablolar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxTablolar.SelectedItem != null)
            {
                DbTablo tablo = (DbTablo)cbxTablolar.SelectedValue;
                List<KullanıcıYetki> yetkiler = Kullanıcı.Yetkiler.Where(x => x.Tablo == tablo).ToList();

                chkEkle.Checked = yetkiler.FirstOrDefault(x => x.Islem == YetkiIslem.Ekleme).YetkiliMi;
                chkGuncelle.Checked = yetkiler.FirstOrDefault(x => x.Islem == YetkiIslem.Güncelleme).YetkiliMi;
                chkSil.Checked = yetkiler.FirstOrDefault(x => x.Islem == YetkiIslem.Silme).YetkiliMi;
                chkListele.Checked = yetkiler.FirstOrDefault(x => x.Islem == YetkiIslem.Listeleme).YetkiliMi;
            }
        }

        private void CheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if(cbxTablolar.SelectedItem != null)
            {
                DbTablo tablo = (DbTablo)cbxTablolar.SelectedValue;
                CheckBox chk = sender as CheckBox;
                if(chk.Name == chkEkle.Name)
                {
                    Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == tablo && x.Islem == YetkiIslem.Ekleme).YetkiliMi = chk.Checked;
                }
                else if(chk.Name == chkListele.Name)
                {
                    Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == tablo && x.Islem == YetkiIslem.Listeleme).YetkiliMi = chk.Checked;
                }
                else if(chk.Name == chkGuncelle.Name)
                {
                    Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == tablo && x.Islem == YetkiIslem.Güncelleme).YetkiliMi = chk.Checked;
                }
                else if(chk.Name == chkSil.Name)
                {
                    Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == tablo && x.Islem == YetkiIslem.Silme).YetkiliMi = chk.Checked;
                }
            }
        }
    }
}
