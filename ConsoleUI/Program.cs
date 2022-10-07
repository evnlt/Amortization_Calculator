using AmortizationLoanCalculator;
using static AmortizationLoanCalculator.Calculator;
using static AmortizationLoanCalculator.TextProcessor;
using System;
using System.Globalization;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US", false);

            decimal initialPrinciple = 10_000;
            decimal interestRate = 0.05m;
            int years = 10;
            DateTime agreementDate = DateTime.Now;

            (initialPrinciple, interestRate, years, agreementDate) = EnterData();

            Console.Clear();
            PrintData(initialPrinciple, interestRate, years, agreementDate);

            decimal monthlyPayment = GetMonthlyPayment(initialPrinciple, interestRate, years);
            decimal interest = GetTotalInterest(monthlyPayment, initialPrinciple, years);

            Console.WriteLine($"\nMonthly payment: {monthlyPayment:C2}");
            Console.WriteLine($"Total interest: {interest:C2}");

            var schedule = GetScheduleList(initialPrinciple, interestRate, years, monthlyPayment, agreementDate);

            PrintScheduleTable(schedule);
        }

        public static (decimal initialPrinciple, decimal interestRate, int years, DateTime agreementDate) EnterData()
        {
            decimal initialPrinciple = 0;
            decimal interestRate = 0;
            int years = 0;
            DateTime agreementDate = DateTime.MinValue;


            bool inputIsValid = false;
            do
            {
                Console.Write("Enter initial principle: ");
                inputIsValid = decimal.TryParse(Console.ReadLine(), out initialPrinciple);

                if (!inputIsValid)
                {
                    PrintError();
                }

            } while (!inputIsValid);

            do
            {
                Console.Write("Enter interest rate (i.e. 0.05): ");
                inputIsValid = decimal.TryParse(Console.ReadLine(), out interestRate);


                if (!inputIsValid)
                {
                    PrintError();
                }
            } while (!inputIsValid);

            do
            {
                Console.Write("Enter years of loan: ");
                inputIsValid = int.TryParse(Console.ReadLine(), out years);


                if (!inputIsValid)
                {
                    PrintError();
                }
            } while (!inputIsValid);

            do
            {
                Console.Write("Enter agreement date (i.e. 31.10.2022): ");
                inputIsValid = DateTime.TryParse(Console.ReadLine(), out agreementDate);


                if (!inputIsValid)
                {
                    PrintError();
                }
            } while (!inputIsValid);

            return (initialPrinciple, interestRate, years, agreementDate);
        }
        static void PrintError()
        {
            ConsoleColor before = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error! Try again.");
            Console.ForegroundColor = before;
        }
        static void PrintData(decimal initialPrinciple, decimal interestRate, int years, DateTime agreementDate)
        {
            Console.WriteLine("Initial principle: " + initialPrinciple);
            Console.WriteLine("Interest rate: " + interestRate);
            Console.WriteLine("Years of loan: " + years);
            Console.WriteLine("Agreement date: " + agreementDate.Date.ToString("MM/dd/yyyy"));
        }

        static void PrintScheduleTable(List<ScheduleLine> schedule)
        {
            var scheduleTable = GetScheduleTable(schedule);

            foreach (var item in scheduleTable)
            {
                Console.WriteLine(item);
            }
        }
    }
}