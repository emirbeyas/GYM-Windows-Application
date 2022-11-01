using FontAwesome.Sharp;
using SporSalonuApp.Models.Enums;
using SporSalonuApp.WinForm.Extensions;
using SporSalonuApp.WinForm.Views;
using SporSalonuApp.WinForm.Views.EgzersizViews;
using SporSalonuApp.WinForm.Views.KullanıcıViews;
using SporSalonuApp.WinForm.Views.OdemeViews;
using SporSalonuApp.WinForm.Views.YedekViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SporSalonuApp.WinForm
{
    public partial class MainForm : Form
    {
        private void YetkiAyarla()
        {
            //menuUyeler.YetkiVisible(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.Uyeler && x.Islem == YetkiIslem.Listeleme));
            //menuOdemeler.YetkiVisible(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.Odemeler && x.Islem == YetkiIslem.Listeleme));
            //menuEgzersizler.YetkiVisible(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.Egzersizler && x.Islem == YetkiIslem.Listeleme));
            //menuEgzersizKategori.YetkiVisible(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.EgzersizKategorileri && x.Islem == YetkiIslem.Listeleme));
            //menuKullanıcılar.YetkiVisible(Program.Kullanıcı.Yetkiler.FirstOrDefault(x => x.Tablo == DbTablo.Kullanıcılar && x.Islem == YetkiIslem.Listeleme));

            ////yedek işlemleri ve ana sayfa admine bırakılabilir?
            //menuYedekIslemleri.Visible = (Program.Kullanıcı.Tip == KullanıcıType.DefaultAdmin || Program.Kullanıcı.Tip == KullanıcıType.Admin);
        }
        public MainForm()
        {
            //InitializeComponent();
            //if(Program.Kullanıcı != null)
            //    YetkiAyarla();
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            IconButton btn = sender as IconButton;
            if (btn.Name == menuAnaSayfa.Name)
            {
                pnlContainer.Controls.Clear();
                pnlContainer.Controls.Add(new MainView());
                lblActive.Top = btn.Top;
            }
            else if (btn.Name == menuUyeler.Name)
            {
                pnlContainer.Controls.Clear();
                pnlContainer.Controls.Add(new UyeListView());
                lblActive.Top = btn.Top;
            }
            else if (btn.Name == menuEgzersizler.Name)
            {
                pnlContainer.Controls.Clear();
                pnlContainer.Controls.Add(new EgzersizListView());
                lblActive.Top = btn.Top;
            }
            else if (btn.Name == menuEgzersizKategori.Name)
            {
                FrmEgzersizKategoriList kategoriListFrm = new FrmEgzersizKategoriList();
                kategoriListFrm.ShowDialog();
            }
            else if (btn.Name == menuOdemeler.Name)
            {
                pnlContainer.Controls.Clear();
                pnlContainer.Controls.Add(new OdemeListView());
                lblActive.Top = btn.Top;
            }
            else if (btn.Name == menuKullanıcılar.Name)
            {
                pnlContainer.Controls.Clear();
                lblActive.Top = btn.Top;
                pnlContainer.Controls.Add(new KullanıcıListView());
            }
            else if (btn.Name == menuYedekIslemleri.Name)
            {
                pnlContainer.Controls.Clear();
                lblActive.Top = btn.Top;
                pnlContainer.Controls.Add(new YedekView());
            }

        }

        private void mainView1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
