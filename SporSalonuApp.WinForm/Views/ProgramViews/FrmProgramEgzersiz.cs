using SporSalonuApp.DatabaseAccess;
using SporSalonuApp.Models.EgzersizModels;
using SporSalonuApp.Models.Enums;
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

namespace SporSalonuApp.WinForm.Views.ProgramViews
{
    public partial class FrmProgramEgzersiz : Form
    {
        public ProgramEgzersiz ProgramEgzersiz { get; set; }

        UnitOfWork uow = new UnitOfWork();

        public FrmProgramEgzersiz(int prog_id):this(new ProgramEgzersiz() { ProgramId = prog_id  }){}

        public FrmProgramEgzersiz(ProgramEgzersiz programEgzersiz)
        {
            InitializeComponent();
            this.ProgramEgzersiz = programEgzersiz;
        }

        private void FrmProgramEgzersiz_Load(object sender, EventArgs e)
        {
            cbxGun.DataSource = Enum.GetValues(typeof(GunAdi));
            cbxKategori.DataSource = uow.EgzersizKategoriRepo.ToList();
            cbxKategori.DisplayMember = "Ad";
            cbxKategori.ValueMember = "Id";

            cbxGun.SelectedItem = ProgramEgzersiz.Gun;
            cbxKategori.SelectedValue = ProgramEgzersiz.Egzersiz.Kategori.Id;
            cbxEgzersiz.SelectedValue = ProgramEgzersiz.Egzersiz.Id;
            
            nmSetAdet.Value = ProgramEgzersiz.SetAdet;
            nmTekrarSayısı.Value = ProgramEgzersiz.TekrarSayısı;
        }

        private void cbxKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxKategori.SelectedItem != null)
            {
                EgzersizKategori kat = cbxKategori.SelectedItem as EgzersizKategori;

                cbxEgzersiz.DataSource = uow.EgzersizRepo.ToList(kat.Id);
                cbxEgzersiz.DisplayMember = "Ad";
                cbxEgzersiz.ValueMember = "Id";
            }

        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            ProgramEgzersiz.Gun = (GunAdi)cbxGun.SelectedItem;
            ProgramEgzersiz.Egzersiz.Kategori = cbxKategori.SelectedItem as EgzersizKategori;
            ProgramEgzersiz.Egzersiz = cbxEgzersiz.SelectedItem as Egzersiz;
            ProgramEgzersiz.SetAdet = Convert.ToInt32(nmSetAdet.Value);
            ProgramEgzersiz.TekrarSayısı = Convert.ToInt32(nmTekrarSayısı.Value);
        }
    }
}
