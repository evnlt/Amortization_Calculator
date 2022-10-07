using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmortizationLoanCalculator
{
    public static class TextProcessor
    {
        private static string br = "|---------------------------------------------------------------------------------------------------------------|";

        public static List<string> GetScheduleTable(List<ScheduleLine> schedule)
        {
            var table = new List<string>();

            table.AddRange(GetTableHeader());
            table.AddRange(GetTableBody(schedule));

            return table;
        }
        private static List<string> GetTableHeader()
        {
            var header = new List<string>();

            header.Add(br);
            header.Add($"| {TabSmall("Date")}| {Tab("Start Balance")}| {Tab("Principal")}| {Tab("Interest")}| {Tab("End Balance")}|");
            header.Add(br);

            return header;
        }

        private static List<string> GetTableBody(List<ScheduleLine> schedule)
        {
            var body = new List<string>();

            foreach (var line in schedule)
            {
                body.Add($"| {TabSmall($"{line.Date.ToString("yyyy MMM")}")}| {Tab($"{line.BeginingBalance:C2}")}| {Tab($"{line.Principal:C2}")}| {Tab($"{line.Interest:C2}")}| {Tab($"{line.EndBalance:C2}")}|");
            }

            return body;
        }

        private static string Tab(string str)
        {
            if (str.Length > 5)
                str += "\t\t";
            else
                str += "\t\t\t";

            return str;
        }

        private static string TabSmall(string str)
        {
            if (str.Length < 6)
                str += "\t\t";
            else
                str += "\t";

            return str;
        }
    }
}
