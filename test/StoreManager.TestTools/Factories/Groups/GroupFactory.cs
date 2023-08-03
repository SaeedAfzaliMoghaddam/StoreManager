using StoreManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.TestTools.Factories.Groups
{
    public static class GroupFactory
    {
        public static Group Generate(string name)
        {
            var group = new Group
            {
                Name = name,
            };
            return group;
        } 
    }
}
