using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltExam3.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Display(Name = "First Name")]
        [Required]
        [MinLength(2)]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Name can only have letters and spaces no numbers and must be more than 2 letters!")]
        public string fname { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        [MinLength(2)]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Name can only have letters and spaces no numbers and must be more than 2 letters!")]
        public string lname { get; set; }
        [Display(Name = "Username")]
        [RegularExpression("^[0-9A-Za-z]+$", ErrorMessage = "Alias can only have letters and numbers no spaces!")]
        [MinLength(3)]
        [Required]
        public string username { get; set; }
        [MinLength(8, ErrorMessage = "Must be longers than 8 characters")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("password")]
        [NotMapped]
        public string cpassword { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
        public DateTime updatedAt { get; set; } = DateTime.Now;


        public List<Hobby> CreatedHobbies { get; set; } // list of hobbies the user created
        public List<JOIN> CreatedJOINs { get; set; } // list of RSVPs by the users // Many to Many //Users can attend many users 

    }
}