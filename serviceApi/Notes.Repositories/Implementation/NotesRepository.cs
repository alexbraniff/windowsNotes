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
    public class NotesRepository<DTO, EFM> : BaseRepository<DTO, EFM, NotesContext>
        where DTO : class, new()
        where EFM : class, IEntity, new()
    {
        public NotesRepository(IDbContext context) : base(context)
        {
        }
    }
}
