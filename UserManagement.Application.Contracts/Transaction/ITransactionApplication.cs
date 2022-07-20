using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.Contracts.Transaction
{
    public interface ITransactionApplication
    {
        List<TransactionViewModel> GetUserTransactionsForShow();
    }
}
