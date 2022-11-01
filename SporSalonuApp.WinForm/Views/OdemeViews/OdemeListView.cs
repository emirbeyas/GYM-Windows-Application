using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SporSalonuApp.DatabaseAccess;
using SporSalonuApp.Models.OdemeModels;
using SporSalonuApp.Models.UyeModels;
using SporSalonuApp.Models.EgzersizModels;
using SporSalonuApp.WinForm.Models;
using SporSalonuApp.DatabaseAccess.Repositories;
using SporSalonuApp.WinForm.Extensions;
using SporSalonuApp.Models.Enums;
using SporSalonuApp.WinForm.Views.ReportViews;
using Microsoft.Reporting.WinForms;

namespace SporSalonuApp.WinForm.Views.OdemeViews
{
    public partial class OdemeListView : UserControl
    {
        UnitOfWork uow = new UnitOfWork();
        BindingSource source = new BindingSource();

        private void YetkiAyarla()
        {
            btnEkle.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.Odemeler && x.Islem == YetkiIslem.Ekleme));
            btnDuzenle.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.Odemeler && x.Islem == YetkiIslem.Güncelleme));
            btnSil.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.Odemeler && x.Islem == YetkiIslem.Silme));
        }

        public OdemeListView()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            YetkiAyarla();
        }

        private void OdemeListView_Load(object sender, EventArgs e)
        {
            List<ComboBoxModel> orderList = new List<ComboBoxModel>
            {
                new ComboBoxModel{Id = Convert.ToInt32(OdemeSıralamaTypes.AdaGoreArtan), Name = "Ada Göre Artan"},
                new ComboBoxModel{Id = Convert.ToInt32(OdemeSıralamaTypes.AdaGoreAzalan), Name = "Ada Göre Azalan"},
                new ComboBoxModel{Id = Convert.ToInt32(OdemeSıralamaTypes.TariheGoreArtan), Name = "Tarihe Göre Artan"},
                new ComboBoxModel{Id = Convert.ToInt32(OdemeSıralamaTypes.TariheGoreAzalan), Name = "Tarihe Göre Azalan"}
            };
            cbxSırala.DataSource = orderList;
            cbxSırala.DisplayMember = "Name";
            cbxSırala.ValueMember = "Id";
            cbxSırala.SelectedIndexChanged += cbxSıralamaSelectedChanged;


            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[0].DataPropertyName = "Id";
            dataGridView1.Columns[1].HeaderText = "Üye";
            dataGridView1.Columns[1].DataPropertyName = "UyeAdSoyad";
            dataGridView1.Columns[2].HeaderText = "Tarih Saat";
            dataGridView1.Columns[2].DataPropertyName = "TarihSaat";
            dataGridView1.Columns[3].HeaderText = "Ay Adet";
            dataGridView1.Columns[3].DataPropertyName = "OdenenAyAdet";
            dataGridView1.Columns[4].HeaderText = "Tutar";
            dataGridView1.Columns[4].DataPropertyName = "Ucret";

            dtpAlt.Value = DateTime.Now.Subtract(new TimeSpan(30, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second));
            dtpUst.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            dtpAlt.ValueChanged += TarihFilter_Degisimi;
            dtpUst.ValueChanged += TarihFilter_Degisimi;

            List<Uye> uyeler = uow.UyeRepo.ToList();
            uyeler.Insert(0, new Uye { Id = 0, Ad = "Hepsi", Soyad = "" });
            cbxUye.DisplayMember = "AdSoyad";
            cbxUye.ValueMember = "Id";
            cbxUye.DataSource = uyeler;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmOdeme odemeFrm = new FrmOdeme() { Text = "Yeni Ödeme Ekle" };
            if (odemeFrm.ShowDialog() == DialogResult.OK)
            {
                odemeFrm.Odeme.Id = Convert.ToInt32(uow.OdemeRepo.Add(odemeFrm.Odeme));
                source.Add(odemeFrm.Odeme);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (source.Current != null &&
                DialogResult.Yes == MessageBox.Show("Seçili ödeme kaydını silmek istiyor musunuz?", "Ödeme Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                uow.OdemeRepo.Remove(source.Current as Odeme);
                source.Remove(source.Current);
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (source.Current != null)
            {
                FrmOdeme odemeFrm = new FrmOdeme(source.Current as Odeme) { Text = "Ödeme Düzenle" };
                if (odemeFrm.ShowDialog() == DialogResult.OK)
                {
                    uow.OdemeRepo.Update(odemeFrm.Odeme);
                    source.ResetBindings(false);
                }
            }
        }

        private void cbxUye_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listele();
        }

        private void TarihFilter_Degisimi(object sender, EventArgs e)
        {
            Listele();
        }

        private void chkTarih_CheckedChanged(object sender, EventArgs e)
        {
            dtpAlt.Enabled = dtpUst.Enabled = chkTarih.Checked;
            Listele();            
        }

        private void cbxSıralamaSelectedChanged(object sender, EventArgs e)
        {
            Listele();
        }

        private void Listele()
        {
            Uye uye = cbxUye.SelectedItem as Uye;
            if (!chkTarih.Checked)
            {
                source.DataSource = uow.OdemeRepo.ToList((OdemeSıralamaTypes)cbxSırala.SelectedValue, (uye == null) ? 0 : uye.Id);
                dataGridView1.DataSource = source;
            }
            else
            {
                source.DataSource = uow.OdemeRepo.ToList((OdemeSıralamaTypes)cbxSırala.SelectedValue, (uye == null) ? 0 : uye.Id, dtpAlt.Value, dtpUst.Value);
                dataGridView1.DataSource = source;
            }
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
                reportFrm.ReportViewer.LocalReport.ReportEmbeddedResource = "SporSalonuApp.WinForm.Reports.OdemeListReport.rdlc";
                reportFrm.ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("OdemeDataSet", source));
                reportFrm.ReportViewer.RefreshReport();
            };
            reportFrm.ShowDialog();
        }
    }
}
