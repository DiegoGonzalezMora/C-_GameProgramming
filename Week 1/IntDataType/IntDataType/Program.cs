using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntDataType
{
    /// <summary>
    /// Demostrate integer data types
    /// </summary>
    class Program
    {
        /// <summary>
        /// Demostrate integer data types
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // declare integer variable and constant
            int totalSecondsPlayed = 100;
            const int SecondsPerMinute = 60;


            //calculate minutes and seconds
            int minutes = totalSecondsPlayed / SecondsPerMinute;
            int seconds = totalSecondsPlayed % SecondsPerMinute;

            //print  results
            Console.WriteLine("Minutes: " + minutes);
            Console.WriteLine("Seconds: " + seconds);
            Console.WriteLine();
        }
    }
}
