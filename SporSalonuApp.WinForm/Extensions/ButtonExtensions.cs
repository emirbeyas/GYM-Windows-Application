using SporSalonuApp.Models.KullanıcıModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SporSalonuApp.WinForm.Extensions
{
    public static class ButtonExtensions
    {
        public static void YetkiVisible(this Button btn, KullanıcıYetki yetki)
        {
            btn.Visible = yetki.YetkiliMi;
        }

        public static void YetkiVisile(this ToolStripButton btn, KullanıcıYetki yetki)
        {
            btn.Enabled = yetki.YetkiliMi;
        }
    }
}
