using Ninject;
using Notes.BusinessObjects.WebApiModels;
using Notes.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Net.Http;
using Notes.BusinessObjects.DataTransferObjects.Users;
using Notes.API.Results;
using System.Web.Mvc;

namespace Notes.API.Attributes
{
    public class MvcTokenAuthenticationAttribute : FilterAttribute { }
}