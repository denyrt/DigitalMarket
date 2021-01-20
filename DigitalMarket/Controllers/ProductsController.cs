using DigitalMarket.Models.Common;
using DigitalMarket.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DigitalMarket.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IProductsService _productsService;

        public ProductsController(ILogger logger, IProductsService productsService)
        {            
            _logger = logger ?? throw new ArgumentNullException(nameof(logger), "");
            _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService), "");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id) 
        {
            try
            {
                var response = await _productsService.GetProductById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("{0}[utc]: {1}\nStackTrace: {2}", DateTime.UtcNow, ex.Message, ex.StackTrace));
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll([FromQuery] PageFilter pageFilter, [FromQuery] Guid? productTypeId = null) 
        {
            try
            {
                var response = await _productsService.GetCollection(pageFilter, productTypeId);
                return Ok(response);
            }
            catch(Exception ex)
            {
                _logger.LogError(string.Format("{0}[utc]: {1}\nStackTrace: {2}", DateTime.UtcNow, ex.Message, ex.StackTrace));
                return StatusCode(500);
            }
        }        

        [HttpGet]
        [Route("product-types")]
        public async Task<IActionResult> GetProductTypes()
        {
            try
            {
                var response = await _productsService.GetProductTypes();
                return Ok(response);
            }
            catch(Exception ex) 
            {
                _logger.LogError(string.Format("{0}[utc]: {1}\nStackTrace: {2}", DateTime.UtcNow, ex.Message, ex.StackTrace));
                return StatusCode(500);
            }
        }
    }
}