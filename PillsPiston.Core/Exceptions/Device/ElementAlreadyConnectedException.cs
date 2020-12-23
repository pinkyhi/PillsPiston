using PillsPiston.Core.Enums;
using PillsPiston.Core.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace PillsPiston.Core.Exceptions.Device
{
    public class ElementAlreadyConnectedException : PillsPistonException
    {
        public ElementAlreadyConnectedException()
            : base(ErrorMessages.ElementAlreadyConnectedException)
        {
        }

        public ElementAlreadyConnectedException(string message)
            : base(message)
        {
        }

        public override int Code => (int)ErrorCodesEnums.Device.AlreadyConnected;
    }
}
