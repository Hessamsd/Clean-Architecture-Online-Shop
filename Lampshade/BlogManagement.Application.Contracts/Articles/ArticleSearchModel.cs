﻿using BlogManagement.Application.Contracts.ArticleCategory;

namespace BlogManagement.Application.Contracts.Articles
{
    public class ArticleSearchModel
    {
        public string Title { get; set; }
        public int CategoryId { get; set; }

    }
}
