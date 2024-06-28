using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace QuizManagerAPI.Models
{
    public class QuizManagerContext : DbContext
    {
        public DbSet<Questions> Questions { get; set; }

        public DbSet<Responses> Responses { get; set; }

        public QuizManagerContext(DbContextOptions options) : base(options)
        {
        
        }


    }
}
