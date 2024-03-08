using Microsoft.EntityFrameworkCore;


namespace ApiAppTv.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Customer> Customer { get; set; } = null!;
        public DbSet<Movie> Movie { get; set; } = null!;
        public DbSet<Subscription> Subscription{ get; set; } = null!;
        public DbSet<SubtitleLanguage> SubtitleLanguage{ get; set; } = null!;





    }
}

