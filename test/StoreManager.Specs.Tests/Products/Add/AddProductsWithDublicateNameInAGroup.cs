using StoreManager.Persistence.EF.Groups;
using StoreManager.Persistence.EF.Products;
using StoreManager.Persistence.EF;
using StoreManager.Services.Products;
using StoreManager.Services.Products.Contracts;
using StoreManager.Services.Products.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StoreManager.Specs.Tests.BDDHelper;
using Xunit;
using StoreManager.TestTools.Factories.Groups;
using StoreManager.TestTools.Infrastructure.DataBaseConfig;
using StoreManager.Entities;
using FluentAssertions;
using StoreManager.Services.Products.Exceptions;
using StoreManager.TestTools.Factories.Products;

namespace StoreManager.Specs.Tests.Products.Add
{
    public class AddProductsWithDublicateNameInAGroup : BusinessIntegrationTest
    {
        private ProductService _sut;
        private AddProductsDto _dto;
        private Action action;
        public AddProductsWithDublicateNameInAGroup()
        {
            _sut = ProductServiceFactory.Create(SetupContext);
        }

        [Given("یک گروه با عنوان بهداشتی " +
            "در فهرست گروه ها وجود دارد")]
        [And("یک کالا با نام شامپو در گروه بهداشتی وجود دارد")]
        public void Given()
        {
            var group = GroupFactory.Generate("بهداشتی");
            DbContext.Save(group);
            var product = new Product
            {
                Title = "شامپو",
                GroupId = group.Id,
                Inventory = 0,
                MinimumInventory = 10,
                Status = ProductStatus.OutOfStocks
            };
            DbContext.Save(product);
            _dto = new AddProductsDto
            {
                Title = "شامپو",
                GroupId = group.Id,
                MinimumInventory = 10,
                Inventory = 0,
                Status = ProductStatus.OutOfStocks
                
            };
        }

        [When("یک کالا با عنوان شامپو " +
            "و گروه بهداشتی و حداقل موجودی ۱۰ را ثبت میکنم")]
        public void When()
        {
            action = () => _sut.Define(_dto);
        }

        [Then("خطایی با عنوان " +
            "'عنوان کالا تکراری است' باید رخ دهد")]
        public void Then()
        {
            action.Should().ThrowExactly<DublicateProductTitleException>();
        }

        [Fact]
        public void Run()
        {
            Runner.RunScenario
                (
                _ => Given(),
                _ => When(),
                _ => Then()
                );
        }
    }
}
