using Notes.BusinessObjects.DataTransferObjects.Users;
using System;

namespace Notes.Service.Infrastructure
{
    public interface IAuthenticationService : IDisposable
    {
        UserDto Authenticate(string name, string passwordOrHash, string salt = null);
        UserDto Register(string name, string passwordOrHash, string salt = null);
        UserDto Ping(string token);
    }
}
