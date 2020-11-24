using PillsPiston.Core.Enums;
using PillsPiston.Core.Resources;

namespace PillsPiston.Core.Exceptions
{
    public class RefreshTokenIsExpiredException : PillsPistonException
    {
        public RefreshTokenIsExpiredException()
           : base(ErrorMessages.RefreshTokenIsExpiredException)
        {
        }

        public RefreshTokenIsExpiredException(string message)
            : base(message)
        {
        }

        public override int Code => (int)ErrorCodesEnums.Token.ExpiredRefreshToken;
    }
}
