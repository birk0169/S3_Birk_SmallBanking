﻿using System;
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
        public decimal TransactionCost { get => GetTransactionCost(); }
        public decimal MonthlyAccountFee { get => GetMonthlyAccountFee(); }
        public string CPR { get => cPR; private set => cPR = value; }
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// Get a readonly list of accounts
        /// </summary>
        public ReadOnlyCollection<Account> Accounts { get { return accounts.AsReadOnly(); } }

       

        //Methods
        public decimal CalculateCostOfMonth(Month month)
        {
            return 4;
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
    }
}
