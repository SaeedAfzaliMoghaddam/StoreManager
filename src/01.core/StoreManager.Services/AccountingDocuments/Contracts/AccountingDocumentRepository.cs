using StoreManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Services.AccountingDocuments.Contracts
{
    public interface AccountingDocumentRepository
    {
        void Add(AccountingDocument accountingDocument);
    }
}
