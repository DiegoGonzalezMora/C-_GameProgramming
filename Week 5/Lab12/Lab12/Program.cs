using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCards;

namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Card[] cards = new Card[4];

            deck.Shuffle();

            cards[0] = deck.TakeTopCard();
            cards[0].FlipOver();
            cards[0].Print();

            Console.WriteLine();

            cards[1] = deck.TakeTopCard();
            cards[1].FlipOver();
            cards[0].Print();
            cards[1].Print();

        }
    }
}
