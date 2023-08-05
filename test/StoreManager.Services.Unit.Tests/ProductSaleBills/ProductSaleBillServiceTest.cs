﻿using FluentAssertions;
using StoreManager.Entities;
using StoreManager.Persistence.EF;
using StoreManager.Persistence.EF.ProductSaleBills;
using StoreManager.Services.ProductSaleBills;
using StoreManager.Services.ProductSaleBills.Contracts;
using StoreManager.Services.ProductSaleBills.Contracts.Dto;
using StoreManager.TestTools.Factories.Groups;
using StoreManager.TestTools.Factories.Products;
using StoreManager.TestTools.Infrastructure.DataBaseConfig;
using StoreManager.TestTools.Infrastructure.DataBaseConfig.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StoreManager.Services.Unit.Tests.ProductSaleBills
{
    public class ProductSaleBillServiceTest : BusinessUnitTest
    {
        private ProductSaleBillService _sut;
        public ProductSaleBillServiceTest()
        {
            var repository = new EFProductSaleBillRepository(SetupContext);
            var unitOfWork = new EFUnitOfWork(SetupContext);
            _sut = new ProductSaleBillAppService(repository, unitOfWork);
        }
        [Fact]
        public void Add_add_a_productSaleBill_properly()
        {
            var group = GroupFactory.Generate("لوازم یدکی");
            DbContext.Save(group);
            var product = ProductFactory.Generate
                ("لنت ترمز", group.Id, 5, ProductStatus.InStock, 20);
            DbContext.Save(product);
            var productEntrance = new ProductEntrance
            {
                ProductId = product.Id,
                DateTime = DateTime.Now.ToString(),
                Count = 0,
                FactorNumber = "123A",
                ProductCompanyName = "dummy",
            };
            DbContext.Save(productEntrance);
            var dto = new AddProductSaleBillDto
            {
                ProductName = "لنت ترمز",
                CustomerName = "مجید رضوی",
                UnitPrice = 1000,
                Count = 5,
                ProductEntranceId = productEntrance.Id,
                BillNumber = "123a"
                

            };

            _sut.Define(dto);

            var expected = ReadContext.Set<Product>().Single();
            expected.Title.Should().Be(product.Title);
            expected.Inventory.Should().Be(20);
            expected.MinimumInventory.Should().Be(product.MinimumInventory);
            expected.GroupId.Should().Be(expected.GroupId);

            var expected2 = ReadContext.Set<ProductSaleBill>().Single();
            expected2.ProductName.Should().Be(dto.ProductName);
            expected2.Count.Should().Be(dto.Count);
            expected2.UnitPrice.Should().Be(dto.UnitPrice);
            expected2.CustomerName.Should().Be(dto.CustomerName);
            expected2.BillNumber.Should().Be(dto.BillNumber);
            expected2.DateTime.Should().Be(DateTime.Now.ToString());
            expected2.ProductEntranceId.Should().Be(dto.ProductEntranceId);

            var expected3 = ReadContext.Set<AccountingDocument>().Single();
            expected3.BillNumber.Should().Be(expected2.BillNumber);
            expected3.DocumentNumber.Should().Be(1233455657);
            expected3.DateTime.Should().Be(DateTime.Now.ToString());
            expected3.BillPrice.Should().Be(dto.UnitPrice * dto.Count);
        }
    }
}