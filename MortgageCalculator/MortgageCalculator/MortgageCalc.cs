using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MortgageCalculator
{
    public class MortgageCalc
    {
        public static double CalcMonthlyPayment(double principle, double Rate, double years)
        {
            double top = principle * Rate / 1200.00;
            double bottom = 1 - Math.Pow(1.00 + Rate / 1200.00, -12.00 * years);
            double monthly = top / bottom;
            return monthly;
        }
    }
}