using FluentAssertions;
using StoreManager.Entities;
using StoreManager.Services.Groups.Contracts;
using StoreManager.Services.Groups.Contracts.Dto;
using StoreManager.Services.Groups.Exceptions;
using StoreManager.TestTools.Factories.Groups;
using StoreManager.TestTools.Factories.Products;
using StoreManager.TestTools.Infrastructure.DataBaseConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;
using static StoreManager.Specs.Tests.BDDHelper;

namespace StoreManager.Specs.Tests.Groups.Delete
{
    [Scenario("حذف گروه" +
        " وقتی که برای گروه کالا وجود دارد")]
    public class DeleteGroupsWhenHaveProducts : BusinessIntegrationTest
    {
        private GroupService _sut;
        private DeleteGroupsDto _dto;
        private Action _action;
        public DeleteGroupsWhenHaveProducts()
        {
            _sut = GroupServiceFactory.Create(SetupContext);
        }
        [Given("در فهرست گروه ها " +
            "یک گروه به نام بهداشتی وجود دارد")]
        [And ("یک کالا با عنوان شامپو" +
            " در گروه بهداشتی ثبت شده است")]
        public void Given()
        {
            var group = GroupFactory.Generate("بهداشتی");
            DbContext.Save(group);

            var product = ProductFactory.Generate
                ("شیر", group.Id, 10, ProductStatus.OutOfStocks, 0);
            DbContext.Save(product);

            _dto = DeleteGroupsDtoFactory.Generate(group.Id);
        }

        [When("گروه بهداشتی را حذف میکنم ")]
        public void When()
        {
            _action = () => _sut.Delete(_dto);
        }

        [Then("خطایی با عنوان " +
            "'گروه دارای کالا است' باید رخ دهد")]
        public void Then()
        {
            _action.Should().ThrowExactly<GroupHasProductsException>();
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
