using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Desafio_02
{
    public class DataManipulation
    {
        private readonly MyDbContext context;

        public DataManipulation(MyDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void CreateTable()
        {
            var tableName = GetEmployeeTableName();

            try
            {
                if (TableExists(tableName))
                {
                    Console.WriteLine($"\nA tabela '{tableName}' já existe.");
                    return;
                }

                context.Database.EnsureCreated();
                Console.WriteLine("\nTabela criada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao criar tabela: {ex.Message}");
            }
        }

        public void DeleteTable()
        {
            var tableName = GetEmployeeTableName();

            try
            {
                if (!TableExists(tableName))
                {
                    Console.WriteLine($"\nA tabela '{tableName}' não existe.");
                    return;
                }

                using var command = context.Database.GetDbConnection().CreateCommand();
                command.CommandText = $"DROP TABLE [dbo].[{tableName}]";

                context.Database.OpenConnection();
                command.ExecuteNonQuery();

                Console.WriteLine($"\nTabela '{tableName}' deletada com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao deletar a tabela '{tableName}': {ex.Message}");
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }

        public void DeleteAllEmployees()
        {
            var tableName = GetEmployeeTableName();

            try
            {
                if (!TableExists(tableName))
                {
                    Console.WriteLine($"\nA tabela '{tableName}' não existe. Nenhum registro foi deletado.");
                    return;
                }

                if (context.Employees.Any())
                {
                    var employees = context.Employees.ToList();
                    context.Employees.RemoveRange(employees);
                    context.SaveChanges();
                    Console.WriteLine("\nTodos os registros foram deletados com sucesso.");
                }
                else
                {
                    Console.WriteLine("\nNenhum registro a ser deletado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao deletar registros: {ex.Message}");
            }
        }

        public void InsertEmployees(int count)
        {
            var tableName = GetEmployeeTableName();

            try
            {
                if (!TableExists(tableName))
                {
                    Console.WriteLine($"\nA tabela '{tableName}' não existe. Não foi possível inserir registros.");
                    return;
                }

                var random = new Random();
                var dataGenerator = new DataGenerator();

                Console.WriteLine("\nInserindo registros...");
                for (int i = 0; i < count; i++)
                {
                    var employee = new Employee
                    {
                        Name = dataGenerator.GetRandomName(),
                        Age = random.Next(18, 51),
                        Address = dataGenerator.GetRandomCity()
                    };
                    context.Employees.Add(employee);
                }
                context.SaveChanges();
                Console.WriteLine($"\n{count} registros inseridos com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao inserir registros: {ex.Message}");
            }
        }

        public void GetAllEmployees()
        {
            var tableName = GetEmployeeTableName();

            try
            {
                if (!TableExists(tableName))
                {
                    Console.WriteLine($"\nA tabela '{tableName}' não existe. Nenhum registro para mostrar.");
                    return;
                }

                var employees = context.Employees.ToList();
                if (employees.Count == 0)
                {
                    Console.WriteLine("\nNenhum registro de funcionário encontrado.");
                }
                else
                {
                    Console.WriteLine("\nRegistros de funcionários encontrados:\n");
                    foreach (var employee in employees)
                    {
                        Console.WriteLine($"Id: {employee.Id}, Nome: {employee.Name}, Idade: {employee.Age}, Endereço: {employee.Address}");
                    }
                    Console.WriteLine($"\nTotal de registros encontrados: {employees.Count}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao consultar registros: {ex.Message}");
            }
        }

        private bool TableExists(string tableName)
        {
            try
            {
                using var command = context.Database.GetDbConnection().CreateCommand();
                command.CommandText = @"
                    SELECT 1 FROM INFORMATION_SCHEMA.TABLES 
                    WHERE TABLE_NAME = @TableName AND TABLE_SCHEMA = 'dbo'";
                command.Parameters.Add(new SqlParameter("@TableName", tableName));

                context.Database.OpenConnection();
                using var reader = command.ExecuteReader();

                return reader.HasRows;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao verificar existência da tabela: {ex.Message}");
                return false;
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }

        private string GetEmployeeTableName()
        {
            var tableAttr = typeof(Employee).GetCustomAttribute<TableAttribute>();
            if (tableAttr != null)
                return tableAttr.Name;

            return typeof(Employee).Name;
        }
    }
}
