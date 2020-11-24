using PillsPiston.Core.Enums;
using PillsPiston.Core.Resources;

namespace PillsPiston.Core.Exceptions
{
    public class RefreshTokenIsUsedException : PillsPistonException
    {
        public RefreshTokenIsUsedException()
   : base(ErrorMessages.RefreshTokenIsUsedException)
        {
        }

        public RefreshTokenIsUsedException(string message)
            : base(message)
        {
        }

        public override int Code => (int)ErrorCodesEnums.Token.UsedRefreshToken;
    }
}
