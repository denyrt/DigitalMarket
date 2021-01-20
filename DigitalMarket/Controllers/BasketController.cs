using DigitalMarket.Models;
using DigitalMarket.Models.Common;
using DigitalMarket.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DigitalMarket.Controllers
{
    [Route("api/basket")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IProductBasketService _productBasketService;

        public BasketController(ILogger logger, IProductBasketService productBasketService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger), "");
            _productBasketService = productBasketService ?? throw new ArgumentNullException(nameof(productBasketService), "");
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetBasket()
        {
            var basket = await _productBasketService.GetBasket();
            return Ok(ResponseFactory.Success(basket));
        }

        [HttpPost]
        [Route("set")]
        public async Task<IActionResult> SetToBastek([FromBody] BasketChangeItemModel basketChangeItemModel)
        {            
            basketChangeItemModel.Count ??= 1;
            var basket = await _productBasketService.AddProduct(basketChangeItemModel.Id, basketChangeItemModel.Count.Value);
            return Ok(ResponseFactory.Success(basket));
        }

        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> RemoveFromBasket([FromBody] BasketChangeItemModel basketChangeItemModel)
        {
            var basket = await (basketChangeItemModel.Count == null
                ? _productBasketService.RemoveProduct(basketChangeItemModel.Id)
                : _productBasketService.RemoveProduct(basketChangeItemModel.Id, basketChangeItemModel.Count.Value));
            return Ok(ResponseFactory.Success(basket));
        }

        [HttpPost]
        [Route("clear")]
        public async Task<IActionResult> ClearBasket() 
        {
            var basket = await _productBasketService.Clear();
            return Ok(ResponseFactory.Success(basket));
        }
    }
}