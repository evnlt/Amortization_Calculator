using System;
using System.Collections.Generic;
using System.Text;

namespace AmortizationLoanCalculator
{
    public static class Calculator
    {
        public static decimal GetMonthlyPayment(decimal initialPrinciple, decimal interestRate, int years)
        {
            decimal pow = (decimal)Math.Pow((double)(1 + interestRate / 12), (-12 * years));
            decimal monthlyPayment = (interestRate * initialPrinciple) / (12 * (1 - pow));

            return monthlyPayment;
        }

        public static decimal GetTotalInterest(decimal monthlyPayment, decimal initialPrinciple, int years)
        {
            return 12 * monthlyPayment * years - initialPrinciple;
        }

        public static List<ScheduleLine> GetScheduleList(decimal initialPrinciple, decimal interestRate, int years, decimal monthlyPayment, DateTime agreementDate)
        {
            var schedule = new List<ScheduleLine>(years*12);
            
            decimal beginingBalance = initialPrinciple;
            decimal interest = beginingBalance * interestRate / 12;
            decimal principle = monthlyPayment - interest;
            decimal endBalance = beginingBalance - principle;
            DateTime date = agreementDate;

            for (int i = 0; i < years*12; i++)
            {
                var line = new ScheduleLine(date, beginingBalance, principle, interest, endBalance);
                schedule.Add(line);

                interest = beginingBalance * interestRate / 12;
                principle = monthlyPayment - interest;
                beginingBalance = endBalance;
                endBalance -= principle;
                date = date.AddMonths(1);
            }
            return schedule;
        }
    }
}
