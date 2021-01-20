using DigitalMarket.DAL.Models;
using DigitalMarket.Models;
using System;

namespace DigitalMarket.Services.Extensions
{
    internal static class ProductsExtensions
    {
        internal static ProductTypeModel ToProductTypeModel(this ProductType productType) 
        {
            if (productType == null)
                throw new ArgumentNullException(nameof(productType), "");

            return new ProductTypeModel
            {
                Id = productType.Id,
                Name = productType.Name
            };
        }

        internal static ProductModel ToProductModel(this Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "");

            return new ProductModel
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                CreateDateUtc = product.CreateDateUtc,
                ProductType = product.ProductType?.ToProductTypeModel()
            };
        }

        internal static ProductModelShort ToProductModelShort(this Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "");

            return new ProductModelShort
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price,
                CreateDateUtc = product.CreateDateUtc
            };
        }
    }
}