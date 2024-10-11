using _0_Framework.Application;

namespace BlogManagement.Application.Contracts.Articles
{
    public interface IArticleApplication
    {
        OperationResult Create(CreateArticle command);
        OperationResult Edit(EditArticle command);
        EditArticle GetDetails(int id);
        List<ArticleViewModel> Search(ArticleSearchModel searchModel);

    }
}
