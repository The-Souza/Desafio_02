using Microsoft.Extensions.Configuration;

namespace Desafio_02;
public class Program
{
    public static void Main()
    {
        var program = new Program();

        string? connectionString = program.ReadConnectionString();

        var context = new MyDbContext(connectionString);
        var dataManipulation = new DataManipulation(context);

        while (true)
        {
            Console.WriteLine("Menu de Opções:\n\n1. Criar tabela\n2. Deletar registros\n3. Inserir registros\n4. Consultar tabela\n5. Sair");
            Console.Write("\nEscolha uma opção: ");

            switch (Console.ReadLine())
            {
                case "1":
                    dataManipulation.CreateTable();
                    program.BackToMenu();
                    break;

                case "2":
                    dataManipulation.DeleteAllEmployees();
                    program.BackToMenu();
                    break;

                case "3":
                    int numRows = program.PromptForRowCount();
                    dataManipulation.InsertEmployees(numRows);
                    program.BackToMenu();
                    break;

                case "4":
                    dataManipulation.GetAllEmployees();
                    program.BackToMenu();
                    break;

                case "5":
                    Console.WriteLine("\nSaindo...");
                    return;

                default:
                    program.HandleInvalidOption();
                    break;
            }
        }
    }

    private int PromptForRowCount()
    {
        Console.Write("\nQuantidade de registros para inserir: ");
        int numRows;
        do
        {
            if (!int.TryParse(Console.ReadLine(), out numRows) || numRows == 0) 
            { 
                Console.Write("\nEntrada inválida.\nInsira um número ou um número maior que zero: ");
            }
        } while (numRows <= 0);
        return numRows;
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
            return string.Empty;
        }
    }

    private void BackToMenu()
    {
        string backToMenu = "\nPressino qualquer tecla para voltar ao Menu de Operações.";
        Console.Write(backToMenu);
        Console.ReadKey();
        Console.Clear();
    }

    private void HandleInvalidOption()
    {
        Console.Write("\nOpção inválida. Escolha entre as opções [1], [2], [3], [4] e [5].");
        Console.ReadKey();
        Console.Clear();
    }
}
