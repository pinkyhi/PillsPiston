﻿using System.Text.Json.Serialization;

namespace PillsPiston.Core.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DeviceModelsEnum
    {
        Light,
        Medium,
        Prime
    }
}
