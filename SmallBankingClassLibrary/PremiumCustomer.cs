using System;
using System.Collections.Generic;
using System.Text;

namespace SmallBankingClassLibrary
{
    class PremiumCustomer : Customer
    {
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
