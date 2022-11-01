using SporSalonuApp.Models.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporSalonuApp.Models.EgzersizModels
{
    public class EgzersizKategori : IModel
    {
        public int Id { get; set; }
        public string Ad { get; set; }

        public List<SqlParameter> GetInsertParameters()
        {
            return new List<SqlParameter> { new SqlParameter("@kat_ad", this.Ad) };
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            var items = new List<SqlParameter> { new SqlParameter("@kat_id", this.Id) };
            items.AddRange(GetInsertParameters());
            return items;
        }

        public void ReadItem(IDataRecord record)
        {
            this.Id = (record["kat_id"] == DBNull.Value)? 0 : Convert.ToInt32(record["kat_id"]);
            this.Ad = record["kat_ad"].ToString();
        }
    }
}
