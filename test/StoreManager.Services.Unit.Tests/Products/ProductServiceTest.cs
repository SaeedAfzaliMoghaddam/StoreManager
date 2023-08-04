using StoreManager.Persistence.EF.Products;
using StoreManager.Persistence.EF;
using StoreManager.Services.Products;
using StoreManager.Services.Products.Contracts;
using StoreManager.TestTools.Infrastructure.DataBaseConfig.Unit;
using Xunit;
using StoreManager.TestTools.Factories.Groups;
using StoreManager.TestTools.Infrastructure.DataBaseConfig;
using StoreManager.Entities;
using StoreManager.Services.Products.Contracts.Dto;
using FluentAssertions;
using System.Text.RegularExpressions;
using StoreManager.Services.Groups.Exceptions;
using StoreManager.Persistence.EF.Groups;
using StoreManager.Services.Products.Exceptions;
using StoreManager.TestTools.Factories.Products;

namespace StoreManager.Services.Unit.Tests.Products
{
    public class ProductServiceTest : BusinessUnitTest
    {
        private ProductService _sut;
        public ProductServiceTest()
        {
            _sut = ProductServiceFactory.Create(SetupContext);
        }

        [Fact]
        public void Add_add_a_product_properly()
        {
            var group = GroupFactory.Generate("dummy1");
            DbContext.Save(group);
            var group2 = GroupFactory.Generate("dummy1");
            DbContext.Save(group2);
            var product = new Product
            {
                Title = "dummy",
                GroupId = group.Id,
            };
            var dto = new AddProductsDto
            {
                Title = "dummy",
                GroupId = group2.Id,
                MinimumInventory = 10,
                Inventory = 0,
                Status = ProductStatus.OutOfStocks

            };

            _sut.Define(dto);

            var expected = ReadContext.Set<Product>().Single();
            expected.Title.Should().Be(dto.Title);
            expected.GroupId.Should().Be(dto.GroupId);
            expected.MinimumInventory.Should().Be(dto.MinimumInventory);
            expected.Inventory.Should().Be(dto.Inventory);
            expected.Status.Should().Be(dto.Status);
        }

        [Fact]
        public void Add_throw_exception_when_groupId_not_found()
        {
            var group = GroupFactory.Generate("dummy1");
            DbContext.Save(group);
            var invalidId = -1;
            var dto = new AddProductsDto
            {
                Title = "dummy",
                GroupId = invalidId,
                MinimumInventory = 10,
                Inventory = 0,
                Status = ProductStatus.OutOfStocks
            };

            var action = () => _sut.Define(dto);

            action.Should().ThrowExactly<GroupNotFoundException>();
        }

        [Fact]
        public void Add_throw_exception_when_title_in_group_is_dublicate()
        {
            var group = GroupFactory.Generate("بهداشتی");
            DbContext.Save(group);
            var product = new Product
            {
                Title = "شامپو",
                GroupId = group.Id,
            };
            DbContext.Save(product);
            var dto = new AddProductsDto
            {
                Title = "شامپو",
                GroupId = group.Id,
                MinimumInventory = 10
            };

            var action = () => _sut.Define(dto);

            action.Should().ThrowExactly<DublicateProductTitleException>();
        }
    }
}
