using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToStrings
{
    /// <summary>
    /// Demostrates string basics
    /// </summary>
    class Program
    {
        /// <summary>
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
   