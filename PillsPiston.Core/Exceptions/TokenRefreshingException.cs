using PillsPiston.Core.Enums;
using PillsPiston.Core.Resources;

namespace PillsPiston.Core.Exceptions
{
    public class TokenRefreshingException : PillsPistonException
    {
        public TokenRefreshingException()
            : base(ErrorMessages.TokenRefreshingException)
        {
        }

        public TokenRefreshingException(string message)
            : base(message)
        {
        }

        public override int Code => (int)ErrorCodesEnums.Token.RefreshingError;
    }
}
