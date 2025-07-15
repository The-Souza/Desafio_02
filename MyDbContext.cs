using Microsoft.EntityFrameworkCore;

namespace Desafio_02
{
    public class MyDbContext : DbContext
    {
        private readonly string _connectionString;

        public MyDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
