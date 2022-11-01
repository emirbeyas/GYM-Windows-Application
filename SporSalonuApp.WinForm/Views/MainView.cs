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
using SporSalonuApp.Models.ReportModels;

namespace SporSalonuApp.WinForm.Views
{
    public partial class MainView : UserControl
    {
        UnitOfWork uow = new UnitOfWork();
        BindingSource source = new BindingSource();

        public MainView()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            try
            {
                MainViewModel countModel = uow.ReportRepo.GetMainViewModel();
                infoUyeAdet.Value = countModel.UyeAdet.ToString();
                infoEgzersizAdet.Value = countModel.EgzersizAdet.ToString();
                infoAktifProgAdet.Value = countModel.AktifProgramAdet.ToString();
                infoKullanıcıAdet.Value = countModel.KullanıcıAdet.ToString();


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

                source.DataSource = uow.UyeRepo.GetBugunAntrenmaniOlanlar();
                dataGridView1.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Spor Salonu App", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
