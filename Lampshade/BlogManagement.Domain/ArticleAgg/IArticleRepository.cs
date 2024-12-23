﻿using _0_Framework.Domain;
using BlogManagement.Application.Contracts.Articles;

namespace BlogManagement.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<int,Article>
    {
        EditArticle GetDetails(int id);
        List<ArticleViewModel> Search(ArticleSearchModel searchModel);

        Article GetWithCategory(int id);
    }
}
