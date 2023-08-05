using StoreManager.Entities;
using StoreManager.Services.Contracts;
using StoreManager.Services.ProductEntrances.Contracts;
using StoreManager.Services.ProductEntrances.Contracts.Dto;
using StoreManager.Services.Products.Contracts;

namespace StoreManager.Services.ProductEntrances
{
    public class ProductEntranceAppService : ProductEntranceService
    {
        private readonly ProductEntranceRepository _repository;
        private readonly ProductRepository _productRepository;
        private readonly UnitOfWork _unitOfWork;

        public ProductEntranceAppService
            (
            ProductEntranceRepository repository,
            ProductRepository productRepository,
            UnitOfWork unitOfWork
            )
        {
            _repository = repository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public void Define(AddProductEntranceDto dto)
        {
            var productEntrance = new ProductEntrance
            {
                Count = dto.Count,
                DateTime = DateTime.Now.ToString(),
                FactorNumber = dto.FactorNumber,
                ProductCompanyName = dto.ProductCompanyName,
                ProductId = dto.ProductId,
            };

            var product = _productRepository.FindById(dto.ProductId);
            if (dto.Count > product.MinimumInventory)
            {
                product.Status = ProductStatus.InStock;
            }
            if (dto.Count <= product.MinimumInventory &&
                dto.Count > 0)
            {
                product.Status = ProductStatus.ReadyToOrder;
            }
            if (dto.Count == 0)
            {
                product.Status = ProductStatus.OutOfStocks;
            }
            product.Inventory = productEntrance.Count;
            _repository.Add(productEntrance);
            _productRepository.Update(product);
            _unitOfWork.Complete();

        }
    }
}