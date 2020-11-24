using PillsPiston.Core.Enums;
using PillsPiston.Core.Resources;

namespace PillsPiston.Core.Exceptions
{
    public class EmailOccupiedException : PillsPistonException
    {
        public EmailOccupiedException()
           : base(ErrorMessages.EmailOccupiedException)
        {
        }

        public EmailOccupiedException(string message)
            : base(message)
        {
        }

        public override int Code => (int)ErrorCodesEnums.Registration.EmailOccupied;
    }
}
