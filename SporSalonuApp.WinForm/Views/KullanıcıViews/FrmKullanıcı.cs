using SporSalonuApp.Models.Enums;
using SporSalonuApp.Models.KullanıcıModels;
using SporSalonuApp.WinForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SporSalonuApp.WinForm.Views.KullanıcıViews
{
    public partial class FrmKullanıcı : Form
    {
        public Kullanıcı Kullanıcı { get; set; }

        public FrmKullanıcı():this(new Kullanıcı()){ }

        public FrmKullanıcı(Kullanıcı kullanıcı)
        {
            InitializeComponent();
            this.Kullanıcı = kullanıcı;
        }

        private void FrmKullanıcı_Load(object sender, EventArgs e)
        {
            cbxTipler.DataSource = new List<ComboBoxModel>
            {
                new ComboBoxModel{Id = (int)KullanıcıType.User, Name = "User"},
                new ComboBoxModel{Id = (int)KullanıcıType.Admin, Name="Admin"}
            };
            cbxTipler.DisplayMember = "Name";
            cbxTipler.ValueMember = "Id";

            txtAd.Text = Kullanıcı.Ad;
            txtSoyad.Text = Kullanıcı.Soyad;
            cbxTipler.SelectedValue = (int)Kullanıcı.Tip;
            txtKullanıcıadı.Text = Kullanıcı.KullanıcıAdı;
            txtParola.Text = txtParolaTekrar.Text = Kullanıcı.Parola;
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            if(ValidationKontrol())
            {
                Kullanıcı.Ad = txtAd.Text;
                Kullanıcı.Soyad = txtSoyad.Text;
                Kullanıcı.Tip = (KullanıcıType)cbxTipler.SelectedValue;
                Kullanıcı.KullanıcıAdı = txtKullanıcıadı.Text;
                Kullanıcı.Parola = txtParola.Text;

                this.DialogResult = DialogResult.OK;
            }
        }

        #region Validation Kontrolleri...
        private bool ValidationKontrol()
        {
            bool adKontrol = AdKontrol();
            bool soyadKontrol = SoyadKontrol();
            bool kullanıcıAdıKontrol = KullanıcıAdıKontrol();
            bool parolaKontrol = ParolaKontrol();
            bool parolaTekrarKontrol = ParolaTekrarKontrol();


            return adKontrol && soyadKontrol && kullanıcıAdıKontrol && parolaKontrol && parolaTekrarKontrol;
        }

        private bool AdKontrol()
        {
            if (String.IsNullOrEmpty(txtAd.Text))
            {
                errorProvider1.SetError(txtAd, "Ad alanı boş geçilemez");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtAd, "");
                return true;
            }
        }

        private bool SoyadKontrol()
        {
            if (String.IsNullOrEmpty(txtSoyad.Text))
            {
                errorProvider1.SetError(txtSoyad, "Soyad alanı boş geçilemez");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtSoyad, "");
                return true;
            }
        }

        private bool KullanıcıAdıKontrol()
        {
            if (String.IsNullOrEmpty(txtKullanıcıadı.Text))
            {
                errorProvider1.SetError(txtKullanıcıadı, "Kullanıcı Adı alanı boş geçilemez");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtKullanıcıadı, "");
                return true;
            }
        }

        private bool ParolaKontrol()
        {
            if (String.IsNullOrEmpty(txtParola.Text))
            {
                errorProvider1.SetError(txtParola, "Parola alanı boş geçilemez");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtParola, "");
                return true;
            }
        }

        private bool ParolaTekrarKontrol()
        {
            if (txtParola.Text.Trim() != txtParolaTekrar.Text.Trim())
            {
                errorProvider1.SetError(txtParolaTekrar, "Parola ile Tekrarı aynı olmalıdır");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtParolaTekrar, "");
                return true;
            }
        } 
        #endregion
    }
}
