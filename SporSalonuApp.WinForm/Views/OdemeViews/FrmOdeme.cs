using SporSalonuApp.DatabaseAccess;
using SporSalonuApp.Models.OdemeModels;
using SporSalonuApp.Models.UyeModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SporSalonuApp.WinForm.Views.OdemeViews
{
    public partial class FrmOdeme : Form
    {
        UnitOfWork uow = new UnitOfWork();
        BindingSource source = new BindingSource();


        public Odeme Odeme{ get; set; }

        public FrmOdeme() : this(new Odeme()){}

        public FrmOdeme(Odeme odeme)
        {
            InitializeComponent();
            this.Odeme = odeme;
        }

        private void FrmOdeme_Load(object sender, EventArgs e)
        {
            source.DataSource = uow.UyeRepo.ToList();
            cbxUye.DataSource = source;
            cbxUye.DisplayMember = "AdSoyad";
            cbxUye.ValueMember = "Id";

            cbxUye.SelectedItem = Odeme.Uye;
            dtpTarih.Value = this.Odeme.TarihSaat;
            dtpSaat.Value = this.Odeme.TarihSaat;
            nmOdenenAyAdet.Value = Odeme.OdenenAyAdet;
            nmTutar.Value = Odeme.Ucret;
        }


        private void btnTamam_Click(object sender, EventArgs e)
        {
            if (ValidationKontrol())
            {
                this.Odeme.Uye = cbxUye.SelectedItem as Uye;
                this.Odeme.TarihSaat = new DateTime(dtpTarih.Value.Year, dtpTarih.Value.Month, dtpTarih.Value.Day, dtpSaat.Value.Hour, dtpSaat.Value.Minute, dtpSaat.Value.Second);
                this.Odeme.OdenenAyAdet = Convert.ToInt32(nmOdenenAyAdet.Value);
                this.Odeme.Ucret = nmTutar.Value;

                this.DialogResult = DialogResult.OK;
            }
        }

        #region Validations...
        private bool ValidationKontrol()
        {
            bool uye = UyeKontrol();
            bool ay = AyKontrol();
            bool tutar = TutarKontrol();
            return uye && ay && tutar;
        }
        private bool UyeKontrol()
        {
            if(cbxUye.SelectedItem == null)
            {
                errorProvider1.SetError(cbxUye, "Üye seçimi yapmalısınız!!!");
                return false;
            }
            else
            {
                errorProvider1.SetError(cbxUye, "");
                return true;
            }
        }
        private bool AyKontrol()
        {
            if(nmOdenenAyAdet.Value == 0)
            {
                errorProvider1.SetError(nmOdenenAyAdet, "Ödeme yapılan ay adet sıfır girilemez!");
                return false;
            }
            else
            {
                errorProvider1.SetError(nmOdenenAyAdet, "");
                return true;
            }
        }

        private bool TutarKontrol()
        {
            if (nmTutar.Value == 0)
            {
                errorProvider1.SetError(nmTutar, "Ödeme yapılan Tutar sıfır girilemez!");
                return false;
            }
            else
            {
                errorProvider1.SetError(nmTutar, "");
                return true;
            }
        }
        #endregion
    }
}
