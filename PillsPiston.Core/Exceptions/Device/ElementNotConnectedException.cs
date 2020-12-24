﻿using PillsPiston.Core.Enums;
using PillsPiston.Core.Resources;

namespace PillsPiston.Core.Exceptions.Device
{
    public class ElementNotConnectedException : PillsPistonException
    {
        public ElementNotConnectedException()
            : base(ErrorMessages.ElementNotConnectedException)
        {
        }

        public ElementNotConnectedException(string message)
            : base(message)
        {
        }

        public override int Code => (int)ErrorCodesEnums.Device.NotConnected;
    }
}
