using PillsPiston.Core.Enums;
using PillsPiston.Core.Resources;

namespace PillsPiston.Core.Exceptions
{
    public class RefreshTokenIsInvalidException : PillsPistonException
    {
        public RefreshTokenIsInvalidException()
          : base(ErrorMessages.RefreshTokenIsInvalidatedException)
        {
        }

        public RefreshTokenIsInvalidException(string message)
            : base(message)
        {
        }

        public override int Code => (int)ErrorCodesEnums.Token.InvalidatedRefreshToken;
    }
}
