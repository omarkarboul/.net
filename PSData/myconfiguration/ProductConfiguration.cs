using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data.myconfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //configuring many to many relation
            builder.HasMany(p => p.Providers).WithMany(p => p.Products).UsingEntity(t => t.ToTable("Providings"));
            //configuring 0..1 <=> * relation
            builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryFK).OnDelete(DeleteBehavior.Cascade);
            //configuring 1..1 <=> * relation
            //builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryFK).IsRequired().OnDelete(DeleteBehavior.Cascade);
            //configuring inheritance  table per hierarchy tph
            //builder.HasDiscriminator<int>("isBiological").
            //        HasValue<Product>(0).
            //        HasValue<Chemical>(2).
            //        HasValue<Biological>(1);

            
            
        }
    }
}
