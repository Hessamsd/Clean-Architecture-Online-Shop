using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.EFCore.Mapping
{
    public class ArticleCategoryMapping : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategories");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name).HasMaxLength(500);
            builder.Property(a => a.Description).HasMaxLength(2000);
            builder.Property(a => a.Picture).HasMaxLength(500);
            builder.Property(a => a.PictureAlt).HasMaxLength(500);
            builder.Property(a => a.PictureTitle).HasMaxLength(500);
            builder.Property(a => a.Slug).HasMaxLength(600);
            builder.Property(a => a.Keywords).HasMaxLength(100);
            builder.Property(a => a.MetaDescription).HasMaxLength(150);
            builder.Property(a => a.CanonicalAddress).HasMaxLength(1000);

            builder.HasMany(x=> x.Articles).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
        }
    }
}
