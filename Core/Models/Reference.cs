namespace ProxyPayApiClient.Core.Models
{
    public class Reference
    {
        public required string Id { get; set; }
        public decimal Amount { get; set; }
        public required string CustomerId { get; set; }
    }
}
