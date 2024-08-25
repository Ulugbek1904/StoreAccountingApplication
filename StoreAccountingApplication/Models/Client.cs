namespace StoreAccountingApplication.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public ClientAdress Address { get; set; }

    }
    public enum ClientAdress
    {
        Country,
        Region,
        NeighboorHood
    }

}
