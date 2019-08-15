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
using System.Web.Http.Filters;

namespace Notes.API.Filters
{
    public class HttpTokenAuthenticationFilter : IAuthorizationFilter
    {
        [Inject]
        private readonly IAuthenticationService Auth;

        public HttpTokenAuthenticationFilter()
        {
        }

        public bool AllowMultiple => throw new NotImplementedException();
        
        public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext context, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            return Task.Factory.StartNew(() =>
            {
                HttpRequestMessage request = context.Request;

                UserDto user = null;

                try
                {
                    PingModel pingModel = ParseTokenHeader(context);
                    user = Auth.Ping(pingModel.Token);
                }
                catch (Exception)
                {
                    return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                }

                if (user == null)
                {
                    return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                }
                else
                {
                    return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                }
            });
        }

        private PingModel ParseTokenHeader(HttpActionContext context)
        {
            string authHeader = null;
            var auth = context.Request.Headers.Authorization;
            if (auth != null && auth.Scheme == "Bearer")
                authHeader = auth.Parameter;

            if (string.IsNullOrEmpty(authHeader))
                return null;

            return new PingModel
            {
                Token = authHeader
            };
        }
    }
}