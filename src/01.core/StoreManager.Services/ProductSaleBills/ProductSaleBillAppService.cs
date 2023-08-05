using StoreManager.Entities;
using StoreManager.Services.AccountingDocuments.Contracts;
using StoreManager.Services.Contracts;
using StoreManager.Services.ProductSaleBills.Contracts;
using StoreManager.Services.ProductSaleBills.Contracts.Dto;

namespace StoreManager.Services.ProductSaleBills
{
    public class ProductSaleBillAppService : ProductSaleBillService
    {
        private readonly ProductSaleBillRepository _repository;
        private readonly UnitOfWork _unitOfWork;
        private readonly AccountingDocumentRepository _accountingDocumentRepository;

        public ProductSaleBillAppService
            (
            ProductSaleBillRepository repository,
            UnitOfWork unitOfWork
            )
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Define(AddProductSaleBillDto dto)
        {
            var productSaleBill = new ProductSaleBill
            {
                CustomerName = dto.CustomerName,
                ProductName = dto.ProductName,
                UnitPrice = dto.UnitPrice,
                Count = dto.Count,
                DateTime = DateTime.Now.ToString(),
                BillNumber = "123a",
                ProductEntranceId = dto.ProductEntranceId,
                AccountingDocument = new AccountingDocument
                {
                    BillNumber = dto.BillNumber,
                    BillPrice = dto.UnitPrice * dto.Count,
                    DocumentNumber = 1233454,
                    DateTime = DateTime.Now.ToString(),
                    
                }

            };

            _repository.Add(productSaleBill);
            _accountingDocumentRepository.Add(productSaleBill.AccountingDocument);
            _unitOfWork.Complete();
        }
    }
}