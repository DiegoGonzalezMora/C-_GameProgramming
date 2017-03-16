using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringOperations
{
    /// <summary>
    /// Demonstrates useful string operations
    /// </summary>
    class Program
    {
        /// <summary>
        /// Demonstrates IndexOf and Substring methods
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            //Read in csv string
            Console.Write("Enter name and percent (name, percent): ");
            string csvString = Console.ReadLine();

            //Find comma location
            int commalocation = csvString.IndexOf(",");

            //Extract name and percent
            string name = csvString.Substring(0,commalocation);
            float percent = float.Parse(csvString.Substring(commalocation+1));

            //Print name and percent
            Console.Write("\nName: " + name +
                "\nPercent: " + percent+
                "\n");

        }
    }
}
