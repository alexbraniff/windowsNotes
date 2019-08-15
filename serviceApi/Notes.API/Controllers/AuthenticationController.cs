using Ninject;
using Notes.BusinessObjects.DataTransferObjects.Users;
using Notes.BusinessObjects.WebApiModels;
using Notes.Repositories.Implementation.Users;
using Notes.Security.Authentication;
using Notes.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace Notes.API.Areas.api.Controllers
{
    public class AuthenticationController : ApiController
    {
        private IAuthenticationService Authentication { get; set; }

        private UserRepository Users { get; set; }

        public AuthenticationController(IAuthenticationService auth, UserRepository users)
        {
            Authentication = auth;
            Users = users;
        }

        private void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
        }

        private IPrincipal MakePrincipal(UserDto user)
        {
            return new NotesPrincipal
            {
                Identity = new NotesIdentity(user.Name, user.OrganizationRoles.Select(e => e.OrganizationRole.Role.Name) as ICollection<string>)
            };
        }
        
        [HttpPost]
        [Route("api/Authentication/Login")]
        public IHttpActionResult Login([FromBody] AuthenticationModel authModel)
        {
            if (authModel == null)
            {
                return BadRequest("Login requires username and either password or password hash and salt");
            }

            try
            {
                UserDto user = Authentication.Authenticate(authModel.Username, authModel.PasswordHash ?? authModel.Password, authModel.PasswordSalt);
                SetPrincipal(MakePrincipal(user));
                return Ok(user);
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }
        
        [HttpPost]
        [Route("api/Authentication/Register")]
        public IHttpActionResult Register([FromBody] AuthenticationModel authModel)
        {
            if (authModel == null)
            {
                return BadRequest("Register requires username and either password or password hash and salt");
            }

            try
            {
                UserDto user = Authentication.Register(authModel.Username, authModel.PasswordHash ?? authModel.Password, authModel.PasswordSalt);
                SetPrincipal(MakePrincipal(user));
                return Ok(user);
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }
        
        [HttpPost]
        [Route("api/Authentication/Ping")]
        public IHttpActionResult Ping([FromBody] PingModel pingModel)
        {
            if (pingModel == null)
            {
                return BadRequest("Ping requires token");
            }

            try
            {
                UserDto user = Authentication.Ping(pingModel.Token);
                SetPrincipal(MakePrincipal(user));
                return Ok(user);
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }

        [HttpGet]
        [Route("api/Authentication/Salt/{subject}")]
        public IHttpActionResult Salt([FromUri] string subject)
        {
            UserDto user = Users.Read().SingleOrDefault(a => a.Name == subject);
            if (user != null && !string.IsNullOrEmpty(user.PasswordSalt))
            {
                return Ok(new AuthenticationModel
                {
                    Username = user.Name,
                    Password = null,
                    PasswordHash = null,
                    PasswordSalt = user.PasswordSalt
                });
            }
            return NotFound();
        }
    }
}