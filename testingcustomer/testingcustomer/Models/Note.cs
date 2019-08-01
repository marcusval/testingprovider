using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace testingcustomer.Models
{
    public class Note
    {
       [JsonProperty(PropertyName = "Id_N")]
        public int Id_N { get; set; }

        [JsonProperty(PropertyName = "FromProvider")]
        public bool FromProvider { get; set; }

        [JsonProperty(PropertyName = "FromCustomer")]
        public bool FromCustomer { get; set; }

        [JsonProperty(PropertyName = "WrittenNote")]
        public string WrittenNote { get; set; }

        [JsonProperty(PropertyName = "Id_H")]
        public string Id_H { get; set; }

        [JsonProperty(PropertyName = "Ndate")]
        public DateTime? Ndate { get; set; }
    }
}
