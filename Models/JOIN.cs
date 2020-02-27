using System;
using System.ComponentModel.DataAnnotations;
namespace BeltExam3.Models
{
    public class JOIN
    {
        [Key]
        public int JOINId { get; set; } // primary key
        public int UserId { get; set; } //foreign key
        public int HobbyId { get; set; } //foreign key
        public User UserJOIN { get; set; } //navigation property
        public Hobby PostJOIN { get; set; } //navigation property
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}