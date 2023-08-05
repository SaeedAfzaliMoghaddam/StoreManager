using StoreManager.Services.ProductEntrances.Contracts.Dto;

namespace StoreManager.Services.ProductEntrances.Contracts
{
    public interface ProductEntranceService
    {
        void Define(AddProductEntranceDto dto);
    }
}