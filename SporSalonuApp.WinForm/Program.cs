using SporSalonuApp.DatabaseAccess;
using SporSalonuApp.Models.KullanıcıModels;
using SporSalonuApp.WinForm.Views.KullanıcıViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SporSalonuApp.WinForm
{
    static class Program
    {
        public static Kullanıcı Kullanıcı{ get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //try
            //{
            //    using (UnitOfWork uow = new UnitOfWork())
            //        Program.Kullanıcı = uow.KullanıcıRepo.GetItem("Admin");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Spor Salonu App", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //Application.Run(new MainForm());

            FrmLogin loginFrm = new FrmLogin();
            if (loginFrm.ShowDialog() == DialogResult.OK)
            {
                using (UnitOfWork uow = new UnitOfWork())
                    Program.Kullanıcı = uow.KullanıcıRepo.GetItem(loginFrm.KullanıcıAdı);
                Application.Run(new MainForm());
            }
        }
    }
}
