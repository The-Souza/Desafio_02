# Manipulação de Banco de Dados com Entity Framework Core

Aplicação console em C# utilizando **Entity Framework Core** para manipulação de uma tabela de funcionários (`Funcionario`) em um banco de dados SQL Server.

---

## 📁 Estrutura do Projeto

```
Desafio_02/
├── Program.cs
├── DbManipulation.cs
├── MyDbContext.cs
├── ValuesGeneratorForTheDB.cs
├── Employee.cs
├── ExampleAppSettings.json
```

---

## 📌 Descrição dos Arquivos

### `Program.cs`
Ponto de entrada da aplicação. Responsável por:

- Ler a `ConnectionString` do `appsettings.json`.
- Instanciar `MyDbContext` e `DbManipulation`.
- Exibir o menu interativo com as opções:

```
Menu de Opções:

1. Criar tabela
2. Deletar tabela
3. Inserir registros
4. Deletar registros
5. Consultar tabela
6. Sair

Escolha uma opção: 
```

---

### `DbManipulation.cs`
Classe com as operações principais de banco de dados:

- `CreateTable()` – Cria a tabela se ela não existir
- `DeleteTable()` – Deleta a tabela se existir
- `InsertEmployees()` – Insere funcionários com dados aleatórios
- `DeleteAllEmployees()` – Apaga todos os registros da tabela
- `GetAllEmployees()` – Lista todos os funcionários

Todas as operações verificam se a tabela existe antes de executarem.

---

### `MyDbContext.cs`
Classe de contexto do EF Core que define a conexão com o banco de dados:

```csharp
public DbSet<Employee> Employees { get; set; }
```

Utiliza o método `OnConfiguring` para configurar a string de conexão.

---

### `ValuesGeneratorForTheDB.cs`
Classe utilitária para gerar dados aleatórios:

- `GetRandomName()` – Gera um nome brasileiro aleatório
- `GetRandomCity()` – Gera uma cidade brasileira aleatória

Utilizado para alimentar os dados da tabela durante inserções.

---

### `Employee.cs`
Classe de entidade representando a tabela `Funcionario`.

- Utiliza `DataAnnotations` para definir:
  - Nome da tabela e colunas
  - Tipo de dados (incluindo `varchar`)
  - Regras de validação

Campos:

| Propriedade | Tipo         | Requisitos                     |
|-------------|--------------|--------------------------------|
| `Id`        | int?         | Chave primária, Identity       |
| `Name`      | string?      | Obrigatório, varchar(50)       |
| `Age`       | int?         | Obrigatório, entre 18 e 50     |
| `Address`   | string?      | Obrigatório, varchar(100)      |

---

### `ExampleAppSettings.json`
Arquivo de exemplo com a configuração de conexão:

```json
{
  "ConnectionStrings": {
    "ConnectionString": "Server=Change_Me;Database=Change_Me;User Id=Change_Me;Password=Change_Me;TrustServerCertificate=True;"
  }
}
```

> Substitua os valores `Change_Me` pelos dados reais do seu ambiente.

---

## ▶️ Como Executar

1. Edite o arquivo `appsettings.json` com a sua string de conexão SQL Server.
2. Utilize o menu interativo no console para realizar operações no banco.

---

## ✅ Requisitos

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local ou remoto)
- Pacotes NuGet:
  - `Microsoft.EntityFrameworkCore`
  - `Microsoft.Data.SqlClient`
  - `Microsoft.EntityFrameworkCore.SqlServer`
  - `Microsoft.Extensions.Configuration.Json`

---

## 📄 Licença

Este projeto está licenciado sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.