using Notes.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Repositories.Infrastructure
{
    public interface IAsyncCrudRepository<DTO, EFM, CTX> : ICrudRepository<DTO, EFM, CTX>
        where DTO : class, new()
        where EFM : class, IEntity, new()
        where CTX : class, IDbContext, new()
    {
        Task<DTO> CreateAsync(DTO entity);
        Task<DTO> ReadAsync(int id);
        Task<DTO> UpdateAsync(DTO entity);
        Task<int> DeleteAsync(DTO entity);
        Task<int> CountAsync();
    }
}
