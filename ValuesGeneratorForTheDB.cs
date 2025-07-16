namespace Desafio_02
{
    public class ValuesGeneratorForTheDB
    {
        private readonly string[] Names = {
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

        private readonly string[] Cities = {
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

        private readonly Random Random = new();

        public string GetRandomName() => Names[Random.Next(Names.Length)];
        public string GetRandomCity() => Cities[Random.Next(Cities.Length)];
    }
}
