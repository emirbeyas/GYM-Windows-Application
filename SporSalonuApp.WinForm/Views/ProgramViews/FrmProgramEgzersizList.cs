using Microsoft.Reporting.WinForms;
using SporSalonuApp.DatabaseAccess;
using SporSalonuApp.Models.Enums;
using SporSalonuApp.Models.UyeProgramModels;
using SporSalonuApp.WinForm.Extensions;
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

namespace SporSalonuApp.WinForm.Views.ProgramViews
{
    public partial class FrmProgramEgzersizList : Form
    {
        UnitOfWork uow = new UnitOfWork();
        BindingSource source = new BindingSource();

        public UyeProgram Program { get; set; }

        private void YetkiAyarla()
        {
            btnEkle.YetkiVisile(WinForm.Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.ProgramEgzersizleri && x.Islem == YetkiIslem.Ekleme));
            btnDuzenle.YetkiVisile(WinForm.Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.ProgramEgzersizleri && x.Islem == YetkiIslem.Güncelleme));
            btnSil.YetkiVisile(WinForm.Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.ProgramEgzersizleri && x.Islem == YetkiIslem.Silme));
        }

        public FrmProgramEgzersizList(UyeProgram program)
        {
            InitializeComponent();
            this.Program = program;

            YetkiAyarla();
        }

        private void FrmProgramEgzersizList_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[0].DataPropertyName = "Id";
            dataGridView1.Columns[1].HeaderText = "Gün";
            dataGridView1.Columns[1].DataPropertyName = "Gun";
            dataGridView1.Columns[2].HeaderText = "Egzersiz Adı";
            dataGridView1.Columns[2].DataPropertyName = "EgzersizAd";
            dataGridView1.Columns[3].HeaderText = "Kategori";
            dataGridView1.Columns[3].DataPropertyName = "EgzersizKategori";
            dataGridView1.Columns[4].HeaderText = "Set Adet";
            dataGridView1.Columns[4].DataPropertyName = "SetAdet";
            dataGridView1.Columns[5].HeaderText = "Tekrar Sayısı";
            dataGridView1.Columns[5].DataPropertyName = "TekrarSayısı";
            dataGridView1.Columns[6].HeaderText = "Birim";
            dataGridView1.Columns[6].DataPropertyName = "BirimType";
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[6].MinimumWidth = 200;

            source.DataSource = uow.ProgramEgzersizRepo.ToList(Program.Id);
            dataGridView1.DataSource = source;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmProgramEgzersiz egzersizFrm = new FrmProgramEgzersiz(Program.Id) { Text = "Yeni Program Egzersizi Ekle" };
            if (egzersizFrm.ShowDialog() == DialogResult.OK)
            {
                egzersizFrm.ProgramEgzersiz.Id = Convert.ToInt32(uow.ProgramEgzersizRepo.Add(egzersizFrm.ProgramEgzersiz));
                source.Add(egzersizFrm.ProgramEgzersiz);
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if(source.Current != null)
            {
                FrmProgramEgzersiz egzersizFrm = new FrmProgramEgzersiz(source.Current as ProgramEgzersiz) { Text = "Program Egzersizi Düzenle" };
                if (egzersizFrm.ShowDialog() == DialogResult.OK)
                {
                    uow.ProgramEgzersizRepo.Update(egzersizFrm.ProgramEgzersiz);
                    source.ResetBindings(false);
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if(source.Current != null && DialogResult.Yes == MessageBox.Show("Programdan seçili egzersizi silmek istiyor musunuz?", "Program Egzersizi Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                uow.ProgramEgzersizRepo.Remove(source.Current as ProgramEgzersiz);
                source.Remove(source.Current);
            }
        }

        private void btnYazdır_Click(object sender, EventArgs e)
        {
            FrmReport reportFrm = new FrmReport();
            reportFrm.Text = "Program Egzersiz Listesi";
            reportFrm.WindowState = FormWindowState.Maximized;
            reportFrm.ReportViewer.Load += (s, ev) =>
            {
                reportFrm.ReportViewer.ProcessingMode = ProcessingMode.Local;
                reportFrm.ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportFrm.ReportViewer.Reset();
                reportFrm.ReportViewer.LocalReport.ReportEmbeddedResource = "SporSalonuApp.WinForm.Reports.ProgramEgzersizListReport.rdlc";
                reportFrm.ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("ProgramEgzersizDataSet", source));
                reportFrm.ReportViewer.RefreshReport();
            };
            reportFrm.ShowDialog();
        }
    }
}
