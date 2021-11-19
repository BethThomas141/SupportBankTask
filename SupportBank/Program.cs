using System;
using System.Collections.Generic;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> UserDictionary =
                new Dictionary<string, double>();
            
            List<string> names = new List<string>();    
            string path = "C:/Work/Training/SupportBank/Transactions2014.csv";
    
            string[] lines = System.IO.File.ReadAllLines(path);
            
            //creating a dictionary key for each person in the transactions sheet
            foreach (string line in lines)
            {
                string[] columns = line.Split(',');
                try
                {
                    UserDictionary.Add(columns[1], 0);
                }
                catch (ArgumentException)
                {
                    continue;
                }

                try
                {
                    UserDictionary.Add(columns[2], 0);
                }
                catch (ArgumentException)
                {
                    continue;
                }
            }

            foreach (string line in lines)
            {
                string[] columns = line.Split(',');
                string MoneyString = columns[4];
                try
                {
                    double MoneyDouble = Convert.ToDouble(MoneyString);
                    UserDictionary[columns[1]] -= MoneyDouble;
                    UserDictionary[columns[2]] += MoneyDouble;
                }
                catch
                {
                    continue;
                }
            }

            Console.WriteLine("What would you like to know?");
            string UserInput = Console.ReadLine();
            if (UserInput.ToLower() == "list all")
            {
                foreach (KeyValuePair<string, double> entry in UserDictionary)
                {
                    if (entry.Value < 0)
                    {
                        Console.WriteLine($"{entry.Key} owes £{Math.Round(-1*entry.Value,2)}");
                    }
                    else
                    {
                        Console.WriteLine($"{entry.Key} is owed £{Math.Round(entry.Value,2)}");
                    }
                }
            }
            

        }
    }
}