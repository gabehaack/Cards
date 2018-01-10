using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cards
{
    public class Deck
    {
        public const int LimitedMinCount = 40;
        private static readonly Random Random = new Random();

        private Stack<Card> _cards;

        public Deck(IEnumerable<Card> cards)
        {
            _cards = new Stack<Card>(cards);
        }

        public void Shuffle()
        {
            var oldCards = _cards.ToList();
            var newCards = new Stack<Card>();

            while (oldCards.Count > 0)
            {
                int index = Random.Next(oldCards.Count);
                var card = oldCards[index];
                newCards.Push(card);
                oldCards.Remove(card);
            }

            _cards = newCards;
        }

        public Card Draw()
        {
            return _cards.Pop();
        }
    }
}
