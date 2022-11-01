using SporSalonuApp.Models.UyeModels;
using SporSalonuApp.Models.UyeProgramModels;
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
    public partial class FrmUyeProgram : Form
    {
        public UyeProgram UyeProgram{ get; set; }

        public FrmUyeProgram(int uye_id):this(new UyeProgram() { UyeId = uye_id }){}
        public FrmUyeProgram(UyeProgram uyeProgram)
        {
            InitializeComponent();
            this.UyeProgram = uyeProgram;
        }

        private void FrmUyeProgram_Load(object sender, EventArgs e)
        {
            dtpBasTarih.Value = UyeProgram.BaslangıcTarih;
            dtpBitisTarih.Checked = (UyeProgram.BitisTarih != null) ? true : false;
            if(dtpBitisTarih.Checked) dtpBitisTarih.Value = UyeProgram.BitisTarih.Value;
            chkAktif.Checked = UyeProgram.IsAktif;
            txtAciklama.Text = UyeProgram.Acıklama;

        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            UyeProgram.BaslangıcTarih = dtpBasTarih.Value;
            if (dtpBasTarih.Checked)
                UyeProgram.BitisTarih = dtpBitisTarih.Value;
            else 
                UyeProgram.BitisTarih = null;
            UyeProgram.IsAktif = chkAktif.Checked;
            UyeProgram.Acıklama = txtAciklama.Text;
        }

        private void chkAktif_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAktif.Checked)
                dtpBitisTarih.Checked = false;
            else
                dtpBitisTarih.Checked = true;
        }
    }
}
