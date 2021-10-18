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

            modelBuilder.Entity<Message>().Property(p => p.Id).IsRequired();
            modelBuilder.Entity<Message>().Property(p => p.AccountId);
            modelBuilder.Entity<Message>().Property(p => p.DialogueId).IsRequired();
            modelBuilder.Entity<Message>().Property(p => p.SendDate).IsRequired();
            modelBuilder.Entity<Message>().Property(p => p.Text).IsRequired();

            modelBuilder.Entity<Dialogue>().Property(p => p.Id).IsRequired();
            modelBuilder.Entity<Dialogue>().Property(p => p.FirstMemberAccountId).IsRequired();
            modelBuilder.Entity<Dialogue>().Property(p => p.SecondMemberAccountId).IsRequired();

        }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Dialogue> Dialogues { get; set; }
    }
}
