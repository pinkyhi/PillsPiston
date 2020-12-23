using PillsPiston.Core.Enums;
using PillsPiston.Core.Resources;
using System;
using System.Collections.Generic;
using System.Text;

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
