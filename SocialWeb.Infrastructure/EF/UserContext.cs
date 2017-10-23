using Microsoft.EntityFrameworkCore;
using SocialWeb.Core.Domain;

namespace SocialWeb.Infrastructure.EF
{
    public class UserContext : DbContext
    {
        //private readonly SqlSettings _settings;
        public DbSet<User> User { get; set; }

        public UserContext(DbContextOptions<UserContext> options) 
            : base(options)
        {
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if(_settings.InMemory)
            //{
            //    optionsBuilder.UseInMemoryDatabase();

            //    return;    
            //}
            //optionsBuilder.UseSqlServer(_settings.ConnectionString);

        

            string connectionString = "Server=mssql6.gear.host;User Id=socialweb;Password=Iv5UtZ13!-x0;Database=socialweb";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.Posts)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}