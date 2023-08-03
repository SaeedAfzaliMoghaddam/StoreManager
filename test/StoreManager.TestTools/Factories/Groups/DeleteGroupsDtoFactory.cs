using StoreManager.Services.Groups.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.TestTools.Factories.Groups
{
    public static class DeleteGroupsDtoFactory
    {
        public static DeleteGroupsDto Generate(int id)
        {
            var dto = new DeleteGroupsDto
            {
                Id = id,
            };
            return dto;
        }
    }
}
