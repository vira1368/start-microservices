using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(IProductRepository productRepository, ILogger<CatalogController> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        //swagger code
        [ApiExplorerSettings(IgnoreApi = true)]
        [SwaggerOperation(Summary = "لیست کالا ها", Description = "لیست کالا ها را برمیگرداند، نیاز به اعتباری سنجی نیست...", Tags = new string[] { "کالا ها" })]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        [ProducesResponseType(typeof(string), 401)]

        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        [HttpGet("GetProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return Ok(products);
        }
        //swagger code
        [ApiExplorerSettings(IgnoreApi = false)]
        [SwaggerOperation(Summary = "لیست کالا براساس کد کد کالا", Description = "یک کالا را براساس کد کالا برمیگرداند، نیاز به اعتباری سنجی نیست...", Tags = new string[] { "کالا ها" })]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        [ProducesResponseType(typeof(string), 401)]



        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product is null)
            {
                _logger.LogError($"Product with id: {id}, not found.");
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet]
        [Route("[action]/{category}", Name = "GetProductsByCategory")]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(string category)
        {
            var products = await _productRepository.GetProductsByCategoryName(category);
            return Ok(products);
        }

        //swagger code
        [ApiExplorerSettings(IgnoreApi = false)]
        [SwaggerOperation(Summary = "لیست کالا ها", Description = "ایجاد کالا ...", Tags = new string[] { "کالا ها" })]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        [ProducesResponseType(typeof(string), 401)]

        [EnableCors("MyPolicy")]
        [HttpPost("CreateProduct")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            await _productRepository.CreateProduct(product);
            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }
        //swagger code
        [ApiExplorerSettings(IgnoreApi = false)]
        [SwaggerOperation(Summary = "ویرایش کالا ", Description = "ویرایش کالا را انجام میدهد...", Tags = new string[] { "کالا ها" })]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        [ProducesResponseType(typeof(string), 401)]
        [HttpPut("UpdateProduct")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromForm] Product product)
        {
            var isUpdate = await _productRepository.UpdateProduct(product);
            return Ok(isUpdate);
        }
        //swagger code
        [ApiExplorerSettings(IgnoreApi = false)]
        [SwaggerOperation(Summary = "حذف کالا ", Description = "حذف کالا را انجام میدهد...", Tags = new string[] { "کالا ها" })]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        [ProducesResponseType(typeof(string), 401)]
        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            var isDelete = await _productRepository.DeleteProduct(id);
            return Ok(isDelete);
        }
    }
}
