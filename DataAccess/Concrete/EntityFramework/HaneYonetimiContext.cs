using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class HaneYonetimiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=AYHAN;Database=HaneYonetimi;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        // DbSet Tanımları
        public DbSet<FamilyPerson> FamilyPersons { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseItem> ExpenseItems { get; set; }
        public DbSet<MarketItem> MarketItems { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<MarketItemPhoto> MarketItemPhotos { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User - Role ilişki konfigürasyonu
            modelBuilder.Entity<FamilyPerson>()
                .HasOne(u => u.Role)
                .WithMany(r => r.FamilyPersons)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Expense - ExpenseItem ilişki konfigürasyonu
            modelBuilder.Entity<ExpenseItem>()
                .HasOne(ei => ei.Expense)
                .WithMany(e => e.ExpenseItems)
                .HasForeignKey(ei => ei.ExpenseId)
                .OnDelete(DeleteBehavior.Cascade);


            //ExpenseItem - MarketItem ilişki konfigürasyonu
            modelBuilder.Entity<ExpenseItem>()
                .HasOne(ei => ei.MarketItem)
                .WithMany(mi => mi.ExpenseItems)
                .HasForeignKey(ei => ei.MarketItemId)
                .OnDelete(DeleteBehavior.Restrict);

            // MarketItem - Category ilişki konfigürasyonu
            modelBuilder.Entity<MarketItem>()
                .HasOne(mi => mi.Category)
                .WithMany(c => c.MarketItems)
                .HasForeignKey(mi => mi.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Expense - User ilişki konfigürasyonu
            modelBuilder.Entity<Expense>()
                .HasOne(e => e.FamilyPerson)
                .WithMany(u => u.Expenses)
                .HasForeignKey(e => e.FamilyPersonId)
                .OnDelete(DeleteBehavior.Restrict);

            // Income - User ilişki konfigürasyonu
            modelBuilder.Entity<Income>()
                .HasOne(i => i.FamilyPerson)
                .WithMany(u => u.Incomes)
                .HasForeignKey(i => i.FamilyPersonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MarketItem>()
               .HasOne(mi => mi.Unit)
               .WithMany(u => u.MarketItems)
               .HasForeignKey(mi => mi.UnitId)
               .OnDelete(DeleteBehavior.Restrict); // Birim silindiğinde market item'ları silme
            modelBuilder.Entity<Expense>()
                .HasMany(e => e.ExpenseItems)
                .WithOne(ei => ei.Expense)
                .HasForeignKey(ei => ei.ExpenseId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MarketItem>()
                .HasMany(mi => mi.Photos)
                .WithOne(mp => mp.MarketItem)
                .HasForeignKey(mp => mp.MarketItemId)
                .OnDelete(DeleteBehavior.Cascade); // MarketItem silindiğinde fotoğrafları da silinir


            // Seed Data: Role
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" }
            );

            // Seed Data: Category
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Gıda" },
                new Category { Id = 2, Name = "Temizlik" },
                new Category { Id = 3, Name = "Elektronik" }
            );
            modelBuilder.Entity<Unit>().HasData(
                new Unit { Id = 1, Name = "Adet" },
                new Unit { Id = 2, Name = "Kg" },
                new Unit { Id = 3, Name = "Litre" }
            );
        }
    }
}
