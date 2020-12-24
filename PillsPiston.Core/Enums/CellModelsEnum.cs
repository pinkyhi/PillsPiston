using System.Text.Json.Serialization;

namespace PillsPiston.Core.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CellModelsEnum
    {
        Single,
        Double,
        Large
    }
}
