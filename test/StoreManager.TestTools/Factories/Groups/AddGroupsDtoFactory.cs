using StoreManager.Services.Groups.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.TestTools.Factories.Groups
{
    public static class AddGroupsDtoFactory
    {
        public static AddGroupsDto Generate(string name)
        {
            var dto = new AddGroupsDto
            {
                Name = name,
            };
            return dto;
        }
    }
}
