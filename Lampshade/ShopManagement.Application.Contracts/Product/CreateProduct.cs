using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contracts.ProductCategory;
using System.ComponentModel.DataAnnotations;


namespace ShopManagement.Application.Contracts.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Code { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Description { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public IFormFile Picture { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get; set; }
        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Keywords { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get; set; }
        public List<ProductCategoryViewModel> Categories { get; set; }

    }
}
