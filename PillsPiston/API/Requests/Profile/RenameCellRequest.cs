using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsPiston.API.Requests.Profile
{
    public class RenameCellRequest
    {
        public string CellId { get; set; }

        public string Name { get; set; }
    }
}
