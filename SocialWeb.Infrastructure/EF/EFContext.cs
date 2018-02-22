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
        public DbSet<Conversation> Conversation { get; set; }
        public DbSet<Message> Message { get; set; }

        public EFContext(DbContextOptions<EFContext> options) 
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server= DESKTOP-ROG63LI\\SQLEXPRESS; Database= socialweb; Integrated Security=True;";
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
 
            modelBuilder.Entity<UserConversation>()
                .HasKey(x => new {x.UserId, x.ConversationId});
 
            modelBuilder.Entity<UserConversation>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserConversations)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserConversation>()
                .HasOne(x => x.Conversation)
                .WithMany(x => x.UserConversations)
                .HasForeignKey(x => x.ConversationId);

           modelBuilder.Entity<Conversation>()
                .HasMany(x => x.Messages)
                .WithOne(x => x.Conversation)
                .HasForeignKey(x => x.ConversationId);

            modelBuilder.Entity<Post>()
                .HasMany(x => x.Comments)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}