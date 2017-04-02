using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignment1
{
    /// <summary>
    /// Given two points from the user, tthis program calculates the distance and the angle.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Given two points from the user, tthis program calculates the distance and the angle.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome! this application will calculate the distance between two points and the angle between those points.\n\n");

            //Gets the coordinates from the user.
            Console.WriteLine("Please, introduce the X value for the first point:");
            float point1X = float.Parse(Console.ReadLine());
            Console.WriteLine("Please, introduce the Y value for the first point:");
            float point1Y = float.Parse(Console.ReadLine());
            Console.WriteLine("Please, introduce the X value for the second point:");
            float point2X = float.Parse(Console.ReadLine());
            Console.WriteLine("Please, introduce the Y value for the second point:");
            float point2Y = float.Parse(Console.ReadLine());

            //Calculate the delta x and delta y between the two points.
            double deltaX = point2X - point1X;
            double deltaY = point2Y - point1Y;

            //Calculate the distance between the two points using the Pythagorean Theorem.
            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            Console.WriteLine("\nThe distance between the two points is: " + distance.ToString("0.000"));

            //Calculate the angle we'd have to move in to go from point 1 to point 2
            const double Rad2Deg = 180.0 / Math.PI;
            double angle = Math.Atan2(deltaY, deltaX) * Rad2Deg;
            Console.WriteLine("\nThe angle between the two points is: " + angle.ToString("0.000") + " degrees\n");
        }
    }
}
