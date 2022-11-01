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
using SporSalonuApp.Models.KullanıcıModels;
using SporSalonuApp.WinForm.Extensions;
using SporSalonuApp.Models.Enums;

namespace SporSalonuApp.WinForm.Views.KullanıcıViews
{
    public partial class KullanıcıListView : UserControl
    {
        UnitOfWork uow = new UnitOfWork();
        BindingSource source = new BindingSource();

        private void YetkiAyarla()
        {
            btnEkle.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.Kullanıcılar && x.Islem == YetkiIslem.Ekleme));
            btnSil.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.Kullanıcılar && x.Islem == YetkiIslem.Silme));
            btnDuzenle.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.Kullanıcılar && x.Islem == YetkiIslem.Güncelleme));
            btnYetkiler.YetkiVisile(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.KullanıcıYetkileri && x.Islem == YetkiIslem.Listeleme));
        }
        public KullanıcıListView()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            YetkiAyarla();
        }

        private void KullanıcıListView_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].HeaderText = "Adı";
            dataGridView1.Columns[0].DataPropertyName = "Ad";
            dataGridView1.Columns[1].HeaderText = "Soyadı";
            dataGridView1.Columns[1].DataPropertyName = "Soyad";
            dataGridView1.Columns[2].HeaderText = "Kullanıcı Adı";
            dataGridView1.Columns[2].DataPropertyName = "KullanıcıAdı";
            dataGridView1.Columns[3].HeaderText = "Kullanıcı Tip";
            dataGridView1.Columns[3].DataPropertyName = "Tip";
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].MinimumWidth = 200;

            source.DataSource = uow.KullanıcıRepo.ToList();
            dataGridView1.DataSource = source;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                FrmKullanıcı kullanıcıFrm = new FrmKullanıcı() { Text = "Yeni Kullanıcı Ekle" };
                if (kullanıcıFrm.ShowDialog() == DialogResult.OK)
                {
                    uow.KullanıcıRepo.Add(kullanıcıFrm.Kullanıcı);
                    source.Add(kullanıcıFrm.Kullanıcı);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Kullanıcı Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (source.Current != null && DialogResult.Yes ==
                MessageBox.Show("Seçili kullanıcıyı silmek istiyor musunuz?", "Kullanıcı Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                uow.KullanıcıRepo.Remove(source.Current as Kullanıcı);
                source.Remove(source.Current);
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (source.Current != null)
            {
                Kullanıcı kullanıcı = source.Current as Kullanıcı;
                Kullanıcı temp = kullanıcı.CopyObject();
                try
                {


                    FrmKullanıcı kullanıcıFrm = new FrmKullanıcı(temp) { Text = "Kullanıcı Düzenle" };
                    string oldUserName = kullanıcıFrm.Kullanıcı.KullanıcıAdı;
                    if (kullanıcıFrm.ShowDialog() == DialogResult.OK)
                    {
                        uow.KullanıcıRepo.Update(kullanıcıFrm.Kullanıcı, oldUserName);
                        kullanıcı.SetKullanıcı(temp);
                        source.ResetBindings(false);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Kullanıcı Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnYetkiler_Click(object sender, EventArgs e)
        {
            if (source.Current != null)
            {
                FrmKullanıcıYetkileri yetkiFrm = new FrmKullanıcıYetkileri((source.Current as Kullanıcı).KullanıcıAdı);
                if (yetkiFrm.ShowDialog() == DialogResult.OK)
                {
                    foreach (var yetki in yetkiFrm.Kullanıcı.Yetkiler)
                    {
                        uow.KullanıcıRepo.YetkiGuncelle(yetki);
                    }
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(source.Current != null && (source.Current as Kullanıcı).Tip == KullanıcıType.DefaultAdmin)
            {
                btnSil.Enabled = false;
                btnDuzenle.Enabled = false;
                btnYetkiler.Enabled = false;
            }
            else
            {
                YetkiAyarla();
            }
        }
    }
}
