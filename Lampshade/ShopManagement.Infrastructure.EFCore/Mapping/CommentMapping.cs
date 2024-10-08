﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.CommentAgg;
using System.Xml.Xsl;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(c => c.Id);

            builder.Property(x => x.Name).HasMaxLength(500);
            builder.Property(x=> x.Email).HasMaxLength(500);
            builder.Property(x=> x.Message).HasMaxLength(1000);


            builder.HasOne(x=> x.Product)
                .WithMany(x=> x.Comments)
                .HasForeignKey(x=>x.ProductId);
        }
    }
}
