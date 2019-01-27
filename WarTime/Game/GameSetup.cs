using System;
using System.Collections.Generic;
using System.Linq;
using WarTime.Objects;

namespace WarTime.Game
{
    public static class GameSetup
    {
        public static Deck CreateDeck()
        {
            string[] suits = { "Diamond", "Club", "Spades", "Heart" };
            int[] values = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            string[] faces = {"Two", "Three", "Four", "Five", "Six", "Seven", "Eight",
                                    "Nine", "Ten", "Jack", "Queen","King", "Ace"};

            Deck deck = new Deck();
            List<Card> tempCards = new List<Card>();

            foreach (var suit in suits)
            {
                for (var x = 0; x < values.Length; x++)
                {
                    tempCards.Add(new Card(values[x], faces[x], suit));
                }

            }
            deck.Cards = tempCards;

            return RandomizeDeck(deck);
        }

        private static Deck RandomizeDeck(Deck deck)
        {
            List<Card> randomCards = deck.Cards.OrderBy(x => Guid.NewGuid()).ToList();

            deck.Cards = randomCards;

            return deck;
        }

        public static Hand CreateHand(List<Card> halfDeck)
        {
            Hand hand = new Hand();

            foreach(var card in halfDeck)
            {
                hand.Cards.Enqueue(card);
            }

            return hand;
        }

        public static void PrintStartOfGame()
        {
            Console.WriteLine("War the Card Game");
            Console.WriteLine("Coded by Danny Del Grosso");
            Console.WriteLine("Hit any key to start!");
            Console.ReadLine();
        }


    }
}
