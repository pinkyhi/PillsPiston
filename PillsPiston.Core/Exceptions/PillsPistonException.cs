using PillsPiston.Core.Enums;
using PillsPiston.Core.Resources;
using System;

namespace PillsPiston.Core.Exceptions
{
    public class PillsPistonException : Exception
    {
        public PillsPistonException()
            : base(ErrorMessages.Unknown)
        {
        }

        public PillsPistonException(string message)
            : base(message)
        {
        }

        public virtual int Code => (int)ErrorCodesEnums.Global.Unknown;
    }
}
