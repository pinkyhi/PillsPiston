using PillsPiston.Core.Enums;
using PillsPiston.Core.Resources;

namespace PillsPiston.Core.Exceptions
{
    public class UsernameOccupiedException : PillsPistonException
    {
        public UsernameOccupiedException()
           : base(ErrorMessages.UsernameOccupiedException)
        {
        }

        public UsernameOccupiedException(string message)
            : base(message)
        {
        }

        public override int Code => (int)ErrorCodesEnums.Registration.UsernameOccupied;
    }
}
