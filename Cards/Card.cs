using System;

namespace Cards
{
    public class Card
    {
        public string Name { get; set; }
        public CardType Type { get; set; }
        public Color Color { get; set; }

        public static Card BasicLand(Color color)
        {
            switch (color)
            {
                case Color.Black:
                    return Swamp;
                case Color.Blue:
                    return Island;
                case Color.Green:
                    return Forest;
                case Color.Red:
                    return Mountain;
                case Color.White:
                    return Plains;
                default:
                    throw new ArgumentOutOfRangeException(nameof(color));
            }
        }

        public static Card Forest => new Card
        {
            Color = Color.Green,
            Name = "Forest", 
            Type = CardType.Land
        };

        public static Card Island => new Card
        {
            Color = Color.Blue,
            Name = "Island", 
            Type = CardType.Land
        };

        public static Card Mountain => new Card
        {
            Color = Color.Red,
            Name = "Mountain", 
            Type = CardType.Land
        };

        public static Card Plains => new Card
        {
            Color = Color.White,
            Name = "Plains", 
            Type = CardType.Land
        };

        public static Card Swamp => new Card
        {
            Color = Color.Black,
            Name = "Swamp", 
            Type = CardType.Land
        };
    }
}
