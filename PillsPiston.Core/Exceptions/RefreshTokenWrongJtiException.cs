using PillsPiston.Core.Enums;
using PillsPiston.Core.Resources;

namespace PillsPiston.Core.Exceptions
{
    public class RefreshTokenWrongJtiException : PillsPistonException
    {
        public RefreshTokenWrongJtiException()
   : base(ErrorMessages.RefreshTokenWrongJtiException)
        {
        }

        public RefreshTokenWrongJtiException(string message)
            : base(message)
        {
        }

        public override int Code => (int)ErrorCodesEnums.Token.WrongJtiRefreshToken;
    }
}
