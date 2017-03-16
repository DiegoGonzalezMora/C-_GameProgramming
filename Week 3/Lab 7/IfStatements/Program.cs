using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfStatements
{
    /// <summary>
    ///  Demonstrates if statements
    /// </summary>
    class Program
    {
        /// <summary>
        /// Demonstrates various forms of if statement
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // PROBLEM 1

            // ask for and get user answer
            Console.Write("What is your month birthday?");
            string month = Console.ReadLine();

            Console.Write("\nWhat is your birth day?");
            int day = int.Parse(Console.ReadLine());

            // print appropriate message
            Console.Write("\n Your birthday is " + month + " " + day+"\n");

            // PROBLEM 2
            day = day - 1;
            Console.Write("\n You’ll receive an email reminder on " + month + " " + day + "\n");

        }
    }
}
