using Microsoft.EntityFrameworkCore;
using SocialWeb.Core.Domain;

namespace SocialWeb.Infrastructure.EF
{
    public class EFContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Follow> Follow { get; set; }

        public EFContext(DbContextOptions<EFContext> options) 
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server= localhost; Database= socialweb; Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.Posts)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Comments)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Following)
                .WithOne(x => x.FromUser)
                .HasForeignKey(x => x.FromUserId);

             modelBuilder.Entity<User>()
                .HasMany(x => x.Followers)
                .WithOne(x => x.ToUser)
                .HasForeignKey(x => x.ToUserId);
        
            modelBuilder.Entity<Post>()
                .HasMany(x => x.Comments)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}