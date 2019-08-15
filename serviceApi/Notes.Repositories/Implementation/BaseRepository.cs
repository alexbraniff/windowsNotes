using Notes.Data.Model.Notes;
using Notes.Repositories.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Notes.Data.Infrastructure;
using Notes.Data.Implementation;
using System.Data.Entity;
using Ninject;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq.Expressions;

namespace Notes.Repositories.Implementation
{
    public class BaseRepository<DTO, EFM, CTX> : IAsyncCrudRepository<DTO, EFM, CTX>
        where DTO : class, new()
        where EFM : class, IEntity, new()
        where CTX : class, IDbContext, new()
    {
        private CTX _context;

        protected IDbContext Context
        {
            get
            {
                return _context;
            }

            set
            {
                _context = (CTX)value;
            }
        }

        [Inject]
        public BaseRepository(IDbContext context)
        {
            Context = context;
        }

        public DTO Create(DTO dto)
        {
            EFM efm = Mapper.Map<EFM>(dto);
            EFM added = _context.Set<EFM>().Add(efm);
            _context.SaveChanges();
            return Mapper.Map<DTO>(added);
        }

        public async Task<DTO> CreateAsync(DTO dto)
        {
            EFM efm = Mapper.Map<EFM>(dto);
            EFM added = _context.Set<EFM>().Add(efm);
            await _context.SaveChangesAsync();
            return Mapper.Map<DTO>(added);
        }

        public DTO Read(int id)
        {
            EFM read = _context.Set<EFM>().Find(id);
            return Mapper.Map<DTO>(read);
        }

        public IQueryable<DTO> Read()
        {
            IQueryable<EFM> read = _context.Set<EFM>();
            return Mapper.Map<List<DTO>>(read).AsQueryable();
        }

        public async Task<DTO> ReadAsync(int id)
        {
            EFM read = await _context.Set<EFM>().FindAsync(id);
            return Mapper.Map<DTO>(read);
        }

        public DTO Update(DTO dto)
        {
            if (dto == null)
            {
                return null;
            }

            EFM efm = Mapper.Map<EFM>(dto);

            EFM existing = _context.Set<EFM>().Find(efm.Id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(efm);
                _context.SaveChanges();
            }
            return Mapper.Map<DTO>(existing);
        }

        public async Task<DTO> UpdateAsync(DTO dto)
        {
            if (dto == null)
            {
                return null;
            }

            EFM efm = Mapper.Map<EFM>(dto);

            EFM existing = await _context.Set<EFM>().FindAsync(efm.Id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(dto);
                await _context.SaveChangesAsync();
            }
            return Mapper.Map<DTO>(existing);
        }

        public int Delete(DTO dto)
        {
            EFM efm = Mapper.Map<EFM>(dto);
            _context.Set<EFM>().Remove(efm);
            return _context.SaveChanges();
        }

        public async Task<int> DeleteAsync(DTO dto)
        {
            EFM efm = Mapper.Map<EFM>(dto);
            _context.Set<EFM>().Remove(efm);
            return await _context.SaveChangesAsync();
        }

        public int Count()
        {
            return _context.Set<EFM>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<EFM>().CountAsync();
        }
    }
}
