using FluentAssertions;
using StoreManager.Entities;
using StoreManager.Services.Groups.Contracts;
using StoreManager.Services.Groups.Contracts.Dto;
using StoreManager.Services.Groups.Exceptions;
using StoreManager.TestTools.Factories.Groups;
using StoreManager.TestTools.Factories.Products;
using StoreManager.TestTools.Infrastructure.DataBaseConfig;
using StoreManager.TestTools.Infrastructure.DataBaseConfig.Unit;
using Xunit;

namespace StoreManager.Services.Unit.Tests.Groups
{
    public class GroupServiceTest : BusinessUnitTest
    {
        private GroupService _sut;

        public GroupServiceTest()
        {
            _sut = GroupServiceFactory.Create(SetupContext);
        }

        [Fact]
        public void Add_add_a_group_properly()
        {
            var dto = AddGroupsDtoFactory.Generate("dummy");

            _sut.Define(dto);

            var expected = ReadContext.Set<Group>().Single();
            expected.Name.Should().Be(dto.Name);

        }

        [Fact]
        public void Add_throw_new_exception_when_name_is_dublicate()
        {
            var group = GroupFactory.Generate("dummy");
            DbContext.Save(group);
            var dto = AddGroupsDtoFactory.Generate("dummy");

            var expected = () => _sut.Define(dto);

            expected.Should().ThrowExactly<DublicateGroupNameException>();
        }

        [Fact]
        public void Delete_delete_a_group_properly()
        {
            var group = GroupFactory.Generate("DummyGroup");
            DbContext.Save(group);
            var dto = DeleteGroupsDtoFactory.Generate(group.Id);

            _sut.Delete(dto);

            var exepted = ReadContext.Set<Group>();
            exepted.Should().HaveCount(0);
        }

        [Fact]
        public void Delete_throw_new_exception_when_group_does_not_found()
        {
            var dto = DeleteGroupsDtoFactory.Generate(-1);

            var exepted = () => _sut.Delete(dto);

            exepted.Should().ThrowExactly<GroupNotFoundException>();

        }

        [Fact]
        public void Delete_throw_new_exception_when_group_have_related_products()
        {
            var group = GroupFactory.Generate("dummyGroup");
            DbContext.Save(group);
            var product = ProductFactory.Generate("dummyProduct", group.Id);
            DbContext.Save(product);
            var dto = DeleteGroupsDtoFactory.Generate(group.Id);

            var expected = () => _sut.Delete(dto);

            expected.Should().ThrowExactly<GroupHasProductsException>();

        }

    }
}
