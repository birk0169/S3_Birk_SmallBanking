using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SmallBankingClassLibrary
{
    public class Account
    {
        private decimal balance;
        private List<Transaction> transactions = new List<Transaction>();

        //Properties
        public string AccountNumber { get; }
        public ReadOnlyCollection<Transaction> Transactions { get { return transactions.AsReadOnly(); } }

        //Methods
        public decimal CalculateCostOfMonth(Month month)
        {

        }

    }
}
