using Microsoft.EntityFrameworkCore;
using SquareFish.Core;

using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SquareFish.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Data Seeding
            // modelBuilder.Seed();

            // Default Schema
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Booking>().HasKey(x => x.Id).HasAnnotation("DatabaseGenerated", "Identity");
            modelBuilder.Entity<Booking>(
             sa =>
             {
                 sa.Property(p => p.Name).IsRequired();
                 sa.Property(p => p.Status).IsRequired();
                 sa.Property(p => p.CreatedAt).IsRequired();
             });

            modelBuilder.Entity<Leader>().HasKey(x => x.Id).HasAnnotation("DatabaseGenerated", "Identity");
            modelBuilder.Entity<Leader>().HasData(
                new Leader(1, "Michael Scott"),
                new Leader(2, "Jim Halpert"),
                new Leader(3, "Pam Beesly"),
                new Leader(4, "Dwight Schrute")
                );
            modelBuilder.Entity<BookingLeader>().HasAlternateKey(bl => new { bl.BookingId, bl.LeaderId });

            modelBuilder.Entity<BookingLeader>()
                .HasOne<Leader>(bl => bl.Leader)
                .WithMany(s => s.BookingLeader)
                .HasForeignKey(bl => bl.LeaderId);


            modelBuilder.Entity<BookingLeader>()
                .HasOne<Booking>(bl => bl.Booking)
                .WithMany(s => s.BookingLeader)
                .HasForeignKey(bl => bl.BookingId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
