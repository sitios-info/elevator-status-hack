using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace Elevator.Domain;

public class DbContext: Microsoft.EntityFrameworkCore.DbContext
{
    internal DbSet<Data.Elevator> Elevators { get; set; } = null!;

    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options.UseSqlite("elevator");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Data.Elevator>()
            .Property(b => b.Properties)
            .HasConversion(
                v => JsonSerializer.Serialize(v, JsonSerializerOptions.Default),
                v => JsonSerializer.Deserialize<Dictionary<string, string>>(v, JsonSerializerOptions.Default) 
                     ?? new Dictionary<string, string>());
    }
}