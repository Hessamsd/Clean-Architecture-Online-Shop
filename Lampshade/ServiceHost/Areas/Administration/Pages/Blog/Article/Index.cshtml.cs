using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.Articles
{
    public class IndexModel : PageModel
    {

        public ArticleSearchModel SearchModel;
        public List<ArticleViewModel> Articles;
        public SelectList ArticleCategories;


        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articlecategoryApplication;

        public IndexModel(IArticleApplication articleApplication, IArticleCategoryApplication articlecategoryApplication)
        {
            _articleApplication = articleApplication;
            _articlecategoryApplication = articlecategoryApplication;
        }

        public void OnGet(ArticleSearchModel searchModel)
        {
            ArticleCategories = new SelectList(_articlecategoryApplication.GetArticleCategories(),"Id","Name");
            Articles = _articleApplication.Search(searchModel);
        }
    }


}

