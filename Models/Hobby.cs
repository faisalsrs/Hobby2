using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeltExam3.Models
{
    public class Hobby
    {
        [Key]
        public int HobbyId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [DataType(DataType.Text)]
        [MinLength(2)]
        [Display(Name = "Name:")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [DataType(DataType.Text)]
        [MinLength(2)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int UserId { get; set; } //foreign key
        public User Creator { get; set; } // navigation for the foreign key property when you 
        public List<JOIN> CreatedJOINs { get; set; }
    }
}