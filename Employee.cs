using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_02
{
    [Table("Funcionario")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int? Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("Nome")]
        public string? Name { get; set; }

        [Required]
        [Range(18, 51)]
        [Column("Idade")]
        public int? Age { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Endereco")]
        public string? Address { get; set; }
    }
}