using FluentAssertions;
using StoreManager.Entities;
using StoreManager.Persistence.EF;
using StoreManager.Persistence.EF.Groups;
using StoreManager.Services.Groups;
using StoreManager.Services.Groups.Contracts.Dto;
using Xunit;
using static StoreManager.Specs.Tests.BDDHelper;

namespace StoreManager.Specs.Tests.Groups.Add
{
    [Scenario(" ثبت گروه ")]
    public class AddGroups : BusinessIntegrationTest
    {
        public class AddComplexes : BusinessIntegrationTest
        {
            

            [Given("فهرست گروه خالی است ")]
            public void Given()
            {
                
            }

            [When("یک گروه با نام بهداشتی را ثبت میکنم ")]
            public void When()
            {
                var repository = new EFGroupRepository(SetupContext);
                var unitOfWork = new EFUnitOfWork(SetupContext);
                var sut = new GroupAppService(repository,unitOfWork);
                var dto = new AddGroupsDto
                {
                    Name = "بهداشتی"
                };
                sut.Define(dto);
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
}
