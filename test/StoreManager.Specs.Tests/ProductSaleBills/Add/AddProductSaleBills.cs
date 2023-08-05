using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StoreManager.Specs.Tests.BDDHelper;
using Xunit;
using StoreManager.TestTools.Factories.Groups;
using StoreManager.TestTools.Infrastructure.DataBaseConfig;
using StoreManager.TestTools.Factories.Products;
using StoreManager.Entities;
using FluentAssertions;
using StoreManager.Services.ProductSaleBills;
using StoreManager.Services.ProductSaleBills.Contracts.Dto;
using StoreManager.Persistence.EF.ProductSaleBills;
using StoreManager.Persistence.EF;

namespace StoreManager.Specs.Tests.ProductSales.Add
{
    [Scenario("فروش کالا")]
    public class AddProductSaleBills : BusinessIntegrationTest
    {
        private AddProductSaleBillDto _dto;
        private ProductSaleBillAppService _sut;
        public AddProductSaleBills()
        {
            var repository = new EFProductSaleBillRepository(SetupContext);
            var unitOfWork = new EFUnitOfWork(SetupContext);
            _sut = new ProductSaleBillAppService(repository, unitOfWork);
        }
        [Given("گروهی با نام لوازم یدکی " +
            "در فهرست گروه ها وجود دارد")]
        [And("کالایی با عنوان لنت ترمز با " +
            "موجودی ۲۰  و وضعیت موجود " +
            "و حداقل موجودی ۵ در گروه لوازم یدکی وجود دارد ")]
        public void Given()
        {
            var group = GroupFactory.Generate("لوازم یدکی");
            DbContext.Save(group);

            var product = ProductFactory.Generate
                ("لنت ترمز", group.Id, 5, ProductStatus.InStock, 20);
            DbContext.Save(product);
            

            _dto = new AddProductSaleBillDto
            {
                ProductName = "لنت ترمز",
                CustomerName = "مجید رضوی",
                UnitPrice = 1000,
                Count = 5,
                ProductEntranceId = product.ProductEntrances.Select(_=>_.Id).First(),
            };

        }

        [When("کالایی با عنوان لنت ترمز " +
            "و قیمت واحد ۱۰۰۰ تومان برای مشتری به نام مجید رضوی" +
            " به تعداد ۵ عدد را ثبت میکنم")]
        public void When()
        {
            _sut.Define(_dto);
        }

        [Then("کالایی با عنوان لنت ترمز با موجودی ۱۵ " +
            "و وضعیت موجود و حداقل موجودی ۵ " +
            " در گروه لوازم یدکی وجود داشته باشد")]
        [And("یک فاکتور فروش با کالای لنت ترمز" +
            " و تعداد ۵ و قیمت ۱۰۰۰ و شماره فاکتور " +
            "123a و مشتری با نام مجید رضوی و تاریخ 1402" +
            " در فاکتورهای فروش باید وجود داشته باشد")]
        [And("یک سند حسابداری با شماره فاکتور" +
            " ۱۲۳a و شماره سند 1233455657 و تاریخ 1402 و مبلغ ۵۰۰۰ باید" +
            " در فهرست سندهای حسابداری ثبت شده باشد")]
        public void Then()
        {
            var expected = ReadContext.Set<Product>().Single();
            expected.Title.Should().Be("لنت ترمز");
            expected.Inventory.Should().Be(15);
            expected.MinimumInventory.Should().Be(5);
            expected.GroupId.Should().Be(expected.GroupId);

            var expected2 = ReadContext.Set<ProductSaleBill>().Single();
            expected2.ProductName.Should().Be("لنت ترمز");
            expected2.Count.Should().Be(5);
            expected2.UnitPrice.Should().Be(1000);
            expected2.BillNumber.Should().Be("123a");
            expected2.CustomerName.Should().Be("مجید رضوی");
            expected2.DateTime.Should().Be(DateTime.Now.ToString());
            expected2.ProductEntranceId.Should().Be(_dto.ProductEntranceId);

            var expected3 = ReadContext.Set<AccountingDocument>().Single();
            expected3.BillNumber.Should().Be(expected2.BillNumber);
            expected3.DocumentNumber.Should().Be(1233455657);
            expected3.DateTime.Should().Be(DateTime.Now.ToString());
            expected3.BillPrice.Should().Be(5000);
            expected3.ProductSaleBillId.Should().Be(expected2.Id);


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
