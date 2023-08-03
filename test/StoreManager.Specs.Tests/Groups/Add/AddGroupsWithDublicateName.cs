using StoreManager.Entities;
using StoreManager.Persistence.EF.Groups;
using StoreManager.Persistence.EF;
using StoreManager.Services.Groups.Contracts.Dto;
using StoreManager.Services.Groups;
using StoreManager.TestTools.Infrastructure.DataBaseConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static StoreManager.Specs.Tests.BDDHelper;
using FluentAssertions;
using StoreManager.Services.Groups.Exceptions;
using StoreManager.Services.Groups.Contracts;
using StoreManager.TestTools.Factories.Groups;

namespace StoreManager.Specs.Tests.Groups.Add
{
    [Scenario("ثبت گروه با نام تکراری")]
    public class AddGroupsWithDublicateName : BusinessIntegrationTest
    {
        private Action action;
        private GroupService _sut;

        public AddGroupsWithDublicateName()
        {
            _sut = GroupServiceFactory.Create(SetupContext);
        }

        [Given("یک گروه با نام بهداشتی" +
            " در فهرست گروه وجود دارد")]
        public void Given()
        {
            var group = GroupFactory.Generate("بهداشتی");
            DbContext.Save(group);
        }

        [When("یک گروه با نام بهداشتی را ثبت میکنم")]
        public void When()
        {
            var dto = AddGroupsDtoFactory.Generate("بهداشتی");
            action = () => _sut.Define(dto);
        }

        [Then("خطایی با عنوان 'اسم گروه تکراری'" +
              " باید رخ دهد")]
        public void Then()
        {
            action.Should().ThrowExactly<DublicateGroupNameException>();
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
