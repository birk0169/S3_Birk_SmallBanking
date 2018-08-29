using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallBankingClassLibrary;

namespace UnitTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class PremiumCustomerTest
    {
        public PremiumCustomer testPremiumCustomer = new PremiumCustomer("Bob", "333224444");

        /// <summary>
        /// Test whether or not its possible to contruct a premium customer with out causing an exception.
        /// </summary>
        [TestMethod]
        public void CanCreatePemiumCustomer()
        {
            bool crashed = false;
            try
            {
                PremiumCustomer test = new PremiumCustomer("Bob", "333224444");
            }
            catch
            {

                crashed = true;
            }
            Assert.IsFalse(crashed);
        }

        [TestMethod]
        public virtual void GetTransactionCost_CorrectValue_True()
        {
            //Arrange
            Customer test = testPremiumCustomer;

            //Assert & Act
            Assert.AreEqual(test.GetTransactionCost(), decimal.Parse("1.2"));
        }

        [TestMethod]
        public virtual void GetMonthlyAccountFee_CorrectValue_True()
        {
            //Arrange
            Customer test = testPremiumCustomer;

            //Assert & Act
            Assert.AreEqual(test.GetMonthlyAccountFee(), decimal.Parse("12"));
        }

        /// <summary>
        /// Test whether the PremiumCustomer class thorws an exception when constructed with a invalid CPR
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidateCPR_TenDigitCPR_ThrowArgumentException()
        {
            PremiumCustomer test = new PremiumCustomer("name", "1");
        }





    }
}
