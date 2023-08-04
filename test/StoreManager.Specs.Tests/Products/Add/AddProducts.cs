using FluentAssertions;
using StoreManager.Entities;
using StoreManager.Persistence.EF;
using StoreManager.Persistence.EF.Groups;
using StoreManager.Persistence.EF.Products;
using StoreManager.Services.Products;
using StoreManager.Services.Products.Contracts;
using StoreManager.Services.Products.Contracts.Dto;
using StoreManager.TestTools.Factories.Groups;
using StoreManager.TestTools.Factories.Products;
using StoreManager.TestTools.Infrastructure.DataBaseConfig;
using Xunit;
using static StoreManager.Specs.Tests.BDDHelper;

namespace StoreManager.Specs.Tests.Products.Add
{
    [Scenario("تعریف کالا")]
    public class AddProducts : BusinessIntegrationTest
    {
        private AddProductsDto _dto;
        private ProductService _sut;
        public AddProducts()
        {
            _sut = ProductServiceFactory.Create(SetupContext);
            _dto = new AddProductsDto();
        }

        [Given("دو گروه با عنوان های  اسباب بازی و لبنیات" +
            " در فهرست گروه ها وجود دارد")]
        [And("یک کالا با نام شیر " +
            "در فهرست کالا های لبنیات وجود دارد")]
        public void Given()
        {
            var group1 = GroupFactory.Generate("اسباب بازی");
            DbContext.Save(group1);
            var group2 = GroupFactory.Generate("لبنیات");
            DbContext.Save(group2);
            var product = ProductFactory.Generate
                ("شیر", group2.Id, 10, ProductStatus.OutOfStocks, 0);
            _dto = new AddProductsDto
            {
                Title = "شیر",
                GroupId = group1.Id,
                MinimumInventory = 10,
                Status = ProductStatus.OutOfStocks,
                Inventory = 0
            };
        }

        [When("یک کالا با عنوان شیر در گروه اسباب بازی" +
            "با حداقل موجودی ۱۰ را ثبت میکنم")]
        public void When()
        {
            _sut.Define(_dto);
        }

        [Then("یک کالا با عنوان شیر در گروه اسباب بازی" +
            " و حداقل موجودی ۱۰ و وضعیت ناموجود و موجودی ۰ " +
            " باید در فهرست کالا موجود باشد")]
        public void Then()
        {
            var expected = ReadContext.Set<Product>().Single();
            expected.Title.Should().Be(_dto.Title);
            expected.GroupId.Should().Be(_dto.GroupId);
            expected.MinimumInventory.Should().Be(_dto.MinimumInventory);
            expected.Inventory.Should().Be(_dto.Inventory);
            expected.Status.Should().Be(_dto.Status);
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
