namespace ProxyPayApiClient.Core.Interfaces
{
    public interface IProxyPayService
    {
        Task<string> GenerateReferenceAsync(decimal amount, string customerId);
        Task<string> GetReferenceStatusAsync(string referenceId);
        // Adicione outros métodos conforme necessário
    }
}
