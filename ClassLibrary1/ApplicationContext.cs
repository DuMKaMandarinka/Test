using System;
using System.Configuration;
using System.Reflection.Metadata;
using ClassLibrary1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class ApplicationContext : DbContext
{
    public DbSet<InfoPerson> InfoPersons { get; set; }

    public DbSet<Balance> Balances { get; set; }

    public DbSet<Currency> Currencies { get; set; }

    public DbSet<Transaction> Transactions { get; set; }

    public ApplicationContext()
       : base()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=Servers;Host=localhost;Database=BankDatabase;Port=5432;User Id=postgres;Password=root");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Balance>()
        .HasMany(e => e.TransactionSenders)
        .WithOne(e => e.BalanceSender)
        .HasForeignKey(e => e.SenderId)
        .IsRequired();

        modelBuilder.Entity<Balance>()
        .HasMany(e => e.TransactionRecepients)
        .WithOne(e => e.BalanceRecepient)
        .HasForeignKey(e => e.RecepientId)
        .IsRequired(false);
    }
}
