﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Services.Products.Contracts
{
    public interface ProductRepository
    {
        bool IsAsseignedToGroup(int id);
    }
}
