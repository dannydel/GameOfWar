using System.Collections.Generic;

namespace WarTime.Objects
{
    public class Hand
    {
        public Queue<Card> Cards { get; set; }

        public Hand()
        {
            Cards = new Queue<Card>();
        }
    }
}
