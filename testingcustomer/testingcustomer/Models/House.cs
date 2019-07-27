using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace testingcustomer.Models
{
    public class House
    {
        [JsonProperty(PropertyName = "Id_H")]
        public string Id_H { get; set; }

        [JsonProperty(PropertyName = "StreetNumber")]
        public string StreetNumber { get; set; }

        [JsonProperty(PropertyName = "StreetName")]
        public string StreetName { get; set; }

        [JsonProperty(PropertyName = "StreetSuffix")]
        public string StreetSuffix { get; set; }

        [JsonProperty(PropertyName = "City")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "State")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "Id_S")]
        public string Id_S { get; set; }

        [JsonProperty(PropertyName = "Space")]
        public string Space { get; set; }

        [JsonProperty(PropertyName = "Id_R")]
        public string Id_R { get; set; }

        [JsonProperty(PropertyName = "Id_C")]
        public string Id_C { get; set; }

        [JsonProperty(PropertyName = "Long")]
        public string Long { get; set; }

        [JsonProperty(PropertyName = "Lat")]
        public string Lat { get; set; }
    }
}
