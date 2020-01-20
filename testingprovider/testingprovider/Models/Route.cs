using Newtonsoft.Json;

namespace testingprovider.Models
{
    public class Route
    {
        [JsonProperty(PropertyName = "Id_R")]
        public int Id_R { get; set; }

        [JsonProperty(PropertyName = "DayOfWeek")]
        public string DayOfWeek { get; set; }

        [JsonProperty(PropertyName = "Id_P")]
        public string Id_P { get; set; }
    }
}
