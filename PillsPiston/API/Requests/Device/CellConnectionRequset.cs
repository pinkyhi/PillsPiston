using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsPiston.API.Requests.Device
{
    public class CellConnectionRequset
    {
        public string DeviceId { get; set; }

        public string CellId { get; set; }
    }
}
