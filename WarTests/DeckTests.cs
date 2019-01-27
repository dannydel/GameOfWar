using Microsoft.VisualStudio.TestTools.UnitTesting;
using WarTime.Objects;
using WarTime.Game;

namespace WarTests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void DeckTest_CreateDeck_Has52Cards()
        {
            Deck deck = GameSetup.CreateDeck();

            Assert.AreEqual(deck.Cards.Count, 52);
        }
    }
}
