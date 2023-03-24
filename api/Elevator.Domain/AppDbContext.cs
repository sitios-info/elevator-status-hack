using System.Text.Json;
using Elevator.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Elevator.Domain;

using Elevator = Data.Elevator;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public required DbSet<Data.Elevator> Elevators { get; set; }
    public required DbSet<OperationChangeEvent> OperationChangedEvents { get; set; }
    public required DbSet<Operator> Operators { get; set; }
    public required DbSet<MetaDataSourceInfo> MetaDataSourceInfos { get; set; }
    public required DbSet<GeoLocation> GeoLocations { get; set; }
    public required DbSet<PlannedMaintenance> PlannedMaintenances { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Data.Elevator>()
            .Property(b => b.Properties)
            .HasConversion(
                v => JsonSerializer.Serialize(v, JsonSerializerOptions.Default),
                v => JsonSerializer.Deserialize<Dictionary<string, string>>(v, JsonSerializerOptions.Default)
                     ?? new Dictionary<string, string>(),
                ValueComparer.CreateDefault(typeof(Dictionary<string, string>), true));

#if DEBUG
        modelBuilder.Entity<Elevator>()
            .HasData(DummyData.DummyElevator1);
#endif
    }
}