using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDemo1.Models
{
    [Table("student")]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public decimal Percentage { get; set; }
    }
}
