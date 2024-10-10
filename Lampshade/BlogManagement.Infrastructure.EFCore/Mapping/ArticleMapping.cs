using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.EFCore.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Title).HasMaxLength(500);
            builder.Property(a => a.ShortDescription).HasMaxLength(1000);
            builder.Property(a => a.Picture).HasMaxLength(500);
            builder.Property(a => a.PictureAlt).HasMaxLength(500);
            builder.Property(a => a.PictureTitle).HasMaxLength(500);
            builder.Property(a => a.Slug).HasMaxLength(600);
            builder.Property(a => a.Keywords).HasMaxLength(100);
            builder.Property(a => a.MetaDescription).HasMaxLength(150);
            builder.Property(a => a.CanonicalAddress).HasMaxLength(1000);

            builder.HasOne(x=>x.Category).WithMany(x=> x.Articles).HasForeignKey(x=>x.CategoryId);
        }
    }
}
