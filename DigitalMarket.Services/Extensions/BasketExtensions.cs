using DigitalMarket.DAL.Contexts;
using DigitalMarket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalMarket.Services.Extensions
{
    internal static class BasketExtensions
    {
        internal async static Task<BasketModel<ProductModelShort>> ToBasketModel(this Basket basket, ProductsDbContext context)
        {
            var keys = basket.Items.Select(entry => entry.Item);
            var products = await context.Products
                .Where(product => keys.Contains(product.Id))
                .Select(product => new BasketItemModel<ProductModelShort>
                {
                    Item = product.ToProductModelShort(),
                    Count = basket[product.Id]
                })
                .ToListAsync();

            var basketModel = new BasketModel<ProductModelShort>
            {
                Items = products,
                Price = products.Select(product => product.Item.Price * product.Count).Sum()
            };

            return basketModel;
        }
    }
}