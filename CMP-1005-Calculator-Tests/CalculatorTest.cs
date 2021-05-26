using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CMP_1005_Calculator_Tests
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow(1, 2)]
        [DataRow(4, 7)]
        [DataRow(9, 5)]
        [DataRow(2, 17)]
        [TestCategory("Addition")]
        public void AddingTwoPositiveNumbersShouldResultInAPositiveNumber(double left, double right)
        {
            double result = CMP_1005_Calculator.Calculator.add(left, right);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(-1, -2)]
        [DataRow(-4, -7)]
        [DataRow(-9, -5)]
        [DataRow(-2, -17)]
        [TestCategory("Addition")]
        public void AddingTwoNegativeNumbersShouldResultInANegativeNumber(double left, double right)
        {
            //double left = -1;
            //double right = -2;
            double result = CMP_1005_Calculator.Calculator.add(left, right);
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        [TestCategory("Addition")]
        public void AddingTwoNumbersShouldNotDependOnOrder()
        {
            double left = 1;
            double right = 2;
            double result = CMP_1005_Calculator.Calculator.add(left, right);
            double result2 = CMP_1005_Calculator.Calculator.add(right, left);
            Assert.IsTrue(result == result2);
        }

        [TestMethod]
        [TestCategory("Addition")]
        public void AddingTwoDoublesShouldResultInADouble()
        {
            double left = 1;
            double right = 2;
            object result = CMP_1005_Calculator.Calculator.add(left, right);
            Assert.IsInstanceOfType(result, typeof(double));
        }

        [TestMethod]
        [TestCategory("Division")]
        [TestCategory("Exception")]
        public void DividingByZeroShouldProduceAnException()
        {
            double left = 1;
            double right = 0;

            Assert.ThrowsException<DivideByZeroException>(() => CMP_1005_Calculator.Calculator.divide(left, right));
        }

        [TestMethod]
        [TestCategory("Division")]
        public void DividingByNegativeNumbersShouldCalculate()
        {
            double left = 10;
            double right = -2;

            double result = CMP_1005_Calculator.Calculator.divide(left, right);
            Assert.AreEqual(-5, result);
        }

        [TestMethod]
        [TestCategory("Division")]
        public void DividingTwoNumbersShouldProduceDifferentResultsDependingOnOrder()
        {
            double left = 10;
            double right = 2;

            double result = CMP_1005_Calculator.Calculator.divide(left, right);
            double result2 = CMP_1005_Calculator.Calculator.divide(right, left);
            Assert.IsTrue(result != result2);
        }
    }
}
