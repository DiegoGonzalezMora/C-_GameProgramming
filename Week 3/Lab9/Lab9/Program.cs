using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchStatements
{
    /// <summary>
    /// Demonstrates the switch statement
    /// </summary>
    class Program
    {
        /// <summary>
        /// Demonstrates the switch statement
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // ask for and get user answer
            Console.WriteLine("*****************"+
                "\nMenu:"+
                "\nN - New game" +
                "\nL - Load game"+
                "\nO - Options"+
                "\nQ - Quit"+
                "\n*****************"
                );


            char answer = Console.ReadLine()[0];

            switch (answer)
            {
                case 'N':
                case 'n':
                    Console.WriteLine("New game started.");
                    break;
                case 'L':
                case 'l':
                    Console.WriteLine("Pick a save: \n- Save 1.\n- Save 2.\n\nBACK");
                    break;
                case 'O':
                case 'o':
                    Console.WriteLine("\n- Graphics. \n- Sounds. \nControls.\n\nBACK");
                    break;

                default:
                    Console.WriteLine("Option not found.");
                    break;

            }

            // print appropriate message

            Console.WriteLine();
        }
    }
}
