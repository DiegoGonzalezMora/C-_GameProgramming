using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToStrings
{
    /// <summary>
    /// Demonstrates string basics
    /// </summary>
    class Program
    {
        /// <summary>
        /// Demonstrates string basics
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // prompt for and read in gamertag
            Console.Write("Enter gamertag: ");
            string gamertag = Console.ReadLine();

            // prompt for and read in level
            Console.Write("Enter level: ");
            int level = int.Parse(Console.ReadLine());

            // extract the first character of the gamertag
            char firstGamertagCharacter = gamertag[0];

            // print out values
            Console.WriteLine();
            Console.WriteLine("Gamertag: " + gamertag);
            Console.WriteLine("Level: " + level);
            Console.WriteLine("First gamertag character: " + firstGamertagCharacter);
            Console.WriteLine();
        }
    }
}
