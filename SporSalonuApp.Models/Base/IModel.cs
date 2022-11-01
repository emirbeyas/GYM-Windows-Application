using SporSalonuApp.Models.Enums;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SporSalonuApp.Models.Base
{
    public interface IModel
    {
        int Id { get; set; }

        void ReadItem(IDataRecord record);

        List<SqlParameter> GetInsertParameters();
        List<SqlParameter> GetUpdateParameters();
    }
}
