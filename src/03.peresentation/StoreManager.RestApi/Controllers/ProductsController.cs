using Microsoft.AspNetCore.Mvc;
using StoreManager.Services.Products.Contracts;
using StoreManager.Services.Products.Contracts.Dto;

namespace StoreManager.RestApi.Controllers
{
    [ApiController]
    [Route("Products")]
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public void Add([FromBody] AddProductsDto dto)
        {
            _productService.Define(dto);
        }
    }
}
