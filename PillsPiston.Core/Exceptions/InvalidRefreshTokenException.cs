using PillsPiston.Core.Enums;
using PillsPiston.Core.Resources;

namespace PillsPiston.Core.Exceptions
{
    public class InvalidRefreshTokenException : PillsPistonException
    {
        public InvalidRefreshTokenException()
          : base(ErrorMessages.InvalidRefreshTokenException)
        {
        }

        public InvalidRefreshTokenException(string message)
            : base(message)
        {
        }

        public override int Code => (int)ErrorCodesEnums.Token.InvalidRefreshToken;
    }
}
