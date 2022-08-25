using Digikala.Application.Contracts.UserManagement.Transaction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Server.Pages.UserPanel.Wallet
{
    public class IndexModel : PageModel
    {
        private readonly ITransactionApplication _transactionApplication;
        public List<TransactionViewModel> TransactionVMs { get; set; }
        [BindProperty]
        public TransactionCommand TransactionCommand { get; set; }
        public IndexModel(ITransactionApplication transactionApplication)
        {
            _transactionApplication=transactionApplication;
        }

        public void OnGet()
        {
            TransactionVMs = _transactionApplication.GetUserTransactionsForShow();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return RedirectToPage();
            var paymentResponse=_transactionApplication.TransactionPayment(TransactionCommand);

            if (paymentResponse.Status == 100)
                return Redirect("https://SandBox.Zarinpal.com/pg/StartPay/" + paymentResponse.Authority);

            return RedirectToPage();
        }

       
    }
}
