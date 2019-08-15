using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Notes.API.Results
{
    public class AuthenticationFailureResult : IHttpActionResult
    {
        public string Message { get; private set; }

        public HttpRequestMessage Request { get; private set; }

        public AuthenticationFailureResult(string message, HttpRequestMessage request)
        {
            Message = message;
            Request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        private HttpResponseMessage Execute()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.RequestMessage = Request;
            response.ReasonPhrase = Message;
            return response;
        }
    }
}