using DigitalMarket.Models;
using System;
using System.Threading.Tasks;

namespace DigitalMarket.Services
{
    public interface IProductBasketService
    {
        /// <summary>
        /// Get current basket.
        /// </summary>
        /// <returns> Returns current basket. </returns>
        Task<BasketModel<ProductModelShort>> GetBasket();

        /// <summary>
        /// Add product to current basket.
        /// </summary>
        /// <param name="productId"> Product Id. </param>
        /// <param name="count"> Count of products.. </param>
        /// <returns> Returns changed basket. </returns>
        Task<BasketModel<ProductModelShort>> AddProduct(Guid productId, int count);

        /// <summary>
        /// Remove product from basket.
        /// </summary>
        /// <param name="productId"> Product Id. </param>
        /// <returns> Changed basket. </returns>
        Task<BasketModel<ProductModelShort>> RemoveProduct(Guid productId);

        /// <summary>
        /// Remove count of products from basket.
        /// </summary>
        /// <param name="productId"> Product Id. </param>
        /// <param name="count"> Count of products. </param>
        /// <returns> Changed basket. </returns>
        Task<BasketModel<ProductModelShort>> RemoveProduct(Guid productId, int count);

        /// <summary>
        /// Clear current busket.
        /// </summary>
        /// <returns> Returns clear busket. </returns>
        Task<BasketModel<ProductModelShort>> Clear();
    }
}
