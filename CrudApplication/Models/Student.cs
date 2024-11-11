using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApplication.net4.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name")]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name")]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name")]
        [Column(TypeName = "varchar(50)")]
        public string PhoneNum { get; set; }
  
        
    }

}
