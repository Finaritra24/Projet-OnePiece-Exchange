using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnePiece.Models;

public class AppDbContext : DbContext
{
    public DbSet<Team> Teams { get; set; }
    public DbSet<Pirate> Pirates { get; set; }
    public DbSet<Treasure> Treasures { get; set; }
    public DbSet<Proposal> Proposals { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-3ILLFK8;Database=piece;Trusted_Connection=True;MultipleActiveResultSets=true");

        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuration des colonnes de type decimal
        modelBuilder.Entity<Proposal>()
            .Property(p => p.ProposedOfferAmount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Proposal>()
            .Property(p => p.CounterOfferAmount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Treasure>()
            .Property(t => t.Price)
            .HasPrecision(18, 2);
        modelBuilder.Entity<Proposal>()
            .HasOne(p => p.ProposingPirate)
            .WithMany()  // Pas de navigation inverse
            .HasForeignKey(p => p.ProposingPirateID)
            .OnDelete(DeleteBehavior.Restrict);  // Pas de suppression en cascade

        modelBuilder.Entity<Proposal>()
            .HasOne(p => p.RequestingPirate)
            .WithMany()  // Pas de navigation inverse
            .HasForeignKey(p => p.RequestingPirateID)
            .OnDelete(DeleteBehavior.Restrict);  // Pas de suppression en cascade

        modelBuilder.Entity<Proposal>()
            .HasOne(p => p.ProposedTreasure)
            .WithMany()  // Pas de navigation inverse
            .HasForeignKey(p => p.ProposedTreasureID)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }

public DbSet<OnePiece.Models.Category> Category { get; set; } = default!;
}
