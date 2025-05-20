# 🛠️ Sistema de Gerenciamento de Oficina Mecânica

## Sobre o projeto

O **Sistema de Oficina Mecânica** é uma API desenvolvida com **ASP.NET Core 8**, projetada para gerenciar ordens de serviço, clientes, veículos e agendamentos de forma organizada e eficiente. A aplicação utiliza o **FluentValidation** para garantir a integridade dos dados nas requisições.

A arquitetura foi construída seguindo o padrão de camadas, promovendo uma **boa separação de responsabilidades**, facilitando manutenção, testes e evolução do sistema. Foi utilizada **injeção de dependência via interfaces**, garantindo um **baixo acoplamento** entre os componentes.

O banco de dados utilizado é o **SQL Server**, com mapeamento feito via **Entity Framework Core**. Os testes de unidade foram implementados com **xUnit**, e as asserções com **FluentAssertions**, promovendo clareza e legibilidade nos testes.

Além disso, o código segue os princípios de **Clean Code**, com foco em nomes significativos, código limpo e estruturado.

---

## Funcionalidades principais

- **Cadastro de Clientes**: Registra clientes com validações de nome, email e dados de contato.
- **Cadastro de Veículos**: Permite associar veículos aos clientes, com informações como placa, modelo e ano.
- **Abertura de Ordens de Serviço**: Gera ordens com data, descrição do problema, diagnóstico e valor.
- **Atualização e Conclusão de Serviços**: Permite alterar status de ordens e registrar conclusão.
- **Histórico de Serviços**: Lista ordens finalizadas por cliente ou veículo.
- **Validações robustas**: Uso de FluentValidation para garantir regras de negócio e integridade dos dados.
- **Listar manutenções agendadas para os próximos 5 dias** (funcionalidade "upcoming")

---

## Padrões e Práticas Utilizadas

- **CQRS** (Command Query Responsibility Segregation)
- **MediatR** para centralizar a comunicação entre comandos e manipuladores.
- **Result Pattern** para retorno unificado de respostas com mensagens e códigos apropriados.
- **Repository Pattern** para isolar a lógica de persistência.
- **Clean Architecture**, dividindo o projeto em camadas:
  - `API`
  - `Application`
  - `Core`
  - `Infrastructure`
  - `Tests`

---

## 🔎 Destaque de Código - Filtro de Manutenções Agendadas (Upcoming)

A API permite listar as manutenções agendadas que acontecerão nos próximos 5 dias, com base na data atual e no ID da oficina (obtido a partir do usuário autenticado). Isso é útil para alertar sobre serviços que estão próximos da data de execução.

Trecho do método utilizado no repositório:

```csharp
public async Task<List<Maintenance?>> GetAllUpcomingMaintenance(int workShopId)
{
    var today = DateTime.Now;
    var nextFiveDays = today.AddDays(5);

    var maintenances = await _context.Maintenances
        .Where(m => m.ScheduledDate >= today &&
            m.ScheduledDate <= nextFiveDays &&
            !m.IsCompleted &&
            m.WorkShopId == workShopId)
        .ToListAsync();

    return maintenances;
}
````

## 📬 Exemplo: Uso do MediatR (CQRS)

O RegisterVehicleCommand encapsula os dados da requisição, enquanto o RegisterVehicleHandler trata a lógica. Esse padrão organiza a aplicação e separa responsabilidade de entrada e execução.

```csharp
public record RegisterVehicleCommand(string Plate, string Model, int Year, int CustomerId, int WorkshopId)
    : IRequest<Result<RegisterVehicleResponse>>;
```
```csharp
public class RegisterVehicleHandler : IRequestHandler<RegisterVehicleCommand, Result<RegisterVehicleResponse>>
{
    public async Task<Result<RegisterVehicleResponse>> Handle(RegisterVehicleCommand request, CancellationToken cancellationToken)
    {
        // Lógica para criar o veículo
    }
}
```


## Requisitos

- Visual Studio 2022+ ou Visual Studio Code
- Windows 10+, macOS ou Linux com .NET SDK 8+
- SQL Server

---

## Construído com

- ✅ ASP.NET Core 8
- ✅ Entity Framework Core
- ✅ FluentValidation
- ✅ xUnit + FluentAssertions
- ✅ MediatR
- ✅ SQL Server
- ✅ Swagger para documentação da API

---

## Começando

### 📦 Requisitos

- [.NET SDK 8](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- Visual Studio ou VS Code com extensões C#

---

### 🚀 Instalação

1. Clone o repositório:

```bash
git clone git@github.com:benicio227/Manutec-API.git
````

2. Acesse a documentação da API pelo Swagger:
   ```bash
   https://localhost:7148/swagger
   ```
OBS! A porta 7148 é a padrão configurada nesse projto. Caso esteja usando outra porta localmente, ajuste a URL conforme necessário.
Exemplo: https://localhost:porta/swagger

## License

Este projeto está licenciado sob a [Licença MIT](LICENSE) 
