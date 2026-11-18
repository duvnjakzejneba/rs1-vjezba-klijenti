using KlijentiVjezba.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace KlijentiVjezba.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Klijent> Klijenti => Set<Klijent>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Klijent>().HasData(
            new Klijent()
            {
                Id = 1,
                DatumKreiranja = new DateOnly(2026, 11, 17),
                Naziv = "Klijent 1",
                Grad= "Sarajevo",
                Email = "klijen1@gmail.com"
            },
            new Klijent()
            {
                Id = 2,
                DatumKreiranja = new DateOnly(2026, 11, 17),
                Naziv = "Klijent 2",
                Grad= "Mostar",
                Email = "klijen2@gmail.com"
            }
        ); 
    }
}