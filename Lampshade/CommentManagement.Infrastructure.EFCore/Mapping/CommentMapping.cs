﻿using CommentManagement.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommentManagement.Infrastructure.EFCore.Mapping
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(c => c.Id);

            builder.Property(x => x.Name).HasMaxLength(500);
            builder.Property(x=> x.Email).HasMaxLength(500);
            builder.Property(x=> x.WebSite).HasMaxLength(500);
            builder.Property(x=> x.Message).HasMaxLength(1000);
                      

        }
    }   
}
