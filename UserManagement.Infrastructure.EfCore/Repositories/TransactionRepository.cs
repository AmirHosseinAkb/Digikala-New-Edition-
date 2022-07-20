using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.TransactionAgg;

namespace UserManagement.Infrastructure.EfCore.Repositories
{
    public class TransactionRepository:ITransactionRepository
    {
        private readonly AccountContext _context;

        public TransactionRepository(AccountContext context)
        {
            _context = context;
        }

        public List<Transaction> GetUserTransactions(long userId)
        {
            return _context.Transactions.Where(t => t.UserId == userId).ToList();
        }
    }
}
