using Ninject;
using Notes.API.Helpers;
using Notes.API.Results;
using Notes.BusinessObjects.DataTransferObjects.Users;
using Notes.BusinessObjects.WebApiModels;
using Notes.Repositories.Implementation.Users;
using Notes.Security.Authentication;
using Notes.Service.Implementation;
using Notes.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace Notes.API.Filters
{
    public class MvcTokenAuthenticationFilter : IAuthorizationFilter
    {
        private readonly IAuthenticationService Auth;

        public MvcTokenAuthenticationFilter(IAuthenticationService auth)
        {
            Auth = auth;
        }

        public bool AllowMultiple => throw new NotImplementedException();

        public void OnAuthorization(AuthorizationContext context)
        {
            UserDto user = null;

            try
            {
                PingModel pingModel = ParseTokenHeader(context);
                user = Auth.Ping(pingModel.Token);
            }
            catch (Exception x)
            {
                context.Result = new HttpUnauthorizedResult();
            }

            if (user == null)
            {
                context.Result = new HttpUnauthorizedResult();
            }
            else
            {
                context.Result = new HttpStatusCodeResult(200);
            }
        }

        private PingModel ParseTokenHeader(AuthorizationContext context)
        {
            string authHeader = null;
            var auth = context.HttpContext.Request.Headers.Get("Authorization");

            string[] tokens = auth.Split(' ');

            if (tokens.Length < 2 || tokens[0] != "Bearer")
            {
                tokens = tokens.Skip(1).Take(tokens.Length - 1).ToArray();
                authHeader = string.Join(" ", tokens);
            }

            if (string.IsNullOrEmpty(authHeader))
                return null;

            return new PingModel
            {
                Token = authHeader
            };
        }
    }
}