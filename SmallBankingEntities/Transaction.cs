using System;
using System.Collections.Generic;
using System.Text;

namespace SmallBankingClassLibrary
{
    public class Transaction
    {
        //Fields
        private Account transmitter;
        private Account receiver;
        private DateTime dateOfTransaction;
        private decimal amount;
        
        //Constructor
        /// <summary>
        /// The constructor of the Transaction class
        /// </summary>
        /// <param name="transmitter"></param>
        /// <param name="receiver"></param>
        /// <param name="dateOfTransaction"></param>
        /// <param name="amount"></param>
        public Transaction(Account transmitter, Account receiver, DateTime dateOfTransaction, decimal amount)
        {
            Transmitter = transmitter;
            Receiver = receiver;
            DateOfTransaction = dateOfTransaction;
            Amount = amount;
        }

        //Properties
        /// <summary>
        /// A property that returns who transmitted the transaction
        /// </summary>
        public Account Transmitter { get => transmitter; private set => transmitter = value; }
        /// <summary>
        /// A property that returns who recieved the transaction
        /// </summary>
        public Account Receiver { get => receiver; private set => receiver = value; }
        /// <summary>
        /// A property that returns the date the transaction was made in DateTime
        /// </summary>
        public DateTime DateOfTransaction { get => dateOfTransaction; private set => dateOfTransaction = value; }
        /// <summary>
        /// A property that returns the value of the transaction in the form of decimal
        /// </summary>
        public decimal Amount { get => amount; private set => amount = value; }
        /// <summary>
        /// A read only property that returns the month of the Transaction object
        /// </summary>
        public Month MonthOfTransaction
        {
            get
            {
                return (Month)DateOfTransaction.Month;
            }
        }
    }
}
