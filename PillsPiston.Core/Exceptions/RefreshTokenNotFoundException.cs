using PillsPiston.Core.Enums;
using PillsPiston.Core.Resources;

namespace PillsPiston.Core.Exceptions
{
    public class RefreshTokenNotFoundException : PillsPistonException
    {
        public RefreshTokenNotFoundException()
           : base(ErrorMessages.RefreshTokenNotFoundException)
        {
        }

        public RefreshTokenNotFoundException(string message)
            : base(message)
        {
        }

        public override int Code => (int)ErrorCodesEnums.Token.NotFoundRefreshToken;
    }
}
