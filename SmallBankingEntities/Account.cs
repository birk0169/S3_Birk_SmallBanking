using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SmallBankingClassLibrary
{
    abstract public class Account
    {
        //Fields
        private decimal balance;
        private string accountNumber;
        protected List<Transaction> transactions = new List<Transaction>();

        //Constructor
        public Account(string accountNumber, decimal balance = 0)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }

        //Properties
        /// <summary>
        /// A property containing the account balance of an Account
        /// </summary>
        public decimal Balance { get => balance; private set => balance = value; }
        /// <summary>
        /// A property that contains the account number of an Account
        /// </summary>
        public string AccountNumber { get => accountNumber; private set => accountNumber = value; }
        /// <summary>
        /// A property that containst a read only list of all the Accounts Transactions.
        /// </summary>
        public ReadOnlyCollection<Transaction> Transactions { get { return transactions.AsReadOnly(); } }

        //Methods
        /// <summary>
        /// A method that returns the total transactions cost of a month
        /// </summary>
        /// <param name="month"></param>
        /// <param name="transactionCost"></param>
        /// <returns>The total transaction costs of the input month in decimal</returns>
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

        /// <summary>
        /// A method that handles transactions which either deposite or withdraw from a Account
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns>
        /// A bool statement of whether or not the process succeeded.
        /// </returns>
        public bool Process(Transaction transaction)
        {
            if (transaction.Receiver == transaction.Transmitter)
            {
                //Considering making it throw an exception here instead of just returning false.
                return false;
            }
            else if (transaction.Transmitter == this)
            {
                if (transaction.Amount >= Balance)
                {
                    return false;
                }
                else
                {
                    //Withdrawl
                    Balance -= transaction.Amount;
                    transactions.Add(transaction);
                    return true;
                }
            }
            else if(transaction.Receiver == this)
            {
                //Deposite
                Balance += transaction.Amount;
                transactions.Add(transaction);
                return true;
            }
            else
            {
                return false;
            }
        }

        
        //public bool Deposite(Transaction transaction)
        //{
        //    //Placeholder
        //    return true;
        //}

        //public bool Withdraw(Transaction transaction)
        //{
        //    //Placeholder
        //    return true;
        //}

    }
}
