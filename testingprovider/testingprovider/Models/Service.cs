using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace testingprovider.Models
{
    public class Service
    {
        [JsonProperty(PropertyName = "Id_S")]
        public string Id_S { get; set; }

        [JsonProperty(PropertyName = "Frequency")]
        public string Frequency { get; set; }

        [JsonProperty(PropertyName = "ServiceType")]
        public string ServiceType { get; set; }

        [JsonProperty(PropertyName = "WeekColor")]
        public string WeekColor { get; set; }
    }
}
