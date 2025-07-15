using Microsoft.Data.SqlClient;
using Dapper;

namespace Desafio_02
{
    public class DataManipulation(MyDbContext context)
    {
        public void CreateTable() 
        {
            try 
            {
                context.Database.EnsureCreated();
                Console.WriteLine("\nTabela criada com sucesso!");
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"\nErro ao criar tabela: {ex.Message}");
                return;
            }
        } 

        public void DeleteAllEmployees()
        {
            try 
            { 
                var employees = context.Employees.ToList();
                if (employees.Count != 0)
                {
                    context.Employees.RemoveRange(employees);
                    context.SaveChanges();
                    Console.WriteLine("\nDeletando registros...");
                }
                else
                {
                    Console.WriteLine("\nNenhum registro a ser deletado.");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao deletar registros: {ex.Message}");
                return;
            }
        }

        public void InsertEmployees(int count)
        {
            try
            {
                var random = new Random();
                var dataGenerator = new DataGenerator();

                Console.WriteLine("\nInserindo registros...");
                for (int i = 0; i < count; i++)
                {
                    var employee = new Employee
                    {
                        Name = dataGenerator.RandomName(),
                        Age = random.Next(18, 51),
                        Address = dataGenerator.RandomCity()
                    };
                    context.Employees.Add(employee);
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao inserir registros: {ex.Message}");
                return;
            }
        }

        public void GetAllEmployees() 
        {
            try 
            {
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
                return;
            }
        }
    }
}
