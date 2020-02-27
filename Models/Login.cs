using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BeltExam3.Models
{
    [NotMapped]
    public class Login
    {
        [Display(Name = "Username")]
        [Required]
        [MinLength(2)]
        public string lusername { get; set; }
        [DataType(DataType.Password)]
        public string lpassword { get; set; }
    }
}