using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; 
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {

        [TempData]

        public string Message { get; set; }



        public ProductSearchModel SearchModel;
        public List<ProductViewModel> Products;
        public SelectList ProductCategories;


        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ProductSearchModel searchModel)
        {
            ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(),"Id","Name");
            Products = _productApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProduct
            {
                Categories = _productCategoryApplication.GetProductCategories()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateProduct command)
        {
            var result = _productApplication.Create(command);

            return new JsonResult(result);
        }


        public IActionResult OnGetEdit(int id)
        {
            var Product = _productApplication.GetDetails(id);
            Product.Categories = _productCategoryApplication.GetProductCategories();
            return Partial("Edit", Product);
        }


        public JsonResult OnPostEdit(EditProduct command)
        {
            var result = _productApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetNotInStock(int id)
        {
            var result = _productApplication.NotInStock(id);

            TempData["Message"] = result.Message;
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");
            
        }

        public IActionResult OnGetIsInStock(int id)
        {
            var result = _productApplication.IsInStock(id);

            TempData["Message"] = result.Message;
            if (result.IsSuccedded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");

        }
    }
}
