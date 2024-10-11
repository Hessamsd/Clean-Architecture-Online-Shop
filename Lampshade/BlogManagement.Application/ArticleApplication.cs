using _0_Framework.Application;
using BlogManagement.Application.Contracts.Articles;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;

namespace BlogManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {

        private readonly IFileUploader _fileUploader;
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleCategoryRepository _categoryRepository;

        public ArticleApplication(IFileUploader fileUploader, IArticleRepository articleRepository
            , IArticleCategoryRepository categoryRepository)
        {
            _fileUploader = fileUploader;
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
        }

        public OperationResult Create(CreateArticle command)
        {
            var operation = new OperationResult();
                if(_articleRepository.Exists(x => x.Title == command.Title))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var Slug = command.Slug.Slugify();
            var categorySlug = _categoryRepository.GetSlugBy(command.CategoryId);
            var path = $"{categorySlug}/{Slug}";
            var pictureName = _fileUploader.Upload(command.Picture,path);
            var publishDate = command.PublishDate.ToGeorgianDateTime();

            var article = new Article(command.Title,command.ShortDescription
                ,command.Description,pictureName,command.PictureAlt
                ,command.PictureTitle,Slug,command.Keywords,command.MetaDescription
                ,command.CanonicalAddress,publishDate,command.CategoryId);

            _articleRepository.Create(article);
            _articleRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditArticle command)
        {
           var operation = new OperationResult();
             var article = _articleRepository.GetWithCategory(command.Id);

            if(article == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (_articleRepository.Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var Slug = command.Slug.Slugify();
            var path = $"{article.Category.Slug}/{Slug}";
            var pictureName = _fileUploader.Upload(command.Picture, path);
            var publishDate = command.PublishDate.ToGeorgianDateTime();

            article.Edit(command.Title,command.ShortDescription,command.Description,pictureName,command.PictureAlt
                ,command.PictureTitle,Slug,command.Keywords,command.MetaDescription
                ,command.CanonicalAddress,publishDate,command.CategoryId);

            _articleRepository.SaveChanges();
            return operation.Succedded();
             
        }

        public EditArticle GetDetails(int id)
        {
            return _articleRepository.GetDetails(id);

        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            return _articleRepository.Search(searchModel);
        }
    }
}
