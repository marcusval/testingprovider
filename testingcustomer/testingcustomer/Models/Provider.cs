using Newtonsoft.Json;

namespace testingcustomer.Models
{
    public class Provider
    {
        [JsonProperty(PropertyName = "Id_P")]
        public string Id_P { get; set; }

        [JsonProperty(PropertyName = "Password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "FirstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "LastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "CityTerritory")]
        public string CityTerritory { get; set; }

        [JsonProperty(PropertyName = "EmailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty(PropertyName = "PhoneNum")]
        public string PhoneNum { get; set; }
    }
}
