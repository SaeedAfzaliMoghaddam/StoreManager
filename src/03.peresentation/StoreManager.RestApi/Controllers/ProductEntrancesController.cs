using Microsoft.AspNetCore.Mvc;
using StoreManager.Services.ProductEntrances.Contracts;
using StoreManager.Services.ProductEntrances.Contracts.Dto;

namespace StoreManager.RestApi.Controllers
{
    [Route("ProductEntrances")]
    [ApiController]
    public class ProductEntrancesController : Controller
    {
        private readonly ProductEntranceService _productEntranceService;

        public ProductEntrancesController
            (
            ProductEntranceService productEntranceService
            )
        {
            _productEntranceService = productEntranceService;
        }

        [HttpPost]
        public void Add([FromBody] AddProductEntranceDto dto)
        {
            _productEntranceService.Define(dto);
        }
    }
}
