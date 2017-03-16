using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToStrings
{
    /// <summary>
<<<<<<< HEAD
    /// Demonstrates string basics
=======
    /// Demostrates string basics
>>>>>>> 830fe88290bbc0470129de4d3b83496a294a6361
    /// </summary>
    class Program
    {
        /// <summary>
<<<<<<< HEAD
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
=======
        /// Demostrates string basics
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //prompt for and read in gamertag
            Console.Write("Enter gamertag: ");
            string gamertag = Console.ReadLine();

            //prompt for and read in level
            Console.Write("Enter level: ");
            int level = int.Parse(Console.ReadLine());

            // Extact the first character of the gamertag
            char firstGamerTagCharacter = gamertag[0];

            //print out values
            Console.WriteLine("\nGamertag: " + gamertag+
                "\nLevel: "+level+
                "\nFirst gamertag char: "+firstGamerTagCharacter+
                "\n");
        }
    }
}
   
>>>>>>> 830fe88290bbc0470129de4d3b83496a294a6361
