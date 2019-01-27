using System;
using System.Collections.Generic;
using WarTime.Objects;
using WarTime.Game;

namespace WarTime
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Start Game
            GameSetup.PrintStartOfGame();

            //Create Deck
            Deck deck = GameSetup.CreateDeck();

            //Split Deck
            List<Card> half1 = deck.Cards.GetRange(0, 26);
            List<Card> half2 = deck.Cards.GetRange(26, 26);
            Hand hand1 = GameSetup.CreateHand(half1);
            Hand hand2 = GameSetup.CreateHand(half2);

            //Run Game
            PlayGame.Run(hand1, hand2);
        }
    }
}


