using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallBankingClassLibrary;

namespace UnitTests
{
    [TestClass]
    public class SavingAccountTests
    {
        public SavingAccount testSavingAccount = new SavingAccount("22334455", decimal.Parse("2"));
        public SavingAccount testSavingAccount2 = new SavingAccount("33445566", decimal.Parse("2"), 400);

        /// <summary>
        /// Tests whether it is possible to create a opject of the SavingAccount without an exception being thrown.
        /// </summary>
        [TestMethod]
        public void CanCreateSavingAccount()
        {
            bool crashed = false;
            try
            {
                SavingAccount test = new SavingAccount("22334455", decimal.Parse("2"));
            }
            catch 
            {
                crashed = true;
                
            }
            Assert.IsFalse(crashed);
        }


        ///PROPERTIES
        /// <summary>
        /// Tests the Balance property
        /// </summary>
        [TestMethod]
        public void BalanceProperty_Correct()
        {
            //Arrange
            string testAccountNumber = "22334455";
            decimal testAccountInterest = 2;
            decimal testAccountBalance = 400;
            SavingAccount test = new SavingAccount(testAccountNumber, testAccountInterest, testAccountBalance);

            //Act & Assert
            Assert.AreEqual(testAccountBalance, test.Balance);
        }

        /// <summary>
        /// Tests the AccountNumber property
        /// </summary>
        [TestMethod]
        public void AccountNumberProperty_Correct()
        {
            //Arrange
            string testAccountNumber = "22334455";
            decimal testAccountInterest = 2;
            decimal testAccountBalance = 400;
            SavingAccount test = new SavingAccount(testAccountNumber, testAccountInterest, testAccountBalance);

            //Act & Assert
            Assert.AreEqual(testAccountNumber, test.AccountNumber);
        }

        /// <summary>
        /// Tests the Interest property
        /// </summary>
        [TestMethod]
        public void InterestProperty_Correct()
        {
            //Arrange
            string testAccountNumber = "22334455";
            decimal testAccountInterest = 2;
            decimal testAccountBalance = 400;
            SavingAccount test = new SavingAccount(testAccountNumber, testAccountInterest, testAccountBalance);

            //Act & Assert
            Assert.AreEqual(testAccountInterest, test.Interest);
        }

        [TestMethod]
        public void ReadOnlyTransactionsList()
        {
            //Arrange
            SavingAccount test1 = new SavingAccount("22334455", 2, 200);
            SavingAccount test2 = new SavingAccount("33445566", 3, 200);

            Transaction firstTransaction = new Transaction(test1, test2, DateTime.Now, 100);
            Transaction secondTransaction = new Transaction(test2, test1, DateTime.Now, 100);
            Transaction thirdTransaction = new Transaction(test1, test2, DateTime.Now, 100);

            //Act
            test1.Process(firstTransaction);
            test2.Process(firstTransaction);
            test1.Process(secondTransaction);
            test2.Process(secondTransaction);
            test1.Process(thirdTransaction);
            test2.Process(thirdTransaction);

            //Assert
            Assert.AreEqual(3, test1.Transactions.Count);
            
        }

        /// <summary>
        /// Tests that the balance change after a transaction
        /// </summary>
        [TestMethod]
        public void BalanceProperty_Change()
        {
            //Arrange
            SavingAccount testTransmitter = testSavingAccount2;
            SavingAccount testReceiver = testSavingAccount;

            //Act
            Transaction testTransaction = new Transaction(testTransmitter, testReceiver, DateTime.Now, 200);
            testTransmitter.Process(testTransaction);
            testReceiver.Process(testTransaction);

            //Assert
            Assert.AreEqual(200, testReceiver.Balance);
        }


        //METHODS

        [TestMethod]
        public void Process_ProcessReturn_True()
        {
            //Arrange
            SavingAccount test1 = new SavingAccount("22334455", 2, 200);
            SavingAccount test2 = new SavingAccount("33445566", 3, 200);

            Transaction testTransaction = new Transaction(test1, test2, DateTime.Now, 100);

            //Act & Assert
            Assert.IsTrue(test1.Process(testTransaction));
            
        }

        [TestMethod]
        public void Process_ProcessWithdrawlLessThanBalance_False()
        {
            //Arrange
            SavingAccount test1 = new SavingAccount("22334455", 2);
            SavingAccount test2 = new SavingAccount("33445566", 3, 200);

            Transaction testTransaction = new Transaction(test1, test2, DateTime.Now, 100);

            //Act & Assert
            Assert.IsFalse(test1.Process(testTransaction));

        }

        [TestMethod]
        public void Process_SameTransmitterAsReceiver_False()
        {
            //Arrange
            SavingAccount test1 = new SavingAccount("22334455", 2, 200);

            Transaction testTransaction = new Transaction(test1, test1, DateTime.Now, 100);

            //Act & Assert
            Assert.IsFalse(test1.Process(testTransaction));

        }

        /// <summary>
        /// Tests whether the CateYearlyInterest method in the SavingAccount class gives the correct output
        /// </summary>
        [TestMethod]
        public void CalculateYearlyInterest_IsExpectedNumber_True()
        {
            //Arrange
            SavingAccount test = testSavingAccount2;

            //Act
            decimal interest = test.CalculateYearlyIntrest();
            decimal expectedNumber = decimal.Parse("400") * decimal.Parse("0,02");

            //Assert
            Assert.AreEqual(expectedNumber, interest);
        }
    }
}
