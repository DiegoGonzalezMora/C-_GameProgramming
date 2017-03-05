using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatDataType
{
    /// <summary>
    /// Demonstrate floating point numbers
    /// </summary>
    class Program
    {
        /// <summary>
        /// Demonstrate floating point numbers
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //declare variables
            int score = 1356;
            int toTalSecondsPlayed = 10000;

            //calculate and display result
            float pointsPerSeconds = (float)score / toTalSecondsPlayed;
            Console.WriteLine("Points per second: " + pointsPerSeconds);


        }
    }
}
