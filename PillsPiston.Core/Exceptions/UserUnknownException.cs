using PillsPiston.Core.Enums;
using PillsPiston.Core.Resources;

namespace PillsPiston.Core.Exceptions
{
    public class UserUnknownException : PillsPistonException
    {
        public UserUnknownException()
    : base(ErrorMessages.UserUnknownException)
        {
        }

        public UserUnknownException(string message)
            : base(message)
        {
        }

        public override int Code => (int)ErrorCodesEnums.Login.UserUnknown;
    }
}
