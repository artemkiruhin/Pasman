using Microsoft.EntityFrameworkCore;
using Pasman.Domain.Entities;

namespace Pasman.Database.SQLite;

public class AppDbContext : DbContext
{
    public DbSet<AccountData> AccountData { get; set; } = null!;
    public DbSet<PasswordNote> PasswordNotes { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=passwords.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AccountData>(options =>
        {
            options.HasNoKey();
            options.Property(x => x.KeyHash).IsRequired();
        });
        
        
        modelBuilder.Entity<PasswordNote>(options =>
        {
            options.HasKey(x => x.Id);
            options.Property(x => x.Description).IsRequired();
            options.Property(x => x.PasswordEncrypted).IsRequired();
        });
    }
}