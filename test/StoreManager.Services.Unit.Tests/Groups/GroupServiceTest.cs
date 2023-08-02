using FluentAssertions;
using StoreManager.Entities;
using StoreManager.Persistence.EF;
using StoreManager.Persistence.EF.Groups;
using StoreManager.Services.Groups;
using StoreManager.Services.Groups.Contracts.Dto;
using StoreManager.TestTools.Infrastructure.DataBaseConfig.Unit;
using Xunit;

namespace StoreManager.Services.Unit.Tests.Groups
{
    public class GroupServiceTest : BusinessUnitTest
    {
        [Fact]
        public void Add_add_a_group_properly()
        {
            var repository = new EFGroupRepository(SetupContext);
            var unitOfWork = new EFUnitOfWork(SetupContext);
            var sut = new GroupAppService(repository,unitOfWork);
            var dto = new AddGroupsDto
            {
                Name = "Dummy"
            };

            sut.Define(dto);

            var expected = ReadContext.Set<Group>().Single();
            expected.Name.Should().Be(dto.Name);

        }


    }
}
