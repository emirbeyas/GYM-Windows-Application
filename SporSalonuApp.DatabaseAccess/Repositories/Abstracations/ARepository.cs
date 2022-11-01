using SporSalonuApp.DatabaseAccess.DatabaseContext;
using SporSalonuApp.Models.Base;
using System;
using System.Collections.Generic;

namespace SporSalonuApp.DatabaseAccess.Abstracations.Repositories
{
    public abstract class ARepository<T> : IDisposable where T : IModel
    {
        public readonly DBContext context;

        public ARepository(DBContext context)
        {
            this.context = context;
        }

        public abstract object Add(T item);

        public abstract T GetItem(object key);

        public abstract int Remove(object key);

        public abstract int Remove(T item);

        public abstract List<T> ToList();

        public abstract int Update(T item);

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
