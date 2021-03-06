using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Infrastructure
{
    public static class Roles
    {
        public static long Administrator = 1;
        public static long AdminAssistant = 2;
        public static long CommonUser = 3;
    }
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
