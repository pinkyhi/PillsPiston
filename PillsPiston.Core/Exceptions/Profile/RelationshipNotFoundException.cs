using PillsPiston.Core.Enums;
using PillsPiston.Core.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace PillsPiston.Core.Exceptions.Profile
{
    public class RelationshipNotFoundException : PillsPistonException
    {
        public RelationshipNotFoundException()
    : base(ErrorMessages.RelationshipNotFoundException)
        {
        }

        public RelationshipNotFoundException(string message)
            : base(message)
        {
        }

        public override int Code => (int)ErrorCodesEnums.Profile.RelationshipNotFound;
    }
}
