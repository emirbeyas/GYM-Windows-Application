using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SporSalonuApp.WinForm.Models;
using SporSalonuApp.Models.Enums;
using SporSalonuApp.DatabaseAccess;
using SporSalonuApp.DatabaseAccess.DatabaseContext;
using System.Data.SqlClient;
using SporSalonuApp.WinForm.Yedekleme;
using System.Runtime.InteropServices.WindowsRuntime;
using SporSalonuApp.Models.UyeModels;
using System.Windows.Forms.VisualStyles;
using SporSalonuApp.WinForm.Extensions;
using SporSalonuApp.Models.UyeProgramModels;
using SporSalonuApp.Models.EgzersizModels;
using SporSalonuApp.Models.OdemeModels;

namespace SporSalonuApp.WinForm.Views.YedekViews
{
    public partial class YedekView : UserControl
    {
        UnitOfWork uow = new UnitOfWork();
        BindingSource source = new BindingSource();

        public string TableName { get; set; }
        public string SelectQuery { get { return "SELECT * FROM " + this.TableName; } }

        public YedekView()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        private void YedekView_Load(object sender, EventArgs e)
        {
            cbxTablo.DataSource = new List<ComboBoxModel>
            {
                new ComboBoxModel{Id = Convert.ToInt32(DbTablo.Uyeler), Name = "Üyeler"},
                new ComboBoxModel{Id = Convert.ToInt32(DbTablo.UyeOlculeri), Name = "Üye Ölçüleri"},
                new ComboBoxModel{Id = Convert.ToInt32(DbTablo.UyeProgramları), Name = "Üye Programları"},
                new ComboBoxModel{Id = Convert.ToInt32(DbTablo.Egzersizler), Name = "Egzersizler"},
                new ComboBoxModel{Id = Convert.ToInt32(DbTablo.EgzersizKategorileri), Name = "Egzersiz Katgorileri"},
                new ComboBoxModel{Id = Convert.ToInt32(DbTablo.ProgramEgzersizleri), Name = "Program Egzersizleri"},
                new ComboBoxModel{Id = Convert.ToInt32(DbTablo.Odemeler), Name = "Ödemeler"}
                //new ComboBoxModel{Id = Convert.ToInt32(DbTablo.Kullanıcılar), Name = "Kullanıcılar"},
                //new ComboBoxModel{Id = Convert.ToInt32(DbTablo.KullanıcıYetkileri), Name = "Kullanıcı Yetkileri"}
            };

            cbxTablo.DisplayMember = "Name";
            cbxTablo.ValueMember = "Id";

            dataGridView1.DataSource = source;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            DataTable dbTable = new DataTable();
            DbTablo table = (DbTablo)cbxTablo.SelectedValue;
            using (DBContext context = new DBContext())
            {
                switch (table)
                {
                    case DbTablo.Uyeler:
                        this.TableName = "tblUyeler";
                        break;
                    case DbTablo.UyeOlculeri:
                        this.TableName = "tblUyeOlculeri";
                        break;
                    case DbTablo.UyeProgramları:
                        this.TableName = "tblUyeProgramlari";
                        break;
                    case DbTablo.ProgramEgzersizleri:
                        this.TableName = "tblProgramEgzersizleri";
                        break;
                    case DbTablo.Odemeler:
                        this.TableName = "tblOdemeler";
                        break;
                    //case DbTablo.Kullanıcılar:
                    //    this.TableName = "tblKullanicilar";
                    //    break;
                    //case DbTablo.KullanıcıYetkileri:
                    //    this.TableName = "tblKullaniciYetkileri";
                    //    break;
                    case DbTablo.Egzersizler:
                        this.TableName = "tblEgzersizler";
                        break;
                    case DbTablo.EgzersizKategorileri:
                        this.TableName = "tblEgzersizKategorileri";
                        break;
                }

                using (SqlCommand cmd = context.CreateCommand(this.SelectQuery, CommandType.Text))
                {
                    context.OpenConnection();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dbTable.Load(reader);
                    reader.Close();
                    context.CloseConnection();
                    source.DataSource = dbTable;
                }
                lblDısaAktarSatırAdet.Text = "Satır Sayısı : " + dbTable.Rows.Count;
                lblDısaAktarTabloAdı.Text = "Tablo Adı : " + ((ComboBoxModel)cbxTablo.SelectedItem).Name;
                btnDısaAktar.Enabled = (dbTable.Rows.Count > 0);
            }
        }

