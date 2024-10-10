using _0_Framework.Application;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        EditArticleCategory GetDetails(int id);
        OperationResult Edit(EditArticleCategory command);
        OperationResult Create(CreateArticleCategory command);
        List<ArticleCategoryViewModel> GetArticleCategories();
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);
    }
}
