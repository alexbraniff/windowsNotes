using Ninject;
using Notes.BusinessObjects.DataTransferObjects.Audit;
using Notes.BusinessObjects.DataTransferObjects.Notes;
using Notes.BusinessObjects.DataTransferObjects.Users;
using Notes.BusinessObjects.WebApiModels;
using Notes.Repositories.Implementation.Audit;
using Notes.Repositories.Implementation.Notes;
using Notes.Repositories.Implementation.Organizations;
using Notes.Repositories.Implementation.Projects;
using Notes.Repositories.Implementation.Users;
using Notes.Security.Authentication;
using Notes.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Notes.API.Controllers
{
    public class DashboardController : ApiController
    {
        private readonly NoteRepository NoteRepo;
        private readonly OrganizationRepository OrganizationRepo;
        private readonly ProjectRepository ProjectRepo;
        private readonly AuditAddRepository AuditAddRepo;
        private IQueryable<AuditAddDto> AddHistory;
        private readonly UserRepository UserRepo;
        private readonly IAuthenticationService Auth;

        private UserDto CurrentUser { get; set; }

        public DashboardController(NoteRepository noteRepo, AuditAddRepository auditAddRepo, UserRepository userRepo, OrganizationRepository orgRepo, ProjectRepository projectRepo, IAuthenticationService auth)
        {
            NoteRepo = noteRepo;

            OrganizationRepo = orgRepo;

            ProjectRepo = projectRepo;

            AuditAddRepo = auditAddRepo;

            UserRepo = userRepo;

            Auth = auth;
        }


        private static PingModel ParseTokenHeader(HttpRequestMessage request)
        {
            string authHeader = null;
            var auth = request.Headers.Authorization;
            if (auth != null && auth.Scheme == "Bearer")
                authHeader = auth.Parameter;

            if (string.IsNullOrEmpty(authHeader))
                return null;

            return new PingModel
            {
                Token = authHeader
            };
        }

        private bool GiveMeAUserDto_IfThisMotherFuckerHasAGodDamnToken_AKA_WhatWouldHaveBeenMyAuthenticationFilterAttribute(out UserDto user) {
            HttpRequestMessage request = Request;

            user = null;

            try
            {
                PingModel pingModel = ParseTokenHeader(request);
                user = Auth.Ping(pingModel.Token);
            }
            catch (Exception x)
            {
                return false;
            }

            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // GET: Dashboard
        [HttpGet]
        [Route("api/Dashboard/Notes")]
        public IHttpActionResult Notes()
        {
            try
            {
                UserDto user;

                if (!GiveMeAUserDto_IfThisMotherFuckerHasAGodDamnToken_AKA_WhatWouldHaveBeenMyAuthenticationFilterAttribute(out user))
                {
                    throw new Exception("This mother fucker need a god damn token");
                }

                CurrentUser = user;

                AddHistory = AuditAddRepo.Read().Where(auditAdd => auditAdd.UserId == CurrentUser.Id);

                var t = NoteRepo.Read().Where(note => AddHistory.Any(auditAdd => auditAdd.Entity == "Note" && auditAdd.EntityId == note.Id)).ToList();
                return Ok(t);
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }

        // GET: Dashboard
        [HttpGet]
        [Route("api/Dashboard/CreateNote")]
        public IHttpActionResult CreateNote()
        {
            try
            {
                UserDto user;

                if (!GiveMeAUserDto_IfThisMotherFuckerHasAGodDamnToken_AKA_WhatWouldHaveBeenMyAuthenticationFilterAttribute(out user))
                {
                    throw new Exception("This mother fucker need a god damn token");
                }

                CurrentUser = user;

                return Ok(NoteRepo.Create(new NoteDto()));
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }
        
        [HttpPost]
        [Route("api/Dashboard/UpdateNote")]
        public IHttpActionResult UpdateNote(NoteDto note)
        {
            try
            {
                UserDto user;

                if (!GiveMeAUserDto_IfThisMotherFuckerHasAGodDamnToken_AKA_WhatWouldHaveBeenMyAuthenticationFilterAttribute(out user))
                {
                    throw new Exception("This mother fucker need a god damn token");
                }

                CurrentUser = user;

                AddHistory = AuditAddRepo.Read().Where(auditAdd => auditAdd.UserId == CurrentUser.Id);

                if (!AddHistory.Any(add => add.Entity == "Note" && add.EntityId == note.Id && add.UserId == CurrentUser.Id))
                {
                    throw new Exception("This mother fucker didnt make this note");
                }

                return Ok(NoteRepo.Update(note));
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }

        // GET: Dashboard
        [HttpGet]
        [Route("api/Dashboard/Organizations")]
        public IHttpActionResult Organizations()
        {
            try
            {
                UserDto user;

                if (!GiveMeAUserDto_IfThisMotherFuckerHasAGodDamnToken_AKA_WhatWouldHaveBeenMyAuthenticationFilterAttribute(out user))
                {
                    throw new Exception("This mother fucker need a god damn token");
                }

                CurrentUser = user;

                AddHistory = AuditAddRepo.Read().Where(auditAdd => auditAdd.UserId == CurrentUser.Id);

                return Ok(OrganizationRepo.Read().Where(org => AddHistory.Any(auditAdd => auditAdd.Entity == "Organization" && auditAdd.EntityId == org.Id)).ToList());
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }

        // GET: Dashboard
        [HttpGet]
        [Route("api/Dashboard/Projects")]
        public IHttpActionResult Projects()
        {
            try
            {
                UserDto user;

                if (!GiveMeAUserDto_IfThisMotherFuckerHasAGodDamnToken_AKA_WhatWouldHaveBeenMyAuthenticationFilterAttribute(out user))
                {
                    throw new Exception("This mother fucker need a god damn token");
                }

                CurrentUser = user;

                AddHistory = AuditAddRepo.Read().Where(auditAdd => auditAdd.UserId == CurrentUser.Id);

                return Ok(ProjectRepo.Read().Where(project => AddHistory.Any(auditAdd => auditAdd.Entity == "Project" && auditAdd.EntityId == project.Id)).ToList());
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }
    }
}