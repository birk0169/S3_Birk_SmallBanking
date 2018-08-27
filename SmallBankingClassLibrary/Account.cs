using System;
using System.Collections.Generic;
using System.Text;

namespace SmallBankingClassLibrary
{
    class Account
    {
        private decimal balance;
        //private bool deposite;
        //private bool withdrawl
        private List<Transaction> transactions;

        //Properties
        public string AccountNumber { get; }
        public IReadOnlyCollection<Transaction> MyProperty { get; }

        //Methods
        public void CalculateCost()
        {

        }

    }
}
