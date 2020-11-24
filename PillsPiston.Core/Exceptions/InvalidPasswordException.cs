using PillsPiston.Core.Enums;
using PillsPiston.Core.Resources;

namespace PillsPiston.Core.Exceptions
{
    public class InvalidPasswordException : PillsPistonException
    {
        public InvalidPasswordException()
            : base(ErrorMessages.InvalidPasswordException)
        {
        }

        public InvalidPasswordException(string message)
            : base(message)
        {
        }

        public override int Code => (int)ErrorCodesEnums.Login.InvalidPassword;
    }
}
