using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<pyramid slot number>,<block letter>,<whether or not the block should be lit>");
            string userInput = Console.ReadLine();

            int PyramidSlotNumber = int.Parse(userInput.Substring( 0, userInput.IndexOf(",") ));
            string blockNumber = userInput.Substring(userInput.IndexOf(",")+1, 1);
            bool lit = bool.Parse(userInput.Substring(userInput.IndexOf(blockNumber)+2));

            // Print
            Console.Write("Pyramid Slot Number: "+ PyramidSlotNumber+
                "\nBlock letter: "+blockNumber+
                "\nLit: "+ lit + "\n");
        }
    }
}
