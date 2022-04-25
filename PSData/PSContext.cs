using Microsoft.EntityFrameworkCore;
using PS.Data.myconfiguration;
using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSData
{
    public class PSContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Chemical> Chemicals { get; set; }
        public DbSet<Biological> Biologicals { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Achat> Achats { get; set; }

        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog=ProductStoreDB;
                                        Integrated Security=true;
                                        MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);



        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            // modelBuilder.Entity<Category>().ToTable("MyCategories").
            //    HasKey(c => c.CategoryId);
            //modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(50);

            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            //configuring inheritance table per type : tpt
            modelBuilder.Entity<Chemical>().ToTable("chemicals");
            modelBuilder.Entity<Biological>().ToTable("biologicals");

            //config table porteuse de données
            modelBuilder.Entity<Achat>().HasKey(a => new { a.ClientFK, a.ProductFK, a.DateAchat });
            base.OnModelCreating(modelBuilder);


        }
    }
}
