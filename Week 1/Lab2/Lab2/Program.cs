/*
 
Lab 2 – Variables and Constants
Instructions:  Complete each problem.If you're struggling with a problem, feel free to 
ask questions on the class forum.
This lab is optional, but it gives you valuable programming experience.You should
definitely complete the lab if you can.
Problem 1 – Declaring and Using Variables
Create a new C# Console Project named Lab2.
In the
Main
 method, do the following:
Declare a variable named
age
 of type
int
.
Store your age in this variable.
Print the value of the variable to the user.
Problem 2 – Declaring and Using Constants and Variables
In the
Main
 method, add the following:
Declare a constant named
MaxScore
 of type
int
 and assign it a value of 100.
Declare a variable named
score
 of type
int
 and assign it a value between 0 and 100.
Declare a variable named
percent
 of type
float
 and store the percentage calculated by
dividing
score
 by
MaxScore
.Remember how integer division works in C# and use type 
casting as appropriate.
Print the percentage to the user.

    */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Problem 1
            int age = 26;
            Console.WriteLine("My age is " + age + " years");
            Console.WriteLine();

            //Problem 2
            const int MaxScore=100;
            int score = 99;
            float percent = (float)score / MaxScore;
            Console.WriteLine("Your score percentage is " + percent + "%.");
            Console.WriteLine();
        }
    }
}
