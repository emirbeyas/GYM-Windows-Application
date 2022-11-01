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
using System.Xml.Serialization;
using SporSalonuApp.Models.EgzersizModels;
using SporSalonuApp.DatabaseAccess.Repositories;
using SporSalonuApp.WinForm.Extensions;
using SporSalonuApp.Models.Enums;

namespace SporSalonuApp.WinForm.Views.EgzersizViews
{
    public partial class EgzersizListView : UserControl
    {
        UnitOfWork uow = new UnitOfWork();
        BindingSource source = new BindingSource();

        private void YetkiAyarla()
        {
            btnEkle.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.Egzersizler && x.Islem == YetkiIslem.Ekleme));
            btnSil.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.Egzersizler && x.Islem == YetkiIslem.Silme));
            btnDuzenle.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.Egzersizler && x.Islem == YetkiIslem.Güncelleme));
        }

        public EgzersizListView()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.BorderStyle = BorderStyle.FixedSingle;

            YetkiAyarla();
        }

        private void EgzersizListView_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[0].DataPropertyName = "Id";
            dataGridView1.Columns[1].HeaderText = "Kategori";
            dataGridView1.Columns[1].DataPropertyName = "KategoriAd";
            dataGridView1.Columns[2].HeaderText = "Ad";
            dataGridView1.Columns[2].DataPropertyName = "Ad";
            dataGridView1.Columns[3].HeaderText = "Birim";
            dataGridView1.Columns[3].DataPropertyName = "BirimType";
            dataGridView1.Columns[4].HeaderText = "Açıklama";
            dataGridView1.Columns[4].DataPropertyName = "Acıklama";
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].MinimumWidth = 200;

            source.DataSource = uow.EgzersizRepo.ToList();
            dataGridView1.DataSource = source;

            List<EgzersizKategori> kategoriler = uow.EgzersizKategoriRepo.ToList();
            kategoriler.Insert(0, new EgzersizKategori { Id = 0, Ad = "Hepsi" });
            cbxKategori.DataSource = kategoriler;
            cbxKategori.DisplayMember = "Ad";
            cbxKategori.ValueMember = "Id";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmEgzersiz egzersizFrm = new FrmEgzersiz() { Text = "Yeni Egzersiz Ekle" };
            if (egzersizFrm.ShowDialog() == DialogResult.OK)
            {
                egzersizFrm.Egzersiz.Id = Convert.ToInt32(uow.EgzersizRepo.Add(egzersizFrm.Egzersiz));
                source.Add(egzersizFrm.Egzersiz);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (source.Current != null && DialogResult.Yes ==
                MessageBox.Show("Seçili egzersizi silmek istediğinize emin misiniz?", "Egzersiz Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                uow.EgzersizRepo.Remove(source.Current as Egzersiz);
                source.Remove(source.Current);
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (source.Current != null)
            {
                FrmEgzersiz egzersizFrm = new FrmEgzersiz(source.Current as Egzersiz) { Text = "Egzersiz Düzenle" };
                if (egzersizFrm.ShowDialog() == DialogResult.OK)
                {
                    uow.EgzersizRepo.Update(egzersizFrm.Egzersiz);
                    source.ResetBindings(false);
                }
            }
        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {
            int katid = (cbxKategori.SelectedItem as EgzersizKategori).Id;
            source.DataSource = uow.EgzersizRepo.ToList(katid, txtAd.Text);

        }

        private void cbxKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            int katid = (cbxKategori.SelectedItem as EgzersizKategori).Id;
            source.DataSource = uow.EgzersizRepo.ToList(katid, txtAd.Text);
        }
    }
}
