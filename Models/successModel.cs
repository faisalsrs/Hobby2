using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltExam3.Models
{
    [NotMapped]
    public class successModel
    {
        public List<Hobby> allH { get; set; }
        public User userLogged { get; set; }
        public Hobby hobs { get; set; }
        public JOIN isJOIN { get; set; }

    }
}