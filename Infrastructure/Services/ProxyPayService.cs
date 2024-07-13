using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ProxyPayApiClient.Core.Interfaces;
using ProxyPayApiClient.Core.Models;

namespace ProxyPayApiClient.Infrastructure.Services
{
    public class ProxyPayService : IProxyPayService
    {
        private readonly HttpClient _httpClient;

        public ProxyPayService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GenerateReferenceAsync(decimal amount, string customerId)
        {
            var response = await _httpClient.PostAsJsonAsync("references", new { amount, customerId });
            response.EnsureSuccessStatusCode();
            var reference = await response.Content.ReadFromJsonAsync<Reference>();
            return reference.Id;
        }

        public async Task<string> GetReferenceStatusAsync(string referenceId)
        {
            var response = await _httpClient.GetAsync($"references/{referenceId}");
            response.EnsureSuccessStatusCode();
            var status = await response.Content.ReadAsStringAsync();
            return status;
        }

        // Adicione outros métodos conforme necessário
    }
}
