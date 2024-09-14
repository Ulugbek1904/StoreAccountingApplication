using System.Text.Json.Serialization;

namespace StoreAccountingApplication.Models
{
    public class Address
    {
        public string Street { get; set; }  
        public string City { get; set; }    
        public string State { get; set; }   
        public string Country { get; set; }
        [JsonIgnore]
        public Client Client { get; set; }
    }
}
