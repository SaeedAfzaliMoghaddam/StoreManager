using StoreManager.Services.Products.Contracts.Dto;

namespace StoreManager.Services.Products.Contracts
{
    public interface ProductService
    {
        void Define(AddProductsDto dto);
    }
}