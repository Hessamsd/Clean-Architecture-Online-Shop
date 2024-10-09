using _0_Framework.Application;

namespace BlogManagement.Application.Contract
{
    public interface IArticleCategoryApplication
    {
        OperationResult Create(CreateArticleCategory command);
        OperationResult Edit(EditArticleCategory command);
        EditArticleCategory GetDetails(int id);
         List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);
    }
}
