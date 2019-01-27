using System;
using System.Collections.Generic;
using WarTime.Objects;

namespace WarTime.Game
{
    public static class PlayGame
    {
        public static void Run(Hand hand1, Hand hand2)
        {
            var tempCards = new List<Card>();
            var turnCount = 0;
            
            while (hand1.Cards.Count > 0 &&
                 hand2.Cards.Count > 0)
            {
                //We don't want an forever game.
                if(turnCount > 1500)
                {
                    PrintWarWinner(hand1, hand2);
                    break;
                }

                var card1 = hand1.Cards.Dequeue();
                var card2 = hand2.Cards.Dequeue();

                PrintBattleCard("Player 1", card1);
                PrintBattleCard("Player 2", card2);
                
                tempCards.Add(card1);
                tempCards.Add(card2);

                Console.ReadLine();

                //PLAYER 1 Wins Battle!
                if (card1.Value > card2.Value)
                {
                    hand1 = AddCards(hand1, tempCards);
                    PrintBattleWinner("Player 1");                 
                }
                //Player 2 Wins Battle!
                else if (card2.Value > card1.Value)
                {
                    hand2 = AddCards(hand2, tempCards);
                    PrintBattleWinner("Player 2");
                }
                //Player 1 Cards == Player 2 Cards
                else if (card1.Value == card2.Value)
                {
                    Console.WriteLine("WAR!");
                    Console.ReadLine();

                    // The cards equal each other again!
                    while (card1.Value == card2.Value)
                    {
                        int count = 0;
                        var newCard1 = card1;
                        
                        while (hand1.Cards.Count != 0
                            && count < 4)
                        {
                            var temp = hand1.Cards.Dequeue();
                            tempCards.Add(temp);
                            newCard1 = temp;
                            count++;
                        }
                        card1 = newCard1;
                        PrintBattleCard("Player 1", card1);

                        var newCard2 = card2;
                        count = 0;
                        while(hand2.Cards.Count != 0 && count < 4)
                        {
                            var temp = hand2.Cards.Dequeue();
                            tempCards.Add(temp);
                            newCard2 = temp;
                            count++;
                        }

                        card2 = newCard2;
                        PrintBattleCard("Player 2", card2);

                        Console.WriteLine();
                    }

                    if(card1.Value > card2.Value)
                    {
                        hand1 = AddCards(hand1, tempCards);

                        PrintBattleWinner("Player 1");

                    }else if(card2.Value > card1.Value)
                    {
                        hand2 = AddCards(hand2, tempCards);

                        PrintBattleWinner("Player 2");
                    }
                }

                tempCards.Clear();

                PrintHandCounts(hand1, hand2);

                turnCount++;
            }
            PrintWarWinner(hand1, hand2);
        }
        
        private static Hand AddCards(Hand hand, List<Card> cards)
        {
            foreach (var card in cards)
            {
                hand.Cards.Enqueue(card);
            }
            return hand;
        }

        private static void PrintHandCounts(Hand player1Hand, Hand player2Hand)
        {
            Console.WriteLine(string.Format("Player 1 Cards: {0}", player1Hand.Cards.Count));
            Console.WriteLine(string.Format("Player 2 Cards: {0}", player2Hand.Cards.Count));
            Console.WriteLine();
        }

        private static void PrintWarWinner(Hand player1Hand, Hand player2Hand)
        {
            Console.WriteLine();

            if (player1Hand.Cards.Count == 52)
                Console.WriteLine("Player 1 Wins the War!");
            else
                Console.WriteLine("Player 2 Wins the War!");

            Console.ReadLine();
            Console.ReadLine();
        }

        private static void PrintBattleWinner(string player)
        {
            Console.WriteLine(string.Format("{0} wins the battle!", player));
            Console.ReadLine();
        }

        private static void PrintBattleCard(string player, Card card)
        {
            Console.WriteLine(string.Format("{0} played: {1}", player, card.Face));
            Console.WriteLine();
        }
    }

}
