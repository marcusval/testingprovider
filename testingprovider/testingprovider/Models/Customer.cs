using Newtonsoft.Json;

namespace testingprovider.Models
{
    public class Customer
    {
        [JsonProperty(PropertyName = "Id_C")]
        public string Id_C { get; set; }

        [JsonProperty(PropertyName = "Password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "PhoneNum")]
        public string PhoneNum { get; set; }

        [JsonProperty(PropertyName = "EmailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty(PropertyName = "FirstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "LastName")]
        public string LastName { get; set; }
    }
}
