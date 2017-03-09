using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingDeckClass
{
    /// <summary>
    /// Demonstrates using the Deck class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Demonstrates using the Deck class
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            Deck deck = new Deck();

            //Print deck empty information
            bool IsDeckEmpty = deck.Empty;

            Console.WriteLine("Empty: "+IsDeckEmpty+"\n");

            //deck.Print();
            //// tell the deck to shuffle


            ////deck.Shuffle();

            ////Cut the deck
            //deck.Cut(26);

            //take top card and print
            Card card = deck.TakeTopCard();
            Console.WriteLine(card.Rank + " Of " + card.Suit);

            //Console.WriteLine();
            //deck.Print();



        }
    }
}
