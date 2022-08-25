using _01_Framework.Application;
using _01_Framework.Application.ZarinPal;
using _01_Framework.Resources;
using Digikala.Application.Contracts.UserManagement.Transaction;
using Digikala.Domain.UserManagement.TransactionAgg;

namespace Digikala.Applicaion.UserManagement.Application
{
    public class TransactionApplication:ITransactionApplication
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAuthenticationHelper _authenticationHelper;
        private readonly IZarinpalFactory _zarinpalFactory;

        public TransactionApplication(ITransactionRepository transactionRepository, IAuthenticationHelper authenticationHelper, IZarinpalFactory zarinpalFactory)
        {
            _transactionRepository = transactionRepository;
            _authenticationHelper = authenticationHelper;
            _zarinpalFactory = zarinpalFactory;
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
                _zarinpalFactory.CreatePaymentRequest(transactionId, command.Amount,
                    DataDictionaries.PaymentDescription);
            return paymentResponse;;
        }

        public VerificationResponse TransactionVerification(long transactionId,string authority)
        {
            var transaction = _transactionRepository.GetUserTransaction(transactionId,_authenticationHelper.GetCurrentUserId());
            var verificationResponse=_zarinpalFactory.CreateVerificationRequest(transaction.Amount,authority);
            return verificationResponse;
        }

        public void ConfirmTransacttion(long transactionId)
        {
            var transaction = _transactionRepository.GetUserTransaction(transactionId,_authenticationHelper.GetCurrentUserId());
            transaction.Confirm();
            _transactionRepository.SaveChanges();
        }
    }
}
