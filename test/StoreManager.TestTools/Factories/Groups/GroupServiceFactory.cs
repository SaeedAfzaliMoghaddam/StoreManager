using StoreManager.Persistence.EF.Groups;
using StoreManager.Persistence.EF;
using StoreManager.Services.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreManager.Persistence.EF.Products;

namespace StoreManager.TestTools.Factories.Groups
{
    public static class GroupServiceFactory
    {
        public static GroupAppService Create(EFDataContext context)
        {
            var repository = new EFGroupRepository(context);
            var unitOfWork = new EFUnitOfWork(context);
            var productRepository = new EFProductRepository(context);
            var sut = new GroupAppService(repository, unitOfWork,productRepository);
            return sut;
        }
    }
}
