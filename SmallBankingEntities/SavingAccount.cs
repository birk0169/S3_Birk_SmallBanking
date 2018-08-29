using System;
using System.Collections.Generic;
using System.Text;

namespace SmallBankingClassLibrary
{
    public class SavingAccount : Account
    {
        //Fields
        private decimal interest;

        //Constructor
        public SavingAccount(string accountNumber, decimal interest, decimal balance = 0) : base(accountNumber, balance)
        {
            Interest = interest;
        }

        //Properties
        /// <summary>
        /// A property holding interest rate in % in decimal
        /// </summary>
        public decimal Interest { get => interest; set => interest = value; }

        //Methods
        public decimal CalculateYearlyIntrest()
        {
            decimal rate = Interest / 100;
            return Balance* rate;
        }
    }
}
