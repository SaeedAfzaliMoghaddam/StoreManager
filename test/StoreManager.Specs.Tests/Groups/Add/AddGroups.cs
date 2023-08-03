using FluentAssertions;
using StoreManager.Entities;
using StoreManager.Persistence.EF;
using StoreManager.Persistence.EF.Groups;
using StoreManager.Services.Groups;
using StoreManager.Services.Groups.Contracts;
using StoreManager.Services.Groups.Contracts.Dto;
using StoreManager.TestTools.Factories.Groups;
using Xunit;
using static StoreManager.Specs.Tests.BDDHelper;

namespace StoreManager.Specs.Tests.Groups.Add
{
    [Scenario(" ثبت گروه ")]
    public class AddGroups : BusinessIntegrationTest
    {
        private GroupService _sut;

        public AddGroups()
        {
            _sut = GroupServiceFactory.Create(SetupContext);
        }

        [Given("فهرست گروه خالی است ")]
        public void Given()
        {

        }

        [When("یک گروه با نام بهداشتی را ثبت میکنم ")]
        public void When()
        {
            var dto = AddGroupsDtoFactory.Generate("بهداشتی");
            _sut.Define(dto);
        }

        [Then("در فهرست گروه ها " +
            "یک گروه با نام بهداشتی باید وجود داشته باشد")]
        public void Then()
        {
            var expected = ReadContext.Set<Group>().Single();
            expected.Name.Should().Be("بهداشتی");
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

