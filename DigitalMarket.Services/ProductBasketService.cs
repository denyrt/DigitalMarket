using DigitalMarket.DAL.Contexts;
using DigitalMarket.Models;
using DigitalMarket.Services.Extensions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMarket.Services
{
    public class ProductBasketService : IProductBasketService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ProductsDbContext _productsDbContext;

        protected HttpContext HttpContext => _httpContextAccessor.HttpContext;

        public ProductBasketService(IHttpContextAccessor httpContextAccessor, ProductsDbContext productsDbContext)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor), "");
            _productsDbContext = productsDbContext ?? throw new ArgumentNullException(nameof(productsDbContext), "");
        }

        public async Task<BasketModel<ProductModelShort>> AddProduct(Guid productId, int count)
        {
            var basket = await GetCurrentBasket();
            basket.TryAddItem(productId, count);
            await SaveBasket(basket);
            return await basket.ToBasketModel(_productsDbContext);
        }

        public async Task<BasketModel<ProductModelShort>> Clear()
        {
            var basket = await GetCurrentBasket();
            basket.Items.Clear();
            await SaveBasket(basket);
            return await basket.ToBasketModel(_productsDbContext);
        }

        public async Task<BasketModel<ProductModelShort>> GetBasket()
        {
            var basket = await GetCurrentBasket();
            return await basket.ToBasketModel(_productsDbContext);            
        }

        public async Task<BasketModel<ProductModelShort>> RemoveProduct(Guid productId)
        {
            var basket = await GetCurrentBasket();
            basket.TryRemoveItem(productId);
            await SaveBasket(basket);
            return await basket.ToBasketModel(_productsDbContext);
        }

        public async Task<BasketModel<ProductModelShort>> RemoveProduct(Guid productId, int count)
        {
            var basket = await GetCurrentBasket();
            basket.TryRemoveItem(productId, count);
            await SaveBasket(basket);
            return await basket.ToBasketModel(_productsDbContext);
        }

        protected async Task<Basket> GetCurrentBasket() 
        {
            if (!HttpContext.Session.IsAvailable)
                await HttpContext.Session.LoadAsync();

            var storedBusket = HttpContext.Session.GetString("Basket");
            if (storedBusket == null)
            {
                var busket = new Basket();                
                HttpContext.Session.SetString("Basket", JsonConvert.SerializeObject(busket));
                return busket;
            }

            var basket = JsonConvert.DeserializeObject<Basket>(storedBusket);
            return basket;
        }

        protected async Task SaveBasket(Basket basket)
        {
            var jsonBasket = JsonConvert.SerializeObject(basket);
            HttpContext.Session.SetString("Basket", jsonBasket);
            await HttpContext.Session.CommitAsync();
        }
    }
}