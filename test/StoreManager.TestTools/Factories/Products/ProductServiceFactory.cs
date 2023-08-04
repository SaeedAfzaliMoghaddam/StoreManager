using StoreManager.Persistence.EF;
using StoreManager.Persistence.EF.Groups;
using StoreManager.Persistence.EF.Products;
using StoreManager.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.TestTools.Factories.Products
{
    public static class ProductServiceFactory
    {
        public static ProductAppService Create(EFDataContext context)
        {
            var repository = new EFProductRepository(context);
            var unitOfWork = new EFUnitOfWork(context);
            var groupRepository = new EFGroupRepository(context);
            var sut = new ProductAppService
                (repository, unitOfWork, groupRepository);
            return sut;
        }
    }
}
