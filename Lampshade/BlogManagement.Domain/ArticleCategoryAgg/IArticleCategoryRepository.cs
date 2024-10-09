using _0_Framework.Domain;
using BlogManagement.Application.Contract;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository : IRepository<int,ArticleCategory>
    {

        EditArticleCategory GetDetails(int id);
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);

        


    }
}
