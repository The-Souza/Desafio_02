using Microsoft.Extensions.Configuration;

namespace Desafio_02;
public class Program
{
    public static void Main()
    {
        var program = new Program();

        string? connectionString = program.ReadConnectionString();

        var context = new MyDbContext(connectionString);
        var dataManipulation = new DbManipulation(context);

        while (true)
        {
            Console.WriteLine("Menu de Opções:\n\n1. Criar tabela\n2. Deletar tabela\n3. Inserir registros\n4. Deletar registros\n5. Consultar tabela\n6. Sair");
            Console.Write("\nEscolha uma opção: ");

            switch (Console.ReadLine())
            {
                case "1":
                    dataManipulation.CreateTable();
                    program.BackToMenu();
                    break;

                case "2":
                    dataManipulation.DeleteTable();
                    program.BackToMenu();
                    break;

                case "3":
                    dataManipulation.InsertEmployees();
                    program.BackToMenu();
                    break;

                case "4":
                    dataManipulation.DeleteAllEmployees();
                    program.BackToMenu();
                    break;

                case "5":
                    dataManipulation.GetAllEmployees();
                    program.BackToMenu();
                    break;

                case "6":
                    Console.WriteLine("\nSaindo...");
                    return;

                default:
                    program.HandleInvalidOption();
                    break;
            }
        }
    }

    private string ReadConnectionString()
    {
        try
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            string? connectionString = configuration.GetConnectionString("ConnectionString");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("A ConnectionString não foi encontrada ou está vazia no arquivo de configuração.");
            }

            return connectionString;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao ler a ConnectionString: {ex.Message}");
            Environment.Exit(1);
            return "";
        }
    }

    private void BackToMenu()
    {
        Console.Write("\nPressione qualquer tecla para voltar ao Menu de Operações.");
        Console.ReadKey();
        Console.Clear();
    }

    private void HandleInvalidOption()
    {
        Console.Write("\nOpção inválida. Escolha entre as opções [1], [2], [3], [4], [5] e [6].");
        Console.ReadKey();
        Console.Clear();
    }
}
