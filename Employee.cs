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
        [StringLength(50)]
        [Column("Name", TypeName = "varchar(50)")]
        public string? Name { get; set; }

        [Required]
        [Range(18, 51)]
        [Column("Age")]
        public int? Age { get; set; }

        [Required]
        [StringLength(100)]
        [Column("Address", TypeName = "varchar(100)")]
        public string? Address { get; set; }
    }
}