using Notes.BusinessObjects.DataTransferObjects.Users;

namespace Notes.UI.Domain.Events
{
    public class AuthenticationEventArgs
    {
        public UserDto User { get; set; }
    }
}
