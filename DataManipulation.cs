namespace Desafio_02
{
    public class DataManipulation(MyDbContext context)
    {
        public void CreateTable() 
        {
            context.Database.EnsureCreated();
            Console.WriteLine("\nTabela criada com sucesso!");
        } 

        public void DeleteAllEmployees()
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

        public void InsertEmployees(int count)
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

        public void GetAllEmployees() 
        {
            var employees = context.Employees.ToList();
            if (employees.Count == 0)
            {
                Console.WriteLine("\nNenhum registro de funcionário encontrado.");
            }
            else
            {
                Console.WriteLine("\nRegistros de funcionários encontrados:");
                foreach (var employee in employees)
                {
                    Console.WriteLine($"Id: {employee.Id}, Nome: {employee.Name}, Idade: {employee.Age}, Endereço: {employee.Address}");
                }
            }
        }
    }
}
