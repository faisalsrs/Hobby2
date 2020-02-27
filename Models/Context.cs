using Microsoft.EntityFrameworkCore;

namespace BeltExam3.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<JOIN> Join { get; set; }

    }
}