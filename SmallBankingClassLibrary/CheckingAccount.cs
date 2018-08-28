using System;
using System.Collections.Generic;
using System.Text;

namespace SmallBankingClassLibrary
{
    class CheckingAccount : Account
    {
        public int NoMonthlyFreeTransactions { get => GetMonthlyFreeTransactions(); }

        private int GetMonthlyFreeTransactions()
        {
            return 20;
        }
    }
}
