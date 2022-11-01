
using Microsoft.Reporting.WinForms;
using SporSalonuApp.DatabaseAccess;
using SporSalonuApp.Models.Enums;
using SporSalonuApp.Models.UyeModels;
using SporSalonuApp.WinForm.Extensions;
using SporSalonuApp.WinForm.Views.ReportViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SporSalonuApp.WinForm.Views.UyeViews
{
    public partial class FrmUyeOlcuList : Form
    {
        UnitOfWork uow = new UnitOfWork();
        BindingSource source = new BindingSource();

        public Uye Uye{ get; set; }

        private void YetkiAyarla()
        {
            btnEkle.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.UyeOlculeri && x.Islem == YetkiIslem.Ekleme));
            btnDuzenle.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.UyeOlculeri && x.Islem == YetkiIslem.Güncelleme));
            btnSil.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.UyeOlculeri && x.Islem == YetkiIslem.Silme));
        }

        public FrmUyeOlcuList(Uye uye)
        {
            InitializeComponent();
            this.Uye = uye;
            this.Text = uye.Ad + " " + uye.Soyad + " Ölçü Listesi";

            YetkiAyarla();
        }

        private void FrmUyeOlcuList_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[0].DataPropertyName = "Id";
            dataGridView1.Columns[1].HeaderText = "Kol (cm)";
            dataGridView1.Columns[1].DataPropertyName = "Kol";
            dataGridView1.Columns[2].HeaderText = "Göğüs (cm)";
            dataGridView1.Columns[2].DataPropertyName = "Gogus";
            dataGridView1.Columns[3].HeaderText = "Kalça (cm)";
            dataGridView1.Columns[3].DataPropertyName = "Kalca";
            dataGridView1.Columns[4].HeaderText = "Bel (cm)";
            dataGridView1.Columns[4].DataPropertyName = "Bel";
            dataGridView1.Columns[5].HeaderText = "Boy (cm)";
            dataGridView1.Columns[5].DataPropertyName = "Boy";
            dataGridView1.Columns[6].HeaderText = "Kilo (Kg)";
            dataGridView1.Columns[6].DataPropertyName = "Kg";
            dataGridView1.Columns[7].HeaderText = "Ölçüm Tarihi";
            dataGridView1.Columns[7].DataPropertyName = "Tarih";
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[7].MinimumWidth = 200;

            source.DataSource = uow.UyeOlcuRepo.ToList(Uye.Id);
            dataGridView1.DataSource = source;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmUyeOlcu olcuFrm = new FrmUyeOlcu(Uye.Id) { Text = Uye.Ad + " " + Uye.Soyad + " Ölçü Ekle" };
            if(olcuFrm.ShowDialog() == DialogResult.OK)
            {
                olcuFrm.Olcu.Id = Convert.ToInt32(uow.UyeOlcuRepo.Add(olcuFrm.Olcu));
                source.Add(olcuFrm.Olcu);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if(source.Current != null)
            {
                UyeOlcu olcu = source.Current as UyeOlcu;
                if(DialogResult.Yes == MessageBox.Show(Uye.Ad+" "+Uye.Soyad+" adlı üyeye ait "+olcu.Tarih.ToShortDateString()+" tarihli ölçü kaydını silmek istiyor musunuz?",
                                                        "Üye Ölçü Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    uow.UyeOlcuRepo.Remove(olcu);
                    source.Remove(olcu);
                }
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (source.Current != null)
            {
                FrmUyeOlcu olcuFrm = new FrmUyeOlcu(source.Current as UyeOlcu) { Text = Uye.Ad + " " + Uye.Soyad + " Ölçü Güncelle" };
                if(olcuFrm.ShowDialog() == DialogResult.OK)
                {
                    uow.UyeOlcuRepo.Update(olcuFrm.Olcu);
                    source.ResetBindings(false);
                }
            }
        }

        private void btnYazdır_Click(object sender, EventArgs e)
        {
            FrmReport reportFrm = new FrmReport();
            reportFrm.Text = "Üye Ölçü Listesi";
            reportFrm.WindowState = FormWindowState.Maximized;
            reportFrm.ReportViewer.Load += (s, ev) =>
            {
                reportFrm.ReportViewer.ProcessingMode = ProcessingMode.Local;
                reportFrm.ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportFrm.ReportViewer.Reset();
                reportFrm.ReportViewer.LocalReport.ReportEmbeddedResource = "SporSalonuApp.WinForm.Reports.UyeOlcuListReport.rdlc";
                List<ReportParameter> parameters = new List<ReportParameter> { new ReportParameter("UyeAdSoyad", Uye.AdSoyad) };
                reportFrm.ReportViewer.LocalReport.SetParameters(parameters);
                reportFrm.ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("UyeOlcuDataSet", source));
                reportFrm.ReportViewer.RefreshReport();
            };
            reportFrm.ShowDialog();
        }
    }
}
