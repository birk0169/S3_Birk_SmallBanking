using System;
using System.Collections.Generic;
using System.Text;

namespace SmallBankingClassLibrary
{
    class Customer
    {
        //Fields
        
        private string cPR;
        private string name;
        private List<Account> accounts = new List<Account>();

        //Properties
        public decimal TransactionCost { get => GetTransactionCost(); }
        public decimal MonthlyAccountFee { get => GetMonthlyAccountFee(); }
        public string CPR { get; }
        public string Name { get; set; }
        

        /// <summary>
        /// Get a readonly list of accounts
        /// </summary>
        internal IReadOnlyCollection<Account> Accounts { get { return accounts.AsReadOnly(); } }

        //Methods
        public decimal CalculateCostOfMonth()
        {
            return 4;
        }

        /// <summary>
        /// Gets the standard transaction cost
        /// </summary>
        /// <returns>
        /// Always 1.95 in decimal
        /// </returns>
        public virtual decimal GetTransactionCost()
        {
            return decimal.Parse("1.95");
        }

        /// <summary>
        /// Gets the standard monthly account cost
        /// </summary>
        /// <returns>
        /// Always 15 in decimal
        /// </returns>
        public virtual decimal GetMonthlyAccountFee()
        {
            return decimal.Parse("15");
        }
    }
}
