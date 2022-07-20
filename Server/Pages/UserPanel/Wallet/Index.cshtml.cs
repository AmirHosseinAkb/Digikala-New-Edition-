using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagement.Application;
using UserManagement.Application.Contracts.Transaction;
using UserManagement.Application.Contracts.User;

namespace Server.Pages.UserPanel.Wallet
{
    public class IndexModel : PageModel
    {
        private readonly ITransactionApplication _transactionApplication;
        
        public IndexModel(ITransactionApplication transactionApplication)
        {
            _transactionApplication=transactionApplication;
        }

        public List<TransactionViewModel> TransactionVMs { get; set; }
        public void OnGet()
        {
            TransactionVMs = _transactionApplication.GetUserTransactionsForShow();
        }
    }
}
