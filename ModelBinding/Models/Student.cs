
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstAproch.Models
{
    public class Student
    {
        [Key]
        public int  id { get; set; }
        [Column("StudentName",TypeName ="varchar(200)")]
        [Required]
        public string name  { get; set; }
        [Required]
        [Column("StudentGender", TypeName = "varchar(20)")]

        public string Gender { get; set; }
        [Required]
        public int? age { get; set; }
        [Required]
        public int? Standard { get; set; }
    }
}
