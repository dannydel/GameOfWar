
namespace WarTime.Objects
{

    public class Card
    {
        public Card(int value, string face, string suit)
        {
            Value = value;
            Face = face;
            Suit = suit;
        }

        public int Value { get; set; }

        public string Face { get; set; }

        public string Suit { get; set; }
    }
}