        private void btnDısaAktar_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "CSV File|*.csv";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    IceDısaAktar.DısaAktar(source.DataSource as DataTable, TableName, dialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Dışa Aktarma Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAc_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "CSV File|*.csv";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtDosyaYol.Text = dialog.FileName;
                    DataTable table = IceDısaAktar.IceAktar(dialog.FileName);
                    lblIceAktarSatırAdet.Text = "Satır Adet : " + table.Rows.Count;
                    lblIceAktarTabloAdı.Text = "Tablo Adı : " + table.TableName;
                    dataGridView2.DataSource = table;
                    btnIceAktar.Enabled = (table.Rows.Count > 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "İçe Aktarma Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIceAktar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = dataGridView2.DataSource as DataTable;

                if (table.TableName == "tblUyeler")
                {
                    List<Uye> items = table.GetUyeList();
                    if (DialogResult.Yes == MessageBox.Show(items.Count + " adet üye bilgisi içeri aktarılacak.\nOnaylıyor musunuz?", "Üyeleri İçe Aktar", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        foreach (Uye uye in items)
                        {
                            uow.UyeRepo.Add(uye);
                        }
                        MessageBox.Show("Üyelerin içe aktarımı başarılı şekilde tamamlandı.", "İçe Aktar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (table.TableName == "tblUyeOlculeri")
                {
                    List<UyeOlcu> items = table.GetUyeOlcuList();
                    if (DialogResult.Yes == MessageBox.Show(items.Count + " adet üye ölçü bilgisi içeri aktarılacak. Üye Id bilgisi bulunmaması hataya sebep olabilir.\nOnaylıyor musunuz?", "Üye Ölçülerini İçe Aktar", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        foreach (UyeOlcu item in items)
                        {
                            uow.UyeOlcuRepo.Add(item);
                        }
                        MessageBox.Show("Üye Ölçülerinin içe aktarımı başarılı şekilde tamamlandı.", "İçe Aktar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else if (table.TableName == "tblUyeProgramlari")
                {
                    List<UyeProgram> items = table.GetUyeProgramList();
                    if (DialogResult.Yes == MessageBox.Show(items.Count + " adet üye program bilgisi içeri aktarılacak. Üye Id bilgisi bulunmaması hataya sebep olabilir.\nOnaylıyor musunuz?", "Üye Programları İçe Aktar", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        foreach (UyeProgram item in items)
                        {
                            uow.UyeProgRepo.Add(item);
                        }
                        MessageBox.Show("Üye Programlarının içe aktarımı başarılı şekilde tamamlandı.", "İçe Aktar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (table.TableName == "tblEgzersizler")
                {
                    List<Egzersiz> items = table.GetEgzersizList();
                    if (DialogResult.Yes == MessageBox.Show(items.Count + " adet egzersiz bilgisi içeri aktarılacak. Egzersiz Kategori Id bilgisi bulunmaması hataya sebep olabilir.\nOnaylıyor musunuz?", "Egzersizleri İçe Aktar", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        foreach (Egzersiz item in items)
                        {
                            uow.EgzersizRepo.Add(item);
                        }
                        MessageBox.Show("Egzersizlerin içe aktarımı başarılı şekilde tamamlandı.", "İçe Aktar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (table.TableName == "tblEgzersizKategorileri")
                {
                    List<EgzersizKategori> items = table.GetEgzersizKategoriList();
                    if (DialogResult.Yes == MessageBox.Show(items.Count + " adet egzersiz kategori bilgisi içeri aktarılacak.\nOnaylıyor musunuz?", "Egzersiz Kategorileri İçe Aktar", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        foreach (EgzersizKategori item in items)
                        {
                            uow.EgzersizKategoriRepo.Add(item);
                        }
                        MessageBox.Show("Egzersiz Kategorilerinin içe aktarımı başarılı şekilde tamamlandı.", "İçe Aktar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (table.TableName == "tblOdemeler")
                {
                    List<Odeme> items = table.GetOdemeList();
                    if (DialogResult.Yes == MessageBox.Show(items.Count + " adet Ödeme bilgisi içeri aktarılacak. Üye Id bilgisi bulunmaması hataya sebep olabilir.\nOnaylıyor musunuz?", "Ödemeleri İçe Aktar", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        foreach (Odeme item in items)
                        {
                            uow.OdemeRepo.Add(item);
                        }
                        MessageBox.Show("Ödemelerin içe aktarımı başarılı şekilde tamamlandı.", "İçe Aktar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (table.TableName == "tblProgramEgzersizleri")
                {
                    List<ProgramEgzersiz> items = table.GetProgramEgzersizleri();
                    if (DialogResult.Yes == MessageBox.Show(items.Count + " adet program egzersizi bilgisi içeri aktarılacak. Program Id ve Egzersiz Id bilgisi bulunmaması hataya sebep olabilir.\nOnaylıyor musunuz?", "Program Egzersizleri İçe Aktar", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        foreach (ProgramEgzersiz item in items)
                        {
                            uow.ProgramEgzersizRepo.Add(item);
                        }
                        MessageBox.Show("Program Egzersizlerinin içe aktarımı başarılı şekilde tamamlandı.", "İçe Aktar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Tablo adı okunmadı ya da geçersiz tablo adı...", "İçe Aktar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "İçe Aktarma Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnYedekle_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Backup Files|*.bak";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                using(DBContext context = new DBContext())
                {
                    using(SqlCommand cmd = context.CreateCommand("BACKUP DATABASE "+context.Connection.Database +" TO DISK = @filepath", CommandType.Text))
                    {
                        cmd.Parameters.AddWithValue("@filepath", dialog.FileName);
                        context.OpenConnection();
                        cmd.ExecuteNonQuery();
                        context.CloseConnection();

                        MessageBox.Show("Veritabanı yedeğiniz oluşturuldu.", "Database Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnYedektenDon_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Backup Files|*.bak";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (DBContext context = new DBContext())
                {
                    string query = "ALTER DATABASE [" + context.Connection.Database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;" +
                        "USE MASTER RESTORE DATABASE [" + context.Connection.Database + "] FROM DISK= @filepath  WITH REPLACE;" +
                        "ALTER DATABASE[" + context.Connection.Database + "] SET MULTI_USER";

                    using (SqlCommand cmd = context.CreateCommand(query, CommandType.Text))
                    {
                        cmd.Parameters.AddWithValue("@filepath", dialog.FileName);
                        context.OpenConnection();
                        cmd.ExecuteNonQuery();
                        context.CloseConnection();

                        MessageBox.Show("Veritabanı yedeğinizden geri dönüldü", "Database Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
