using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Aggregates;
using AquaEngine.API.Control.Domain.Model.Aggregates;

// using AquaEngine.API.boundedcontext.Domain.Model.Aggregates;


using AquaEngine.API.Planning.Domain.Model.Aggregates;
using AquaEngine.API.Analytics.Domain.Model.Aggregate;
using AquaEngine.API.Control.Domain.Model.ValueObjects;
using AquaEngine.API.Planning.Domain.Model.Entities;
using AquaEngine.API.Profiles.Domain.Model.Aggregates;
using AquaEngine.API.Sales.Domain.Model.Aggregates;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
   protected override void OnConfiguring(DbContextOptionsBuilder builder)
   {
      builder.AddCreatedUpdatedInterceptor();
      base.OnConfiguring(builder);
   }

   protected override void OnModelCreating(ModelBuilder builder)
   {
    base.OnModelCreating(builder);
  
      builder.Entity<MonitoredMachine>()
       .ToTable("monitored_machines")
       .HasKey(mm => mm.Id);

      builder.Entity<Product>()
       .ToTable("Products")
       .HasKey(p => p.Id);

      builder.Entity<Product>()
       .Property(p => p.Id)
       .IsRequired()
       .ValueGeneratedOnAdd();

      builder.Entity<Product>()
       .Property(p => p.Name)
       .IsRequired();

      builder.Entity<Product>()
       .Property(p => p.QuantityPerUnit)
       .IsRequired();

      builder.Entity<Product>()
       .Property(p => p.UnitPrice)
       .IsRequired();

      builder.Entity<Product>()
       .Property(p => p.Quantity)
       .IsRequired();

      // Mapear solo UserId (int), no UserIdValue (ValueObject)
      builder.Entity<Product>()
       .Property(p => p.UserId)
       .HasColumnName("UserId")
       .IsRequired();

      // Ignorar la propiedad UserIdValue
      builder.Entity<Product>()
       .Ignore(p => p.UserIdValue);

      builder.UseSnakeCaseNamingConvention();

      builder.Entity<MonitoredMachine>()
       .Property(mm => mm.Id)
       .IsRequired()
       .ValueGeneratedOnAdd();

      builder.Entity<MonitoredMachine>()
       .Property(mm => mm.Name)
       .IsRequired();

        builder.Entity<MonitoredMachine>()
       .Property(mm => mm.Status)
       .IsRequired();

        builder.Entity<MonitoredMachine>()
       .Property(mm => mm.UrlToImage)
       .IsRequired();

        builder.Entity<MonitoredMachine>()
       .Property(mm => mm.UserId)
       .HasColumnName("UserId")
       .IsRequired();

        // Maintenance
        builder.Entity<Maintenance>()
       .ToTable("maintenances")
       .HasKey(ma => ma.Id);

     builder.Entity<Maintenance>()
       .Property(ma => ma.Id)
       .IsRequired()
       .ValueGeneratedOnAdd();

     builder.Entity<Maintenance>()
       .Property(ma => ma.TechnicianName)
       .IsRequired();

     builder.Entity<Maintenance>()
       .Property(ma => ma.IssueType)
       .IsRequired();

     builder.Entity<Maintenance>()
       .Property(ma => ma.Description)
       .IsRequired();

     builder.Entity<Maintenance>()
       .Property(ma => ma.AdditionalInfo)
       .IsRequired();

     builder.Entity<Maintenance>()
       .Property(ma => ma.MonitoredMachineId)
       .IsRequired();

     builder.UseSnakeCaseNamingConvention();
      
      // Planning Bounded Context
      builder.Entity<OrderingMachinery>().HasKey(o => o.Id);
      builder.Entity<OrderingMachinery>().Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<OrderingMachinery>().Property(o => o.Name).IsRequired().HasMaxLength(30);
      builder.Entity<OrderingMachinery>().Property(o => o.UrlToImage).IsRequired().HasMaxLength(250);
      builder.Entity<OrderingMachinery>().Property(o => o.Status).IsRequired().HasMaxLength(30);
      
      // Invoice Bounded Context
      builder.Entity<Invoice>().ToTable("Invoice").HasKey(i => i.Id);
      builder.Entity<Invoice>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<Invoice>().Property(i => i.Client).IsRequired().HasMaxLength(100);
      builder.Entity<Invoice>().Property(i => i.Product).IsRequired().HasMaxLength(100);
      builder.Entity<Invoice>().Property(i => i.Quantity).IsRequired().HasColumnType("int");
      builder.Entity<Invoice>().Property(i => i.Price).IsRequired().HasColumnType("decimal(18,2)");
      builder.Entity<Invoice>().Property(i => i.Total).IsRequired().HasColumnType("decimal(18,2)");
      builder.Entity<Invoice>().Property(i => i.Date).IsRequired().HasColumnType("datetime");
      
    
    
      builder.Entity<Cart>().HasKey(c => c.Id);
      builder.Entity<Cart>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<Cart>().Property(c => c.Name).IsRequired().HasMaxLength(30);
      builder.Entity<Cart>().Property(c => c.UrlToImage).IsRequired().HasMaxLength(250);
      
      // Profiles 

      builder.Entity<Profile>().HasKey(p => p.Id);
      builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
      
      builder.Entity<Profile>().OwnsOne(p => p.Name, n => 
       {
        n.WithOwner().HasForeignKey("Id");
        n.Property(p => p.Name).HasColumnName("FirstName");
        n.Property(p => p.LastName).HasColumnName("LastName");
       });

       builder.Entity<Profile>().OwnsOne(p => p.Email, n =>
       {
        n.WithOwner().HasForeignKey("Id");
        n.Property(p => p.Address).HasColumnName("EmailAddress");
       });
       
       builder.Entity<Profile>().OwnsOne(p => p.Phone, n =>
       {
        n.WithOwner().HasForeignKey("Id");
        n.Property(p => p.Number).HasColumnName("PhoneNumber");
       });
       
       builder.Entity<Profile>().OwnsOne(p => p.Dni, n =>
       {
        n.WithOwner().HasForeignKey("Id");
        n.Property(p => p.Number).HasColumnName("Dni");
       });
      
      // IAM Context
      builder.Entity<User>().ToTable("Users").HasKey(u => u.Id);
      builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<User>().Property(u => u.Username).IsRequired();
      builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
      
      // Apply snake case naming convention
      builder.UseSnakeCaseNamingConvention();
   }
}
