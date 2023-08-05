using FluentAssertions;
using StoreManager.Entities;
using StoreManager.Persistence.EF;
using StoreManager.Persistence.EF.ProductEntrances;
using StoreManager.Persistence.EF.Products;
using StoreManager.Services.ProductEntrances;
using StoreManager.Services.ProductEntrances.Contracts;
using StoreManager.Services.ProductEntrances.Contracts.Dto;
using StoreManager.TestTools.Factories.Groups;
using StoreManager.TestTools.Factories.Products;
using StoreManager.TestTools.Infrastructure.DataBaseConfig;
using StoreManager.TestTools.Infrastructure.DataBaseConfig.Unit;
using Xunit;

namespace StoreManager.Services.Unit.Tests.ProductEntrances
{
    public class ProductEntrancesServiceTest : BusinessUnitTest
    {
        private ProductEntranceService _sut;
        public ProductEntrancesServiceTest()
        {
            var repistory = new EFProductEntranceRepository(SetupContext);
            var productRepository = new EFProductRepository(SetupContext);
            var unitOfWork = new EFUnitOfWork(SetupContext);
            _sut = new ProductEntranceAppService
                (repistory, productRepository, unitOfWork);
        }

        [Theory]
        [InlineData(20, ProductStatus.InStock)]
        [InlineData(10, ProductStatus.ReadyToOrder)]
        [InlineData(5, ProductStatus.ReadyToOrder)]
        public void Add_add_a_productEntrance_properly(int count , ProductStatus productStatus)
        {
            var group = GroupFactory.Generate("بهداشتی");
            DbContext.Save(group);
            var product = ProductFactory.Generate
            ("شامپو", group.Id, 10, ProductStatus.OutOfStocks, 0);
            DbContext.Save(product);
            var dto = new AddProductEntranceDto
            {
                Count = count,
                ProductId = product.Id,
                FactorNumber = "123a",
                ProductCompanyName = "فپکو",
                DateTime = DateTime.Now.ToString(),

            };

            _sut.Define(dto);

            var expected = ReadContext.Set<Product>().Single();
            expected.Inventory.Should().Be(count);
            expected.Status.Should().Be(productStatus);
            expected.MinimumInventory.Should().Be(expected.MinimumInventory);
            expected.GroupId.Should().Be(expected.GroupId);
            expected.Title.Should().Be("شامپو");

            var expected2 = ReadContext.Set<ProductEntrance>().Single();
            expected2.ProductId.Should().Be(expected.Id);
            expected2.FactorNumber.Should().Be(dto.FactorNumber);
            expected2.ProductCompanyName.Should().Be(dto.ProductCompanyName);
            expected2.Count.Should().Be(dto.Count);
            expected2.DateTime.Should().Be(dto.DateTime);
        }



    }
}
