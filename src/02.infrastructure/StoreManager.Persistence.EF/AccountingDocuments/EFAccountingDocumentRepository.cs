using Microsoft.EntityFrameworkCore;
using StoreManager.Entities;
using StoreManager.Services.AccountingDocuments.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Persistence.EF.AccountingDocuments
{
    public class EFAccountingDocumentRepository :
        AccountingDocumentRepository
    {
        private readonly DbSet<AccountingDocument> _accountingDocuments;
        public EFAccountingDocumentRepository(EFDataContext context)
        {
            _accountingDocuments = context.Set<AccountingDocument>();
        }
        public void Add(AccountingDocument accountingDocument)
        {
            _accountingDocuments.Add(accountingDocument);
        }
    }
}
