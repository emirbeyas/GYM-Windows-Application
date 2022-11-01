using SporSalonuApp.DatabaseAccess.DatabaseContext;
using SporSalonuApp.DatabaseAccess.Repositories;
using SporSalonuApp.Models.UyeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporSalonuApp.DatabaseAccess
{
    public class UnitOfWork : IDisposable
    {
        private DBContext context;

        private UyeRepo uye_repo;
        private UyeOlcuRepo uyeOlcu_repo;
        private EgzersizKategoriRepo egzersizKategori_repo;
        private EgzersizRepo egzersiz_repo;
        private UyeProgramRepo uyeProg_repo;
        private ProgramEgzersizRepo progEgzersiz_repo;
        private OdemeRepo odeme_repo;
        private KullanıcıRepo kullanıcı_repo;
        private ReportRepo report_repo;
        public UyeRepo UyeRepo
        {
            get
            {
                if (uye_repo == null)
                    uye_repo = new UyeRepo(context);
                return uye_repo;
            }
        }

        public UyeOlcuRepo UyeOlcuRepo
        {
            get
            {
                if (uyeOlcu_repo == null)
                    uyeOlcu_repo = new UyeOlcuRepo(context);
                return uyeOlcu_repo;
            }
        }

        public EgzersizKategoriRepo EgzersizKategoriRepo
        {
            get
            {
                if (egzersizKategori_repo == null)
                    egzersizKategori_repo = new EgzersizKategoriRepo(context);
                return egzersizKategori_repo;
            }
        }

        public EgzersizRepo EgzersizRepo
        {
            get
            {
                if (egzersiz_repo == null)
                    egzersiz_repo = new EgzersizRepo(context);
                return egzersiz_repo;
            }
        }

        public UyeProgramRepo UyeProgRepo
        {
            get
            {
                if (uyeProg_repo == null)
                    uyeProg_repo = new UyeProgramRepo(context);
                return uyeProg_repo;
            }
        }

        public ProgramEgzersizRepo ProgramEgzersizRepo
        {
            get
            {
                if (progEgzersiz_repo == null)
                    progEgzersiz_repo = new ProgramEgzersizRepo(context);
                return progEgzersiz_repo;
            }
        }

        public OdemeRepo OdemeRepo
        {
            get
            {
                if (odeme_repo == null)
                    odeme_repo = new OdemeRepo(context);
                return odeme_repo;
            }
        }

        public KullanıcıRepo KullanıcıRepo
        {
            get
            {
                if (kullanıcı_repo == null)
                    kullanıcı_repo = new KullanıcıRepo(context);
                return kullanıcı_repo;
            }
        }

        public ReportRepo ReportRepo
        {
            get
            {
                if (report_repo == null)
                    report_repo = new ReportRepo(context);
                return report_repo;
            }
        }

        public UnitOfWork()
        {
            context = new DBContext();
        }

        public void Dispose()
        {
            context?.Dispose();
            uye_repo?.Dispose();
            uyeOlcu_repo?.Dispose();
            uyeProg_repo?.Dispose();
            egzersizKategori_repo?.Dispose();
            egzersiz_repo?.Dispose();
            progEgzersiz_repo?.Dispose();
            odeme_repo?.Dispose();
            report_repo?.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
