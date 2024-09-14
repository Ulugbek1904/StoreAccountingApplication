using System.Text.Json.Serialization;

namespace StoreAccountingApplication.Models
{
    public class Meneger
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [JsonIgnore]
        public string PassportSeries { get; set; }
    }
}
