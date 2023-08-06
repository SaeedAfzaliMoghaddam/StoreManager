using StoreManager.Entities;
using StoreManager.Services.AccountingDocuments.Contracts;
using StoreManager.Services.Contracts;
using StoreManager.Services.Products.Contracts;
using StoreManager.Services.ProductSaleBills.Contracts;
using StoreManager.Services.ProductSaleBills.Contracts.Dto;

namespace StoreManager.Services.ProductSaleBills
{
    public class ProductSaleBillAppService : ProductSaleBillService
    {
        private readonly ProductSaleBillRepository _repository;
        private readonly UnitOfWork _unitOfWork;
        private readonly AccountingDocumentRepository _accountingDocumentRepository;
        private readonly ProductRepository _productRepository;

        public ProductSaleBillAppService
            (
            ProductSaleBillRepository repository,
            UnitOfWork unitOfWork,
            AccountingDocumentRepository accountingDocument,
            ProductRepository productRepository

            )
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _accountingDocumentRepository = accountingDocument;
            _productRepository = productRepository;
        }

        public void Define(AddProductSaleBillDto dto)
        {
            var productSaleBill = new ProductSaleBill
            {
                CustomerName = dto.CustomerName,
                ProductName = dto.ProductName,
                ProductId = dto.ProductId,
                Count = dto.Count,
                UnitPrice = dto.UnitPrice,
                BillNumber = dto.BillNumber,
                DateTime = DateTime.Now.ToString(),
            };
            var product = _productRepository.FindById(productSaleBill.ProductId);
            product.Inventory = product.Inventory - productSaleBill.Count;

            var accountingDoc = new AccountingDocument
            {
                BillNumber = dto.BillNumber,
                DocumentNumber = 1233455657,
                ProductSaleBill = productSaleBill,
                DateTime = DateTime.Now.ToString(),
                BillPrice = dto.Count * dto.UnitPrice,
            };

            _repository.Add(productSaleBill);
            _accountingDocumentRepository.Add(accountingDoc);
            _productRepository.Update(product);
            _unitOfWork.Complete();
        }
    }
}