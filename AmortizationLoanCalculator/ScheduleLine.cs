using System;
using System.Collections.Generic;
using System.Text;

namespace AmortizationLoanCalculator
{
    public class ScheduleLine
    {
        public DateTime Date { get; }

        public decimal BeginingBalance { get; }

        public decimal Principal { get; }

        public decimal Interest { get; }

        public decimal EndBalance { get; }

        public ScheduleLine(DateTime date, decimal beginingBalance, decimal principal, decimal interest, decimal endBalance)
        {
            Date = date;
            BeginingBalance = beginingBalance;
            Principal = principal;
            Interest = interest;
            EndBalance = endBalance;
        }
    }
}
