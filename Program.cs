using Microsoft.Extensions.Configuration;

namespace Desafio_02;
public class Program
{
    public static void Main()
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

        var context = new MyDbContext(connectionString);
        var employeeService = new DataManipulation(context);

        employeeService.CreateTable();
        employeeService.DeleteAllEmployees();
        employeeService.InsertEmployees(100);
        employeeService.GetAllEmployees();
    }
}
