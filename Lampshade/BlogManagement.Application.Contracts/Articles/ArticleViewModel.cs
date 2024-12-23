﻿namespace BlogManagement.Application.Contracts.Articles
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Picture { get; set; }
        public string PublishDate { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
    }
}
