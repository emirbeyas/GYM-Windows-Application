using SporSalonuApp.Models.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporSalonuApp.Models.ReportModels
{
    public class MainViewModel : IModel
    {
        public int UyeAdet { get; set; }
        public int EgzersizAdet { get; set; }
        public int AktifProgramAdet { get; set; }
        public int KullanıcıAdet { get; set; }
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<SqlParameter> GetInsertParameters()
        {
            throw new NotImplementedException();
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            throw new NotImplementedException();
        }

        public void ReadItem(IDataRecord record)
        {
            this.UyeAdet = Convert.ToInt32(record["uye_count"]);
            this.EgzersizAdet = Convert.ToInt32(record["egzersiz_count"]);
            this.AktifProgramAdet = Convert.ToInt32(record["aktif_prog_count"]);
            this.KullanıcıAdet = Convert.ToInt32(record["kullanici_count"]);
        }
    }
}
