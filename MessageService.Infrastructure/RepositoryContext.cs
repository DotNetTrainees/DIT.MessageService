using MessageService.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace MessageService.Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Message>().Property(p => p.ProfileId).IsRequired();
            modelBuilder.Entity<Message>().Property(p => p.DialogueId).IsRequired();
            modelBuilder.Entity<Message>().Property(p => p.SendDate).IsRequired();
            modelBuilder.Entity<Message>().Property(p => p.Text).IsRequired();

            modelBuilder.Entity<Dialogue>().Property(p => p.FirstMemberProfileId).IsRequired();
            modelBuilder.Entity<Dialogue>().Property(p => p.SecondMemberProfileId).IsRequired();
        }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Dialogue> Dialogues { get; set; }
    }
}
