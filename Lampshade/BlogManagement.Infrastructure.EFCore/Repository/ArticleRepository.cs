﻿using _0_Framework.Application;
using _0_Framework.Infrastructure;
using BlogManagement.Application.Contracts.Articles;
using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EFCore.Repository
{
    public class ArticleRepository : RepositoryBase<int, Article>, IArticleRepository
    {

        private readonly BlogContext _context;

        public ArticleRepository(BlogContext context) : base(context)
        {
            _context = context;
        }

        public EditArticle GetDetails(int id)
        {
            return _context.Articles.Select(a => new EditArticle
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                MetaDescription = a.MetaDescription,
                ShortDescription = a.ShortDescription,
                PictureAlt = a.PictureAlt,
                PictureTitle = a.PictureTitle,
                Keywords = a.Keywords,
                CategoryId = a.CategoryId,
                Slug = a.Slug,
                PublishDate = a.PublishDate.ToFarsi(),
                CanonicalAddress = a.CanonicalAddress

            }).FirstOrDefault(x => x.Id == id);
        }

        public Article GetWithCategory(int id)
        {
            return _context.Articles.Include(x => x.Category).FirstOrDefault(x => x.Id == id);

        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            var query = _context.Articles.Select(x => new ArticleViewModel
            {

                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription.Substring(0, Math.Min(x.ShortDescription.Length, 50)) + "...",
                Category = x.Category.Name,
                PublishDate = x.PublishDate.ToFarsi(),
                Picture = x.Picture,

            });

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));


            if (searchModel.CategoryId > 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
