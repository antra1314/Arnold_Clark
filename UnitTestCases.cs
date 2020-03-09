using ArnoldClark;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArnoldClark.Tests
{
    [TestClass]
    public class UnitTestCases
    {

        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod()]
        public void shouldReturnTrueWhenMinDepositIs15Percentage()
        {
            _Default objValidate = new _Default();

            Boolean status = objValidate.validateMinimumDeposit(150, 1000);
            Assert.AreEqual(status, true);
        }

        public void shouldReturnFalseWhenMinDepositIsLessThan15Percentage()
        {
            _Default objValidate = new _Default();

            Boolean status = objValidate.validateMinimumDeposit(100, 1000);
            Assert.AreEqual(status, false);
        }

        [TestMethod()]
        public void calculateAmountForEachMonthWhenFinancialYearIsOneTest()
        {
            _Default objValidate = new _Default();
            string status = String.Format("{0:.##}", objValidate.calculateAmountForEachMonth(150, 1000, 1));
            Assert.AreEqual(status, "70.83");
        }

        [TestMethod()]
        public void calculateAmountForEachMonthWhenFinancialYearIsTwoTest()
        {
            _Default objValidate = new _Default();
           string status = String.Format("{0:.##}", objValidate.calculateAmountForEachMonth(150, 1000, 2));
            Assert.AreEqual(status, "35.42");
        }

        [TestMethod()]
        public void calculateAmountForEachMonthWhenFinancialYearIsThreeTest()
        {
            _Default objValidate = new _Default();
            string status = String.Format("{0:.##}", objValidate.calculateAmountForEachMonth(150, 1000, 3));
            Assert.AreEqual(status, "23.61");
        }

        [TestMethod()]
        public void validateVehiclePriceIsNotZeroTest()
        {
            _Default objValidate = new _Default();
            Boolean status = objValidate.validateVehiclePriceIsNotZero(100);
            Assert.AreEqual(status, true);            
        }

        
    }
}
