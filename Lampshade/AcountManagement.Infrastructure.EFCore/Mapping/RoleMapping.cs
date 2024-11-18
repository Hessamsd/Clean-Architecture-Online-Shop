﻿using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcountManagement.Infrastructure.EFCore.Mapping
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();


            builder.OwnsMany<Permission>(x => x.Permissions, navigationBuilder =>
            {
                navigationBuilder.HasKey(x => x.Id);
                navigationBuilder.ToTable("RolePermissions");
                navigationBuilder.WithOwner(x => x.Role);

            });

        }
    }
}
