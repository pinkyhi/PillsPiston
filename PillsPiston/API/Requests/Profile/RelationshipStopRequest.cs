using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsPiston.API.Requests.Profile
{
    public class RelationshipStopRequest
    {
        public string MateId { get; set; }

        public bool IsFromSubject { get; set; }
    }
}
