using Microsoft.Data.SqlClient;
using System;

namespace Desafio_02
{
    public class DataBaseManager
    {
        private readonly string connectionString = "Data Source=WSFAR37KT7G;Initial Catalog=Funcionarios;User ID=sa;Password=Spike369852;TrustServerCertificate=True";
        private readonly string tableName = "Funcionario";

        public void CreateTable()
        {
            using SqlConnection connection = new(connectionString);
            connection.Open();
            string createTableQuery = $@"
                CREATE TABLE {tableName} (
                    Id INT NOT NULL PRIMARY KEY,
                    Nome VARCHAR(50) NOT NULL,
                    Idade INT NOT NULL,
                    Endereco VARCHAR(100) NOT NULL
                );";

            using SqlCommand command = new(createTableQuery, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("\nTabela criada com sucesso!");
        }

        public bool CheckIdExists(int id)
        {
            string query = "SELECT COUNT(*) FROM Funcionario WHERE Id = @Id";
            using SqlConnection connection = new (connectionString);
            using SqlCommand command = new (query, connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }

        public void InsertData(int numRows)
        {
            Random random = new();

            string[] namePersons = {
            "João", "Pedro", "Lucas", "Mateus", "Marcos", "Felipe", "Gabriel", "Rafael", "Bruno", "Gustavo",
            "Ricardo", "Daniel", "Eduardo", "André", "Fernando", "Rodrigo", "Vinícius", "Thiago", "Guilherme", "Leonardo",
            "Matheus", "Carlos", "Paulo", "Alexandre", "Caio", "Vitor", "Diego", "Marcelo", "Ramon", "Sérgio",
            "Roberto", "Renato", "Cristiano", "Anderson", "Juliano", "Elias", "Samuel", "Murilo", "Otávio", "César",
            "Henrique", "Júlio", "Wesley", "Everton", "Douglas", "Fabiano", "Tiago", "Uillian", "Wagner", "Wilson",
            "Maria", "Ana", "Julia", "Sofia", "Laura", "Beatriz", "Helena", "Mariana", "Isabela", "Lara",
            "Valentina", "Giovana", "Eduarda", "Livia", "Nicole", "Sophia", "Manuela", "Gabriela", "Yasmin", "Cecília",
            "Eloá", "Sarah", "Alice", "Rebeca", "Rafaela", "Isis", "Vitória", "Larissa", "Esther", "Lorena",
            "Laís", "Fernanda", "Amanda", "Carolina", "Camila", "Letícia", "Bianca", "Luiza", "Isadora", "Agatha",
            "Antonella", "Maya", "Aurora", "Alana", "Heloísa", "Clara", "Melissa", "Leticia", "Heloah", "Maysa"
            };

            string[] cities = {
            "São Paulo-SP", "Rio de Janeiro-RJ", "Belo Horizonte-MG", "Porto Alegre-RS", "Curitiba-PR",
            "Salvador-BA", "Fortaleza-CE", "Recife-PE", "Manaus-AM", "Belém-PA",
            "Brasília-DF", "Campinas-SP", "São Bernardo do Campo-SP", "Osasco-SP", "Santos-SP",
            "Guarulhos-SP", "Ribeirão Preto-SP", "São José dos Campos-SP", "Niterói-RJ", "Duque de Caxias-RJ",
            "Joinville-SC", "Florianópolis-SC", "Blumenau-SC", "Londrina-PR", "Maringá-PR",
            "Cuiabá-MT", "Campo Grande-MS", "Goiânia-GO", "Anápolis-GO", "Uberlândia-MG",
            "Contagem-MG", "Juiz de Fora-MG", "Montes Claros-MG", "Vitória-ES", "Serra-ES",
            "Teresina-PI", "São Luís-MA", "Maceió-AL", "Aracaju-SE", "Natal-RN",
            "João Pessoa-PB", "Palmas-TO", "Boa Vista-RR", "Macapá-AP", "Porto Velho-RO",
            "Rio Branco-AC", "Caxias do Sul-RS", "Pelotas-RS", "Novo Hamburgo-RS", "Canoas-RS"
            };

            using SqlConnection connection = new(connectionString);
            connection.Open();
            for (int i = 0; i < numRows; i++)
            {
                int id;
                string name = namePersons[random.Next(namePersons.Length)];
                int age = random.Next(18, 51);
                string city = cities[random.Next(cities.Length)];

                do
                {
                    id = random.Next(1, 10001);
                } while (CheckIdExists(id));

                string insertQuery = "INSERT INTO Funcionario (Id, Nome, Idade, Endereco) VALUES (@Id, @Nome, @Idade, @Endereco)";

                using SqlCommand command = new(insertQuery, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Nome", name);
                command.Parameters.AddWithValue("@Idade", age);
                command.Parameters.AddWithValue("@Endereco", city);

                command.ExecuteNonQuery();
            }
            Console.WriteLine("\nDados inseridos com sucesso!");
        }

        public void ConsultData()
        {
            using SqlConnection connection = new(connectionString);
            connection.Open();
            string selectQuery = "SELECT * FROM Funcionario";
            using SqlCommand command = new(selectQuery, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["Id"]}, Nome: {reader["Nome"]}, Idade: {reader["Idade"]}, Endereco: {reader["Endereco"]}");
            }
        }

        public void DeleteTable()
        {
            using SqlConnection connection = new(connectionString);
            try
            {
                connection.Open();

                string dropTableQuery = $"DROP TABLE {tableName}";
                using SqlCommand command = new(dropTableQuery, connection);
                command.ExecuteNonQuery();
                Console.WriteLine($"Tabela '{tableName}' excluída com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir a tabela '{tableName}': {ex.Message}");
            }
        }
    }
}
