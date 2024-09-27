﻿using _01_LampshadeQuery.Contracts.Product;
using _01_LampshadeQuery.Contracts.Productcategory;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.EFCore;

namespace _01_LampshadeQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _shopContext;
        public ProductCategoryQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return _shopContext.ProductCategories.Select(c => new ProductCategoryQueryModel
            {
                Id = c.Id,
                Name = c.Name,
                Picture = c.Picture,
                PictureAlt = c.PictureAlt,
                PictureTitle = c.PictureTitle,
                sluge = c.Slug

            }).ToList();
        }

        public List<ProductCategoryQueryModel> GetProductCategoriesWithProducts()
        {
            return _shopContext.ProductCategories
                .Include(c => c.Products)
                .ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryQueryModel
                {

                    Id = x.Id,
                    Name = x.Name,
                    Products = MapProducts(x.Products),


                }).ToList();
        }

        private static List<ProductQueryModel> MapProducts(List<Product> products)
        {
            var result = new List<ProductQueryModel>();

            foreach (var product in products)
            {
                var item = new ProductQueryModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Picture = product.Picture,
                    PictureAlt = product.PictureAlt,
                    PictureTitle = product.PictureTitle,
                    Slug = product.Slug,

                };
                result.Add(item);
            }
            return result;
        }
    }
}
