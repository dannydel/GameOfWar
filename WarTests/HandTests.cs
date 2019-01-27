using Microsoft.VisualStudio.TestTools.UnitTesting;
using WarTime.Objects;
using System.Collections.Generic;
using WarTime.Game;

namespace WarTests
{
    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void HandTests_HandCreationFirstHalf_CountIs26()
        {
            Deck deck = GameSetup.CreateDeck();
            Hand hand = new Hand();

            List<Card> list1 = deck.Cards.GetRange(0, 26);

            Assert.AreEqual(26, list1.Count);
        }

        [TestMethod]
        public void HandTests_HandCreationSecondHalf_CountIs26()
        {
            Deck deck = GameSetup.CreateDeck();
            Hand hand = new Hand();

            List<Card> list2 = deck.Cards.GetRange(26, 26);

            Assert.AreEqual(26, list2.Count);
        }
        
    }
}
