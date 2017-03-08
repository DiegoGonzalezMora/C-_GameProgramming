using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignment1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // List of necessary variables           
                float firstPointX;
                float firstPointY;
                float secondPointX;
                float secondPointY;
                float deltaX;
                float deltaY;
                double distance;
                double angle;

                // Print a message and a blank line           
                Console.WriteLine("Welcome! This program will calculate the distance and angle between two points.");
                Console.WriteLine();

                // Get the first and second points x and y coordernates           
                Console.Write("Enter the first point X coordenate: ");
                firstPointX = float.Parse(Console.ReadLine());
                Console.Write("Enter the first point y coordenate: ");
                firstPointY = float.Parse(Console.ReadLine());
                Console.Write("Enter the second point X coordenate: ");
                secondPointX = float.Parse(Console.ReadLine());
                Console.Write("Enter the second point Y coordenate: ");
                secondPointY = float.Parse(Console.ReadLine());

                // Do the calculations                    
                deltaX = secondPointX - firstPointX;
                deltaY = secondPointY - firstPointY;
                distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
                angle = Math.Atan2(deltaY, deltaX) * (180 / Math.PI);

                // Print a blank line           
                Console.WriteLine();

                // Print the results
                Console.WriteLine("Distance = " + distance.ToString("F3") + " Angle = " + angle.ToString("F3"));
            }
        }
    }