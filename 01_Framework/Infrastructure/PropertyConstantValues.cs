using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Infrastructure
{
    public static class RefundTypes
    {
        public const byte PayToAccountNumber = 1;
        public const byte PayToWallet = 2;
    }

    public static class TransactionTypes
    {
        public const int Deposit = 1;
        public const int Withdraw = 2;

    }
}
