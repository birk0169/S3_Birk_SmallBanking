using System;
using System.Collections.Generic;
using System.Text;

namespace SmallBankingClassLibrary
{
    public class PremiumCustomer : Customer
    {
        public PremiumCustomer(string name, string cPR) : base(name, cPR)
        {
        }

        /// <summary>
        /// Gets the standard transaction cost of a PremiumCustomer
        /// </summary>
        /// <returns>
        /// Always 1.2 in decimal
        /// </returns>
        public override decimal GetTransactionCost()
        {
            return decimal.Parse("1.2");
        }

        /// <summary>
        /// Gets the standard monthly account cost of a PremiumCustomer
        /// </summary>
        /// <returns>
        /// Always 12 in decimal
        /// </returns>
        public override decimal GetMonthlyAccountFee()
        {
            return decimal.Parse("12");
        }
    }
}
