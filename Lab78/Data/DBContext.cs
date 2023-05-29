using Lab78.Models;
using Microsoft.EntityFrameworkCore;
using Attribute = System.Attribute;

namespace Lab78.Data;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options) { }

    public DbSet<Superhero> Superheroes { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Colour> Colours { get; set; }
    public DbSet<Race> Races { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Hero_attribute> HeroAttributes { get; set; }
    public DbSet<Hero_power> Heropowers { get; set; }
    public DbSet<Allignment> Allignments { get; set; }
    public DbSet<Attribute_db> Attributes { get; set; }
    public DbSet<Superpower> Superpowers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Superhero>().ToTable("superhero");
        modelBuilder.Entity<Gender>().ToTable("gender");
        modelBuilder.Entity<Colour>().ToTable("colour");
        modelBuilder.Entity<Race>().ToTable("race");
        modelBuilder.Entity<Publisher>().ToTable("publisher");
        modelBuilder.Entity<Hero_attribute>().HasNoKey().ToTable("hero_attribute");
        modelBuilder.Entity<Hero_power>().HasNoKey().ToTable("hero_power");
        modelBuilder.Entity<Allignment>().ToTable("allignment");
        modelBuilder.Entity<Attribute_db>().ToTable("attribute");
        modelBuilder.Entity<Superpower>().ToTable("superpower");
        
    }
}
