using BlogManagement.Application.Contracts.Article;

namespace BlogManagement.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        EditArticle GetDetails(int id);
        List<ArticleViewModel> Search(ArticleSearchModel searchModel);
    }
}
