using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace ProgrammingAssingnment1

{

    class Program

    {

        public static double pointx = 0;

        public static double pointy = 0;

        public static int result = 0;



        static void Main(string[] args)

        {

            ///code to user///

            ///

            Console.WriteLine("Welcome User, Use This Application To Find The Distance Between two points");

            Console.WriteLine();



            ///code to select points///

            ///

            GetDisplay();

            GetResult(result);

        }

        /// <summary>

        /// GetDisplay in order to let user select points///

        /// </summary>

        static void GetDisplay()

        {

            Console.WriteLine("please select two points");

            Console.WriteLine();

        }

        static void GetResult(int result)

        {

            double pointx = 2;

            double pointy = 1;

            double pointx2 = 1;

            double pointy2 = pointy;

            double distance = 0;

            result = int.Parse(Console.ReadLine());



            switch (result)

            {

                ///solving the problem between pointx and pointy///

                ///

                case 1:

                    Console.WriteLine("enter pointx");

                    Console.WriteLine("enter pointy");

                    Console.WriteLine();

                    {

                        pointx = double.Parse(Console.ReadLine());

                        distance = Math.Sqrt((pointx - pointx2) * (pointx - pointx2) + (pointy - pointy2) * (pointy - pointy2));

                        Console.WriteLine("{0}", distance);

                        {

                            break;



                        }

                    }

            }
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