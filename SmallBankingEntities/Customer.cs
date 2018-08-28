using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SmallBankingClassLibrary
{
    public class Customer
    {
        //Fields
        
        private string cPR;
        private string name;
        private List<Account> accounts = new List<Account>();

        //Constructers
        /// <summary>
        /// Constructor for the Customer class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cPR"></param>
        public Customer(string name, string cPR)
        {
            CPR = cPR;
            Name = name;
        }

        //Properties
        /// <summary>
        /// Property containing the TransactionCost of the customer
        /// </summary>
        public decimal TransactionCost { get => GetTransactionCost(); }
        /// <summary>
        /// Get Property containing the monthltAccountFee
        /// </summary>
        public decimal MonthlyAccountFee { get => GetMonthlyAccountFee(); }
        /// <summary>
        /// Gets or set(Only in constructor) the CPR value
        /// The CPR number must be exactly 9 digits.
        /// </summary>
        public string CPR
        {
            get { return cPR; }
            private set
            {
                (bool isValid, string errorMessage) = ValidateCPR(value);
                if (isValid) cPR = value;
                else
                {
                    throw new ArgumentException(errorMessage);
                }
            }
        }
        //{ get => cPR; private set => cPR = value; }
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// Get a readonly list of accounts
        /// </summary>
        public ReadOnlyCollection<Account> Accounts { get { return accounts.AsReadOnly(); } }

       

        //Methods
        public decimal CalculateCostOfMonth(Month month)
        {
            decimal cost = 0;
            foreach (Account accountItem in Accounts)
            {
                cost = cost + accountItem.CalculateCostOfMonth(month, TransactionCost);
                cost = cost + MonthlyAccountFee;
            }
            return cost;
        }

        public int AddAcount(Account account)
        {
            if (account is null) throw new ArgumentNullException(nameof(account));
            accounts.Add(account);
            return accounts.Count;
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

        private (bool isValid, string errorMessage) ValidateCPR(string value)
        {
            if (value.Length !=9)
            {
                return (false, "The length of the CPR number must be excactly 9");
            }
            else if (!int.TryParse(value, out int number))
            {
                return (false, "A CPR number may only contain numbers");
            }
            else
            {
                return (true, string.Empty);
            }
        }
    }
}
