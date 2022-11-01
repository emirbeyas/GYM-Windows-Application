using Microsoft.Reporting.WinForms;
using SporSalonuApp.DatabaseAccess;
using SporSalonuApp.Models.Enums;
using SporSalonuApp.Models.UyeModels;
using SporSalonuApp.Models.UyeProgramModels;
using SporSalonuApp.WinForm.Extensions;
using SporSalonuApp.WinForm.Views.ProgramViews;
using SporSalonuApp.WinForm.Views.ReportViews;
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
    public partial class FrmUyeProgramList : Form
    {
        UnitOfWork uow = new UnitOfWork();
        BindingSource source = new BindingSource();

        public Uye Uye { get; set; }

        private void YetkiAyarla()
        {
            btnEkle.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.UyeProgramları && x.Islem == YetkiIslem.Ekleme));
            btnDuzenle.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.UyeProgramları && x.Islem == YetkiIslem.Güncelleme));
            btnSil.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.UyeProgramları && x.Islem == YetkiIslem.Silme));
            btnProgramDetayList.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.ProgramEgzersizleri && x.Islem == YetkiIslem.Listeleme));
        }

        public FrmUyeProgramList(Uye uye)
        {
            InitializeComponent();
            this.Uye = uye;
            this.Text = uye.Ad + " " + uye.Soyad + " Program Listesi";

            YetkiAyarla();
        }

        private void FrmUyeProgramList_Load(object sender, EventArgs e)
        {
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[0].DataPropertyName = "Id";
            dataGridView1.Columns[1].HeaderText = "Durum";
            dataGridView1.Columns[1].DataPropertyName = "IsAktif";
            dataGridView1.Columns[2].HeaderText = "Başlangıç Tarih";
            dataGridView1.Columns[2].DataPropertyName = "BaslangıcTarih";
            dataGridView1.Columns[3].HeaderText = "Bitiş Tarih";
            dataGridView1.Columns[3].DataPropertyName = "BitisTarih";
            dataGridView1.Columns[4].HeaderText = "Açıklama";
            dataGridView1.Columns[4].DataPropertyName = "Acıklama";
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].MinimumWidth = 200;

            dataGridView1.DataSource = source;
            Listele();
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex == 1)
            {
                e.Value = (bool)e.Value ? "Aktif" : "Pasif";
                e.FormattingApplied = true;
            }
        }

        private void btnProgramDetayList_Click(object sender, EventArgs e)
        {
            if(source.Current != null)
            {
                FrmProgramEgzersizList egzersizList = new FrmProgramEgzersizList(source.Current as UyeProgram) { Text = "Üye Program Detayları" };
                egzersizList.ShowDialog();
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmUyeProgram programFrm = new FrmUyeProgram(Uye.Id) { Text = "Yeni Program Ekle" };
            if(programFrm.ShowDialog() == DialogResult.OK)
            {
                programFrm.UyeProgram.Id = Convert.ToInt32(uow.UyeProgRepo.Add(programFrm.UyeProgram));
                source.Add(programFrm.UyeProgram);
                Listele();
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if(source.Current != null)
            {
                FrmUyeProgram programFrm = new FrmUyeProgram(source.Current as UyeProgram) { Text = "Program Düzenle" };
                if(programFrm.ShowDialog() == DialogResult.OK)
                {
                    uow.UyeProgRepo.Update(programFrm.UyeProgram);
                    source.ResetBindings(false);
                    Listele();
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if(source.Current != null && DialogResult.Yes ==
                MessageBox.Show("Seçili üye Program kaydını silmek istiyor musunuz?", "Üye Program Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                uow.UyeProgRepo.Remove(source.Current as UyeProgram);
                source.Remove(source.Current);
            }
        }

        private void Listele()
        {
            source.DataSource = uow.UyeProgRepo.ToList(Uye.Id);
        }

        private void btnYazdır_Click(object sender, EventArgs e)
        {
            FrmReport reportFrm = new FrmReport();
            reportFrm.Text = "Üye Program Listesi";
            reportFrm.WindowState = FormWindowState.Maximized;
            reportFrm.ReportViewer.Load += (s, ev) =>
            {
                reportFrm.ReportViewer.ProcessingMode = ProcessingMode.Local;
                reportFrm.ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportFrm.ReportViewer.Reset();
                reportFrm.ReportViewer.LocalReport.ReportEmbeddedResource = "SporSalonuApp.WinForm.Reports.UyeProgramListReport.rdlc";
                List<ReportParameter> parameters = new List<ReportParameter> { new ReportParameter("UyeAdSoyad", Uye.AdSoyad) };
                reportFrm.ReportViewer.LocalReport.SetParameters(parameters);
                reportFrm.ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("UyeProgramDataSet", source));
                reportFrm.ReportViewer.RefreshReport();
            };
            reportFrm.ShowDialog();
        }
    }
}
