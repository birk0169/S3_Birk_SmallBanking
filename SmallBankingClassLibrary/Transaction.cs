using System;
using System.Collections.Generic;
using System.Text;

namespace SmallBankingClassLibrary
{
    public class Transaction
    {
        //Properties
        public Account Transmitter { get; }
        public Account Receiver { get; }
        public DateTime DateOfTransaction { get; }
        public decimal Amount { get; }
        public Month MonthOfTransaction
        {
            get
            {
                return (Month)DateOfTransaction.Month;
            }
        }
    }
}
