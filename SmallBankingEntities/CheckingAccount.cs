using System;
using System.Collections.Generic;
using System.Text;

namespace SmallBankingClassLibrary
{
    public class CheckingAccount : Account
    {
        //Constructor
        public CheckingAccount(string accountNumber, decimal balance = 0) : base(accountNumber, balance)
        {
        }

        //Properties
        public int NoMonthlyFreeTransactions { get => GetMonthlyFreeTransactions(); }

        private int GetMonthlyFreeTransactions()
        {
            return 20;
        }

        //Methods
        public override decimal CalculateCostOfMonth(Month month, decimal transactionCost)
        {
            decimal cost = 0;
            int freeTransactions = NoMonthlyFreeTransactions;
            foreach (Transaction transaction in Transactions)
            {
                if (freeTransactions != 0)
                {
                    if (transaction.MonthOfTransaction == month)
                    {
                        cost = cost + transactionCost;
                    }
                }
                freeTransactions = freeTransactions - 1;
            }
            return cost;
        }
    }
}
