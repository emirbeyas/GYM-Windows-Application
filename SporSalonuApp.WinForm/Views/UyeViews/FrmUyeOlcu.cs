using SporSalonuApp.Models.UyeModels;
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
    public partial class FrmUyeOlcu : Form
    {
        public UyeOlcu  Olcu{ get; set; }
        public FrmUyeOlcu(int uye_id):this(new UyeOlcu()){
            Olcu.UyeId = uye_id;
        }
        public FrmUyeOlcu(UyeOlcu olcu)
        {
            InitializeComponent();
            this.Olcu = olcu;
        }

        private void FrmUyeOlcu_Load(object sender, EventArgs e)
        {
            this.dtpTarih.Value = Olcu.Tarih;
            nmBel.Value = Olcu.Bel;
            nmBoy.Value = Olcu.Boy;
            nmGogus.Value = Olcu.Gogus;
            nmKalca.Value = Olcu.Kalca;
            nmKg.Value = Olcu.Kg;
            nmKol.Value = Olcu.Kol;
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            Olcu.Tarih = dtpTarih.Value;
            Olcu.Bel = nmBel.Value;
            Olcu.Boy = nmBoy.Value;
            Olcu.Gogus = nmGogus.Value;
            Olcu.Kalca = nmKalca.Value;
            Olcu.Kg = nmKg.Value;
            Olcu.Kol = nmKol.Value;
        }
    }
}
