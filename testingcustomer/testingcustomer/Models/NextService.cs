using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Refit; 
using System.Text;
using System.Threading.Tasks;

namespace testingcustomer.Models
{
    public class NextService
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "DateRange")]
        public string DateRange { get; set; }

        [JsonProperty(PropertyName = "ServiceDetails")]
        public string ServiceDetails { get; set; }

        [JsonProperty(PropertyName = "NotesToCustomer")]
        public string NotesToCustomer { get; set; }

        public static implicit operator Task<object>(NextService v)
        {
            throw new NotImplementedException();
        }
    }
}
