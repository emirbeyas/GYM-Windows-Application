using Microsoft.Reporting.WinForms;
using SporSalonuApp.DatabaseAccess;
using SporSalonuApp.DatabaseAccess.Repositories;
using SporSalonuApp.Models.Enums;
using SporSalonuApp.Models.UyeModels;
using SporSalonuApp.WinForm.Extensions;
using SporSalonuApp.WinForm.Models;
using SporSalonuApp.WinForm.Views.ReportViews;
using SporSalonuApp.WinForm.Views.UyeViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SporSalonuApp.WinForm.Views
{
    public partial class UyeListView : UserControl, IDisposable
    {
        UnitOfWork uow = new UnitOfWork();
        BindingSource source = new BindingSource();

        private void YetkiAyarla()
        {
            btnEkle.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.Uyeler && x.Islem == YetkiIslem.Ekleme));
            btnDuzenle.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.Uyeler && x.Islem == YetkiIslem.Güncelleme));
            btnSil.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.Uyeler && x.Islem == YetkiIslem.Silme));
            btnUyeOlculeri.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.UyeOlculeri && x.Islem == YetkiIslem.Listeleme));
            btnUyeProgramList.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.UyeProgramları && x.Islem == YetkiIslem.Listeleme));
        }

        public UyeListView()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.BorderStyle = BorderStyle.FixedSingle;

            Disposed += UyeListView_Disposed;

            YetkiAyarla();
        }

        private void UyeListView_Load(object sender, EventArgs e)
        {
            cbxSırala.DataSource = new List<ComboBoxModel>
            {
                new ComboBoxModel{Id = Convert.ToInt32(UyeSıralamaTypes.AdaGoreArtan), Name = "Ada Göre Artan"},
                new ComboBoxModel{Id = Convert.ToInt32(UyeSıralamaTypes.AdaGoreAzalan), Name = "Ada Göre Azalan"},
                new ComboBoxModel{Id = Convert.ToInt32(UyeSıralamaTypes.KayıtTarihineGoreArtan), Name = "Kayıt Tarihine Göre Artan"},
                new ComboBoxModel{Id = Convert.ToInt32(UyeSıralamaTypes.KayıtTarihineGoreAzalan), Name = "Kayıt Tarihine Göre Azalan"},
                new ComboBoxModel{Id = Convert.ToInt32(UyeSıralamaTypes.SoyadaGoreArtan), Name = "Soyada Göre Artan"},
                new ComboBoxModel{Id = Convert.ToInt32(UyeSıralamaTypes.SoyadaGoreAzalan), Name = "Soyada Göre Azalan"},
                new ComboBoxModel{Id = Convert.ToInt32(UyeSıralamaTypes.UyelikSonTarihineGoreArtan), Name = "Üyelik Son Tarihine Göre Artan"},
                new ComboBoxModel{Id = Convert.ToInt32(UyeSıralamaTypes.UyelikSonTarihineGoreAzalan), Name = "Üyelik Son Tarihine Göre Azalan"}

            };
            cbxSırala.DisplayMember = "Name";
            cbxSırala.ValueMember = "Id";
            cbxSırala.SelectedIndexChanged += cbxSıralamaChanged;


            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[0].DataPropertyName = "Id";
            dataGridView1.Columns[1].HeaderText = "Adı";
            dataGridView1.Columns[1].DataPropertyName = "Ad";
            dataGridView1.Columns[2].HeaderText = "Soyadı";
            dataGridView1.Columns[2].DataPropertyName = "Soyad";
            dataGridView1.Columns[3].HeaderText = "Dogum Tarihi";
            dataGridView1.Columns[3].DataPropertyName = "DogumTarih";
            dataGridView1.Columns[4].HeaderText = "Kayıt Tarihi";
            dataGridView1.Columns[4].DataPropertyName = "KayıtTarih";
            dataGridView1.Columns[5].HeaderText = "Üyelik Son Tarihi";
            dataGridView1.Columns[5].DataPropertyName = "UyelikSonTarih";
            dataGridView1.Columns[6].HeaderText = "Telefon No";
            dataGridView1.Columns[6].DataPropertyName = "TelefonNo";
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[6].MinimumWidth = 200;

            //source.DataSource = uow.UyeRepo.ToList();
            Listele();
            dataGridView1.DataSource = source;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmUye uyeFrm = new FrmUye() { Text = "Üye Ekle" };
            if(uyeFrm.ShowDialog() == DialogResult.OK)
            {
                uyeFrm.Uye.Id = Convert.ToInt32(uow.UyeRepo.Add(uyeFrm.Uye));
                source.Add(uyeFrm.Uye);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if(source.Current != null)
            {
                Uye uye = source.Current as Uye;
                if(MessageBox.Show(uye.Ad+" "+uye.Soyad+" adlı üyeyi silmek istediğinize emin misiniz?", "Üye Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    uow.UyeRepo.Remove(uye);
                    source.Remove(uye);
                }
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (source.Current != null)
            {
                FrmUye uyeFrm = new FrmUye(source.Current as Uye) { Text = "Üye Güncelle" };
                if (uyeFrm.ShowDialog() == DialogResult.OK)
                {
                    uow.UyeRepo.Update(uyeFrm.Uye);
                    source.ResetBindings(false);
                }
            }
        }

        private void btnUyeOlculeri_Click(object sender, EventArgs e)
        {
            if (source.Current != null)
            {
                FrmUyeOlcuList uyeOlcuListFrm = new FrmUyeOlcuList(source.Current as Uye);
                uyeOlcuListFrm.ShowDialog();
            }
        }

        private void btnUyeProgramList_Click(object sender, EventArgs e)
        {
            if (source.Current != null)
            {
                FrmUyeProgramList programListFrm = new FrmUyeProgramList(source.Current as Uye);
                programListFrm.ShowDialog();
            }
        }

        private void txtAranan_TextChanged(object sender, EventArgs e)
        {
            Listele();   
        }

        private void cbxSıralamaChanged(object sender, EventArgs e)
        {
            Listele();
        }

        private void Listele()
        {
            source.DataSource = uow.UyeRepo.ToList((UyeSıralamaTypes)cbxSırala.SelectedValue, txtAd.Text, txtSoyad.Text, txtTelNo.Text);
        }
        private void UyeListView_Disposed(object sender, EventArgs e)
        {
            uow.Dispose();
            source.Dispose();
        }

        private void btnYazdır_Click(object sender, EventArgs e)
        {
            FrmReport reportFrm = new FrmReport();
            reportFrm.Text = "Üye Listesi";
            reportFrm.WindowState = FormWindowState.Maximized;
            reportFrm.ReportViewer.Load += (s, ev) =>
            {
                reportFrm.ReportViewer.ProcessingMode = ProcessingMode.Local;
                reportFrm.ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportFrm.ReportViewer.Reset();
                reportFrm.ReportViewer.LocalReport.ReportEmbeddedResource = "SporSalonuApp.WinForm.Reports.UyeListReport.rdlc";
                reportFrm.ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("UyeDataSet",source));
                reportFrm.ReportViewer.RefreshReport();
            };
            reportFrm.ShowDialog();
        }
    }
}
