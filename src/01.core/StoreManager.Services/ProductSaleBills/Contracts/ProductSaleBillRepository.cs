﻿using StoreManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Services.ProductSaleBills.Contracts
{
    public interface ProductSaleBillRepository
    {
        void Add(ProductSaleBill productSaleBill);
    }
}
