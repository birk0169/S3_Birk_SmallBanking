using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SmallBankingClassLibrary
{
    public class Account
    {
        //Fields
        private decimal balance;
        private string accountNumber;
        private List<Transaction> transactions = new List<Transaction>();

        //Constructor
        public Account(string accountNumber, decimal balance = 0)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }

        //Properties
        public decimal Balance { get => balance; private set => balance = value; }
        public string AccountNumber { get => accountNumber; private set => accountNumber = value; }
        public ReadOnlyCollection<Transaction> Transactions { get { return transactions.AsReadOnly(); } }

        //Methods
        public virtual decimal CalculateCostOfMonth(Month month, decimal transactionCost)
        {
            decimal cost = 0;
            foreach (Transaction transaction in Transactions)
            {
                if (transaction.MonthOfTransaction == month)
                {
                    cost = cost + transactionCost;
                }
            }
            return cost;
        }

        
        public bool Deposite(Transaction transaction)
        {
            //Placeholder
            return true;
        }

        public bool Withdraw(Transaction transaction)
        {
            //Placeholder
            return true;
        }

    }
}
