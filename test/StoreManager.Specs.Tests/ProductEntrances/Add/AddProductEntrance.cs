using FluentAssertions;
using StoreManager.Entities;
using StoreManager.Persistence.EF.ProductEntrances;
using StoreManager.Persistence.EF.Products;
using StoreManager.Persistence.EF;
using StoreManager.Services.ProductEntrances;
using StoreManager.Services.ProductEntrances.Contracts;
using StoreManager.Services.ProductEntrances.Contracts.Dto;
using StoreManager.TestTools.Factories.Groups;
using StoreManager.TestTools.Factories.Products;
using StoreManager.TestTools.Infrastructure.DataBaseConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static StoreManager.Specs.Tests.BDDHelper;

namespace StoreManager.Specs.Tests.ProductEntrances.Add
{
    [Scenario("ورود کالا")]
    public class AddProductEntrance : BusinessIntegrationTest
    {
        private ProductEntranceService _sut;
        private AddProductEntranceDto _dto;
        public AddProductEntrance()
        {
            var repistory = new EFProductEntranceRepository(SetupContext);
            var productRepository = new EFProductRepository(SetupContext);
            var unitOfWork = new EFUnitOfWork(SetupContext);
            _sut = new ProductEntranceAppService
                (repistory, productRepository, unitOfWork);
        }
        [Given("یک گروه با نام بهداشتی" +
            " در فهرست گروه ها وجود دارد")]
        [And("یک کالا با عنوان شامپو با موجودی ۰ " +
            "و وضعیت ناموجود  و حداقل موجودی ۱۰ " +
            "در گروه بهداشتی وجود دارد")]
        public void Given()
        {
            var group = GroupFactory.Generate("بهداشتی");
            DbContext.Save(group);

            var product = ProductFactory.Generate
            ("شامپو", group.Id, 10, ProductStatus.OutOfStocks, 0);
            DbContext.Save(product);

            _dto = new AddProductEntranceDto
            {
                Count = 20,
                ProductId = product.Id,
                DateTime = DateTime.Now.ToString(),
                FactorNumber = "123a",
                ProductCompanyName = "فپکو"
            };

        }

        [When("تعداد ۲۰ تا به موجودی کالایی " +
            "با عنوان شامپو با شماره فاکتور 123a" +
            " و نام شرکت فپکو  در گروه بهداشتی" +
            " را وارد میکنم ")]
        public void When()
        {
            _sut.Define(_dto);
        }

        [Then("یک کالا با عنوان شامپو و موجودی ۲۰ " +
            "و وضعیت موجود در گروه بهداشتی و حداقل موجودی ۱۰ " +
            "باید در فهرست کالاها وجود داشته باشد")]
        [And("یک ورودی کالا برای کالای شامپو در" +
            " تاریخ الان  و تعداد ۲۰ و شماره فاکتور ۱۲۳a" +
            " و نام شرکت فپکو باید در فهرست ورودی های کالا وجود داشته باشد")]
        public void Then()
        {
            var expected = ReadContext.Set<Product>().Single();
            expected.Status.Should().Be(ProductStatus.InStock);
            expected.Inventory.Should().Be(20);
            expected.MinimumInventory.Should().Be(10);
            expected.GroupId.Should().Be(expected.GroupId);
            expected.Title.Should().Be("شامپو");

            var expected2 = ReadContext.Set<ProductEntrance>().Single();
            expected2.ProductId.Should().Be(expected.Id);
            expected2.FactorNumber.Should().Be(_dto.FactorNumber);
            expected2.ProductCompanyName.Should().Be(_dto.ProductCompanyName);
            expected2.Count.Should().Be(_dto.Count);
            expected2.DateTime.Should().Be(_dto.DateTime);
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
