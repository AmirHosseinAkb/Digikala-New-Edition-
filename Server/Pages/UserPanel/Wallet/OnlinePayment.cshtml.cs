using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagement.Application.Contracts.Transaction;

namespace Server.Pages.UserPanel.Wallet
{
    public class OnlinePaymentModel : PageModel
    {
        private readonly ITransactionApplication _transactionApplication;

        public OnlinePaymentModel(ITransactionApplication transactionApplication)
        {
            _transactionApplication = transactionApplication;
        }
        public void OnGet()
        {
        }
    }
}
