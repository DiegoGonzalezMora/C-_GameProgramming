using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssigment1
{
    class Program
    {
        static void Main(string[] args)
        {
            double point1X, point1Y, point2X, point2Y, deltaX, deltaY, finalX, finalY, pointsDistance;

            Console.WriteLine("Welcome!");

            Console.WriteLine();
            Console.WriteLine("This application will calculate the distance between two points and the angle between those points");

            //FIRST POINT

            // X  
            Console.WriteLine(); // FOR  "JUMPING" A  LINE
            Console.Write("Please write the X value in the first point: ");
            point1X = double.Parse(Console.ReadLine());

            // Y  
            Console.Write("Now, please write the Y value in the first point: ");
            point1Y = double.Parse(Console.ReadLine());


            // SECOND POINT

            // X 
            Console.WriteLine(); // FOR  "JUMPING" A  LINE
            Console.Write("Please write the X value in the second point: ");
            point2X = double.Parse(Console.ReadLine());

            // Y
            Console.Write("Now, please write the Y value in the second point: ");
            point2Y = double.Parse(Console.ReadLine());

            // CALCULATING THE DELTAS
            deltaX = point2X - point1X;
            deltaY = point2Y - point1Y;

            finalX = Math.Pow((deltaX), 2); // MAKING THE POTENCY OF DELTA X 
            finalY = Math.Pow((deltaY), 2); ; // MAKING THE POTENCY OF DELTA Y 
            pointsDistance = Math.Sqrt(finalX + finalY); // GETTING THE  SQUARE ROOT
            double Angle = Math.Atan2(deltaY, deltaX) * (180 / Math.PI); // GETTING THE DISTANCE
                                                                         // SEE ALL THE RESULTS Console.WriteLine(deltaX + " " + deltaY + " " +finalX + " " + finalY+" "+pointsDistance + " " + pointAngle);
            Console.WriteLine(); // FOR  "JUMPING" A  LINE
            Console.WriteLine("The distance between the 2 points is: " + "{0:F3}", pointsDistance);
            Console.WriteLine("And the angle is: " + String.Format("{0:0.000}", Angle) + " degrees");
            Console.WriteLine(); // FOR  "JUMPING" A  LINE
            Console.WriteLine("WOULD YOU KINDLY press ENTER to close this window?");
            Console.ReadLine();

        }
    