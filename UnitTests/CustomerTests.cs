using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallBankingClassLibrary;
namespace UnitTests
{
    [TestClass]
    public class CustomerTests
    {
        public Customer testCustomer = new Customer("Name", "333224444");
        [TestMethod]
        public void CanCreateCustomer()
        {
            bool crashed = false;
            try
            {
                Customer test = testCustomer;
                
            }
            catch
            {

                crashed = true;
            }
            Assert.IsFalse(crashed);

        }

        /// <summary>
        /// Tests whether the naming property of the Customer class is working properly
        /// </summary>
        [TestMethod]
        public void CustomerName_Working()
        {
            //Arrange
            Customer test = testCustomer;

            //Act & Assert
            Assert.AreEqual(test.Name, "Name");
        }

        [TestMethod]
        public virtual void GetTransactionCost_CorrectValue_True()
        {
            //Arrange
            Customer test = testCustomer;

            //Assert & Act
            Assert.AreEqual(test.GetTransactionCost(), decimal.Parse("1.95"));
        }

        [TestMethod]
        public virtual void GetMonthlyAccountFee_CorrectValue_True()
        {
            //Arrange
            Customer test = testCustomer;

            //Assert & Act
            Assert.AreEqual(test.GetMonthlyAccountFee(), decimal.Parse("15"));
        }

        /// <summary>
        /// Test whether the Customer class thorws an exception when constructed with a invalid CPR
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidateCPR_TenDigitCPR_ThrowArgumentException()
        {
            Customer test = new Customer("name", "1");
        }
    }
}
