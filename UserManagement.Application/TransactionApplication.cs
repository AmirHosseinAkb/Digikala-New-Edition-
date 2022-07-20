using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Application;
using _01_Framework.Application.Convertors;
using UserManagement.Application.Contracts.Transaction;
using UserManagement.Domain.TransactionAgg;

namespace UserManagement.Application
{
    public class TransactionApplication:ITransactionApplication
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAuthenticationHelper _authenticationHelper;

        public TransactionApplication(ITransactionRepository transactionRepository, IAuthenticationHelper authenticationHelper)
        {
            _transactionRepository = transactionRepository;
            _authenticationHelper = authenticationHelper;
        }

        public List<TransactionViewModel> GetUserTransactionsForShow()
        {
            return _transactionRepository.GetUserTransactions(_authenticationHelper.GetCurrentUserId())
                .Select(t=>new TransactionViewModel()
                {
                    TypeId = t.TypeId,
                    Amount = t.Amount,
                    IsSucceeded = t.IsSucceeded,
                    CreationDate = t.CreationDate.ToShamsi(),
                    Description = t.Description
                }).ToList();
        }
    }
}
