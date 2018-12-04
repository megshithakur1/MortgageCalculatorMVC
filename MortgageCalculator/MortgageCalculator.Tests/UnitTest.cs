using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Tests
{
    class UnitTest
    {
        public void ZeroTestYear30()
        {
            double mort = MortgageCalc.CalcMonthlyPayment(0, 30, .25);
            Assert.AreEqual(0.00, mort);
        }

        [TestMethod]
        public void ZeroTestYear15()
        {
            double mort = MortgageCalc.CalcMonthlyPayment(0, 15, .25);
            Assert.AreEqual(0.00, mort);
        }

        [TestMethod]
        public void TwoRateTest()
        {
            double mort = MortgageCalc.CalcMonthlyPayment(1000, 15, 2.00);
            double f = (double)mort;

            Assert.AreNotEqual(6.44, mort);
        }

    }
}
