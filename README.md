Claro! Aqui está um exemplo de documentação que você pode usar no GitHub para o projeto:

---

# ProxyPay API Client Library

[![NuGet](https://img.shields.io/nuget/v/ProxyPayApiClient.Library.svg)](https://www.nuget.org/packages/ProxyPayApiClient.Library/)

Uma biblioteca C# para consumir a API ProxyPay, seguindo os princípios de Clean Code e Clean Architecture.

## Visão Geral

A biblioteca ProxyPayApiClient fornece uma maneira fácil de interagir com a API ProxyPay. Ela encapsula toda a lógica necessária para gerar referências, consultar status e outras operações fornecidas pela API.

## Estrutura do Projeto

```
ProxyPayApiClient
├── ProxyPayApiClient.Core
│   ├── Interfaces
│   └── Models
├── ProxyPayApiClient.Infrastructure
│   └── Services
└── ProxyPayApiClient.Library
```

## Instalação

Você pode instalar a biblioteca via NuGet:

```sh
dotnet add package ProxyPayApiClient.Library --version 1.0.0
```

## Uso

### Configuração

Para utilizar a biblioteca, você deve configurar os serviços no seu projeto. A seguir, um exemplo de como configurar a biblioteca em um projeto Console:

```csharp
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ProxyPayApiClient.Core.Interfaces;
using ProxyPayApiClient.Library;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddProxyPayApiClient("https://api.proxypay.co.ao/v2/", "YOUR_ACCESS_TOKEN");

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var proxyPayService = serviceProvider.GetRequiredService<IProxyPayService>();

        var referenceId = await proxyPayService.GenerateReferenceAsync(100.00m, "customer123");
        Console.WriteLine($"Generated Reference ID: {referenceId}");

        var status = await proxyPayService.GetReferenceStatusAsync(referenceId);
        Console.WriteLine($"Reference Status: {status}");
    }
}
```

### Adicionando o Serviço

Você pode adicionar o serviço ProxyPayApiClient ao seu `IServiceCollection` usando a extensão `AddProxyPayApiClient`:

```csharp
using Microsoft.Extensions.DependencyInjection;
using ProxyPayApiClient.Library;

// Dentro do método ConfigureServices ou equivalente:
services.AddProxyPayApiClient("https://api.proxypay.co.ao/v2/", "YOUR_ACCESS_TOKEN");
```

### Gerando uma Referência

Para gerar uma referência, você pode usar o método `GenerateReferenceAsync`:

```csharp
var referenceId = await proxyPayService.GenerateReferenceAsync(100.00m, "customer123");
Console.WriteLine($"Generated Reference ID: {referenceId}");
```

### Obtendo o Status de uma Referência

Para obter o status de uma referência, você pode usar o método `GetReferenceStatusAsync`:

```csharp
var status = await proxyPayService.GetReferenceStatusAsync(referenceId);
Console.WriteLine($"Reference Status: {status}");
```

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir uma issue ou enviar um pull request.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

---

## Estrutura dos Diretórios

- `ProxyPayApiClient.Core`: Contém interfaces e modelos.
- `ProxyPayApiClient.Infrastructure`: Implementação dos serviços que consomem a API.
- `ProxyPayApiClient.Library`: Biblioteca que configura e expõe os serviços para consumo.

## Estrutura do Código

### Interfaces

`IProxyPayService` define os métodos para interagir com a API ProxyPay.

### Modelos

`Reference` é o modelo que representa uma referência na API ProxyPay.

### Serviços

`ProxyPayService` implementa `IProxyPayService` e contém a lógica para consumir a API ProxyPay.

### Configuração de Serviços

`ServiceCollectionExtensions` contém métodos de extensão para configurar os serviços no `IServiceCollection`.

---

### Exemplos Adicionais

#### Adicionando mais métodos

Você pode expandir a biblioteca adicionando mais métodos na interface `IProxyPayService` e implementando-os em `ProxyPayService`. Por exemplo:

```csharp
Task<string> CancelReferenceAsync(string referenceId);
```

Implementação:

```csharp
public async Task<string> CancelReferenceAsync(string referenceId)
{
    var response = await _httpClient.DeleteAsync($"references/{referenceId}");
    response.EnsureSuccessStatusCode();
    var result = await response.Content.ReadAsStringAsync();
    return result;
}
```

#### Configurando variáveis de ambiente

Para maior segurança, você pode configurar seu token de acesso usando variáveis de ambiente:

```csharp
var accessToken = Environment.GetEnvironmentVariable("PROXYPAY_ACCESS_TOKEN");
services.AddProxyPayApiClient("https://api.proxypay.co.ao/v2/", accessToken);
```

---
