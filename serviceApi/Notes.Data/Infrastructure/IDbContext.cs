using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Data.Infrastructure
{
    public interface IDbContext
    {
        DbSet<T> Set<T>()
            where T : class;

        DbEntityEntry<T> Entry<T>(T entity)
            where T : class;

        int SaveChanges();

        Task<int> SaveChangesAsync();

        void Dispose();
    }
}
