using SporSalonuApp.DatabaseAccess.DatabaseContext;
using SporSalonuApp.Models.ReportModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporSalonuApp.DatabaseAccess.Repositories
{
    public class ReportRepo : IDisposable
    {
        public readonly DBContext context;

        public ReportRepo(DBContext context)
        {
            this.context = context;
        }

        public MainViewModel GetMainViewModel()
        {
            using(SqlCommand cmd = context.CreateCommand("sp_main_view_counts"))
            {
                return context.GetItem<MainViewModel>(cmd);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
