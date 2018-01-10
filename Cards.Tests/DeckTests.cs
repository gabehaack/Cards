using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Cards.Tests
{
    public class DeckTests
    {
        private static readonly Random Random = new Random();

        private readonly ITestOutputHelper _output;

        public DeckTests(ITestOutputHelper output)
        {
            _output = output;
        }


        [Fact]
        public void LandCount()
        {
            var results = new List<Tuple<int, int>>();
            var cards = CreateLimitedDeckCards(Color.Black, Color.Blue);
            int testCount = 10000;
            for (int i = 0; i < testCount; i++)
            {
                var hand = CreateStartingHand(cards);

                int lands = hand
                    .Count(c => c.Type == CardType.Land);
                int matchingNonlands = hand
                    .Count(c =>
                        c.Type != CardType.Land &&
                        hand.Any(h =>
                            h.Color == c.Color &&
                            h.Type == CardType.Land
                        )
                    );
                results.Add(Tuple.Create(lands, matchingNonlands));
            }

            var landAverage = results.Average(r => r.Item1);
            var matchAverage = results.Average(r => r.Item2);

            _output.WriteLine($"Land Avg: {landAverage}");
            _output.WriteLine($"Match Avg: {matchAverage}");
        }

        [Fact]
        public void NonlandCount()
        {
            var results = new List<Tuple<int, int>>();
            var cards = CreateLimitedDeckCards(Color.Black, Color.Blue);
            int testCount = 10000;
            for (int i = 0; i < testCount; i++)
            {
                var hand = CreateStartingHand(cards);

                int lands = hand
                    .Count(c => c.Type == CardType.Land);
                int matchingNonlands = hand
                    .Count(c =>
                        c.Type != CardType.Land &&
                        hand.Any(h =>
                            h.Color == c.Color &&
                            h.Type == CardType.Land
                        )
                    );
                results.Add(Tuple.Create(lands, matchingNonlands));
            }

            var landAverage = results.Average(r => r.Item1);
            var matchAverage = results.Average(r => r.Item2);

            _output.WriteLine($"Land Avg: {landAverage}");
            _output.WriteLine($"Match Avg: {matchAverage}");
        }

        private static List<Card> CreateStartingHand(IEnumerable<Card> cards)
        {
            var deck = new Deck(cards);
            deck.Shuffle();
            var hand = new List<Card>();
            for (int j = 0; j < 7; j++)
            {
                hand.Add(deck.Draw());
            }
            return hand;
        }

        private static List<Card> CreateLimitedDeckCards(Color color1, Color color2, int landCount = 17)
        {
            var cards = new List<Card>();
            var landColorCount = Math.DivRem(landCount, 2, out int landRem);
            for (int i = 0; i < landColorCount + landRem; i++)
            {
                cards.Add(Card.BasicLand(color1));
            }
            for (int i = 0; i < landColorCount; i++)
            {
                cards.Add(Card.BasicLand(color2));
            }

            var nonlandColorCount = Math.DivRem(Deck.LimitedMinCount - landCount, 2, out int nonlandRem);
            for (int i = 0; i < nonlandColorCount + nonlandRem; i++)
            {
                cards.Add(CreateCreatureCard(color1));
            }
            for (int i = 0; i < nonlandColorCount; i++)
            {
                cards.Add(CreateCreatureCard(color2));
            }

            return cards;
        }

        private static Card CreateCreatureCard(Color color)
        {
            return new Card
            {
                Color = color,
                Name = $"{Random.Next()}",
                Type = CardType.Creature
            };
        }
    }
}
