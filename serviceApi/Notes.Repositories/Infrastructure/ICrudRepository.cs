using Notes.Data.Infrastructure;
using System;
using System.Linq;

namespace Notes.Repositories.Infrastructure
{
    public interface ICrudRepository<DTO, EFT, CTX>
        where DTO : class, new()
        where EFT : class, IEntity, new()
        where CTX : class, IDbContext, new()
    {
        DTO Create(DTO entity);
        DTO Read(int Id);
        IQueryable<DTO> Read();
        DTO Update(DTO entity);
        int Delete(DTO entity);
        int Count();
    }
}
