﻿using Digikala.Domain.UserManagement.TransactionAgg;

namespace Digikala.Infrastructure.EfCore.UserManagement.Repositories
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

        public long AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            return transaction.TransactionId;
        }

        public Transaction GetUserTransaction(long transactionId,long userId)
        {
            return _context.Transactions.SingleOrDefault(t=>t.TransactionId==transactionId && t.UserId==userId);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
