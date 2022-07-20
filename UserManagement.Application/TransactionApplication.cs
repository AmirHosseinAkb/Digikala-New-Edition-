using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Application;
using _01_Framework.Application.Convertors;
using _01_Framework.Application.ZarinPal;
using _01_Framework.Resources;
using UserManagement.Application.Contracts.Transaction;
using UserManagement.Domain.TransactionAgg;

namespace UserManagement.Application
{
    public class TransactionApplication:ITransactionApplication
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAuthenticationHelper _authenticationHelper;
        private readonly IZarinpalFactory _zarinpoFactory;

        public TransactionApplication(ITransactionRepository transactionRepository, IAuthenticationHelper authenticationHelper, IZarinpalFactory zarinpoFactory)
        {
            _transactionRepository = transactionRepository;
            _authenticationHelper = authenticationHelper;
            _zarinpoFactory = zarinpoFactory;
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

        public long AddTransaction(TransactionCommand command)
        {
            var transaction = new Transaction(1, _authenticationHelper.GetCurrentUserId(), command.Amount,
                DataDictionaries.PaymentDescription, false);
            return _transactionRepository.AddTransaction(transaction);
        }

        public PaymentResponse TransactionPayment(TransactionCommand command)
        {
            var transactionId = AddTransaction(command);
            var paymentResponse =
                _zarinpoFactory.CreatePaymentRequest(transactionId, command.Amount,
                    DataDictionaries.PaymentDescription);
            return paymentResponse;;
        }
    }
}
