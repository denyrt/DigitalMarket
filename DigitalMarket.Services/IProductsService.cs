using DigitalMarket.Models;
using DigitalMarket.Models.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalMarket.Services
{
    public interface IProductsService
    {
        Task<BaseResponse<ProductModel>> GetProductById(Guid id);

        Task<BaseResponse<List<ProductModel>>> GetCollection(PageFilter pageFilter, Guid? productType = null);

        Task<BaseResponse<List<ProductTypeModel>>> GetProductTypes();
    }
}