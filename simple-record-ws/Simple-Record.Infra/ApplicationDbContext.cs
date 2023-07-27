using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using simple_record.core.enums;
using simple_record.service.Models;
using System;
using System.Collections.Generic;

namespace simple_record.infra
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect())
                    {
                        databaseCreator.Create();
                    }
                    if (!databaseCreator.HasTables())
                    {
                        databaseCreator.CreateTables();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DbSet<PersonModel> Person { get; set; }
        public DbSet<PersonAddressModel> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonModel>(e =>
            {
                e.HasKey(p => p.Id);
                e.Property(p => p.Name).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
                e.Property(p => p.Document).IsRequired().HasMaxLength(14).HasColumnType("varchar(14)");
                e.Property(p => p.Type).IsRequired().HasColumnType("varchar(10)");
                e.Property(p => p.Contact).IsRequired().HasMaxLength(11).HasColumnType("varchar(11)");
                e.Property(p => p.Email).IsRequired(false).HasColumnType("varchar(40)");
                e.HasMany(p => p.Addresses)
                .WithOne()
                .HasForeignKey(a => a.PersonId);
            });

            modelBuilder.Entity<PersonAddressModel>(e =>
            {
                e.HasKey(p => p.Id);
                e.Property(p => p.Complement).IsRequired(false);
            });
        }

    }

}
