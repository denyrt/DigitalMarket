using DigitalMarket.DAL.Contexts;
using DigitalMarket.Models;
using DigitalMarket.Models.Common;
using DigitalMarket.Services.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalMarket.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ProductsDbContext _productsDbContext;

        public ProductsService(ProductsDbContext productsDbContext)
        {
            _productsDbContext = productsDbContext ?? throw new ArgumentNullException(nameof(productsDbContext), "");
        }

        public async Task<BaseResponse<List<ProductModel>>> GetCollection(PageFilter pageFilter, Guid? productTypeId = null)
        {           
            if (pageFilter == null)
                throw new ArgumentNullException(nameof(pageFilter), "");

            var products = _productsDbContext.Products.AsQueryable();
            if (productTypeId != null)
            {
                products = products.Where(product => product.ProductTypeId == productTypeId);
            }

            products = products
                .OrderBy(product => product.CreateDateUtc)
                .Skip(pageFilter.SkipValue())
                .Take(pageFilter.TakeValue());

            var collection = await products.Select(product => product.ToProductModel()).ToListAsync();
            return ResponseFactory.Success(collection);
        }

        public async Task<BaseResponse<ProductModel>> GetProductById(Guid id)
        {
            var product = await _productsDbContext.Products.FindAsync(id);
            if (product == null)
            {
                return ResponseFactory.Error<ProductModel>("Entity not found.");
            }

            product.ProductType = await _productsDbContext.ProductTypes.FindAsync(product.ProductTypeId);
            return ResponseFactory.Success(product.ToProductModel());
        }

        public async Task<BaseResponse<List<ProductTypeModel>>> GetProductTypes()
        {
            var productTypes = await _productsDbContext.ProductTypes
                .Select(type => type.ToProductTypeModel())
                .ToListAsync();

            return ResponseFactory.Success(productTypes);
        }
    }
}