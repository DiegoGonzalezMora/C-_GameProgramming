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

/*
 * 
 * 
 * 
 * 
Greetings

I am sorry i gave you such a low score, i will try to explain my reasons.

* According to the first 2 criteria points the code should:
  - Follow coding standard.
  - Use appropriate implementation approach to solve the problem. 

I gave you 1 point because your code follows the coding standards given here:
https://www.coursera.org/learn/game-programming/supplement/ZvjcM/course-coding-standards

However i consider that your code is overly complex and uses unnecessary techniques such as methods and the switch statement that are correct, but we have not seen yet in this course. I appreciate that you have experience as programmer, however your program doesn't stick to this course guidelines as you can read in the Advice for Nonbeginners here:
https://www.coursera.org/learn/game-programming/supplement/AW5gl/advice-for-beginners-and-nonbeginners

* The following 6 criteria says:
  - Prints welcome message
  - Prompts for and gets x and y for first point
  - Prompts for and gets x and y for second point
  - Displays correct value for distance between points with appropriate label and 3 decimal points
  - Displays correct angle between points with appropriate label and 3 decimal points
  - Angle between points is in degrees, not radians.

After taking a look at the code i could see that 
*/
