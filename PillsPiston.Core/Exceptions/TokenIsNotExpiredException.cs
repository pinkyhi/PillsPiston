using PillsPiston.Core.Enums;
using PillsPiston.Core.Resources;

namespace PillsPiston.Core.Exceptions
{
    public class TokenIsNotExpiredException : PillsPistonException
    {
        public TokenIsNotExpiredException()
   : base(ErrorMessages.TokenIsNotExpiredExeption)
        {
        }

        public TokenIsNotExpiredException(string message)
            : base(message)
        {
        }

        public override int Code => (int)ErrorCodesEnums.Token.IsNotExpired;
    }
}
