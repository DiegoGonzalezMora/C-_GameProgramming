using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchStatements
{
    /// <summary>
    /// Demonstrates the switch statement
    /// </summary>
    class Program
    {
        /// <summary>
        /// Demonstrates the switch statement
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // ask for and get user answer
            Console.Write("Pick up the shiny thing? (y, n): ");
            char answer = Console.ReadLine()[0];

            switch (answer)
            {
                case 'Y':
                case 'y':
                    Console.WriteLine("You have the shiny thing.");
                    break;
                case 'N':
                case 'n':
                    Console.WriteLine("You don't have the shiny thing.");
                    break;

                default:
                    Console.WriteLine("You are a n00b.");
                    break;

            }

            Console.WriteLine();
        }
    }
}
