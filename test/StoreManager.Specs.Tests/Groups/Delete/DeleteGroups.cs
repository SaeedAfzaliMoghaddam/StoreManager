using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using StoreManager.Entities;
using StoreManager.Services.Groups.Contracts;
using StoreManager.Services.Groups.Contracts.Dto;
using StoreManager.TestTools.Factories.Groups;
using StoreManager.TestTools.Infrastructure.DataBaseConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static StoreManager.Specs.Tests.BDDHelper;

namespace StoreManager.Specs.Tests.Groups.Delete
{
    [Scenario("حذف گروه")]
    public class DeleteGroups : BusinessIntegrationTest
    {
        private GroupService _sut;
        private DeleteGroupsDto _dto;
        public DeleteGroups()
        {
            _sut = GroupServiceFactory.Create(SetupContext);
        }
        [Given("در فهرست گروه ها " +
            "یک گروه به نام بهداشتی وجود دارد")]
        public void Given()
        {
            var group = GroupFactory.Generate("بهداشتی");
            DbContext.Save(group);
            _dto = DeleteGroupsDtoFactory.Generate(group.Id);

        }

        [When("گروه بهداشتی را حذف میکنم")]
        public void When()
        {
            _sut.Delete(_dto);
        }

        [Then("در فهرست گروه ها " +
            "نباید گروهی وجود داشته باشد")]
        public void Then()
        {
            var exepted = ReadContext.Set<Group>();
            exepted.Should().HaveCount(0);
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
