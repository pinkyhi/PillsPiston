﻿using PillsPiston.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PillsPiston.API.Requests.Admin
{
    public class NewCellsRequest
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CellModelsEnum Model { get; set; }

        [Range(1, 100000)]
        public int Count { get; set; }
    }
}
