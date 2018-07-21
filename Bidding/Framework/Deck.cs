using EnumsNET;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Bidding.Framework
{
    public class Deck : IEnumerable<Card>
    {
        private readonly List<Card> Cards;

        public Deck()
        {
            foreach (var rank in Enums.GetValues<Rank>())
            {
                foreach (var suit in Enums.GetValues<Suit>())
                {
                    Cards.Add(new Card { Suit = suit, Rank = rank });
                }
            }
            Shuffle(Cards);
        }

        private static Random rng = new Random();

        // https://stackoverflow.com/a/1262619/3748807
        private static void Shuffle(List<Card> cards)
        {
            var n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return ((IEnumerable<Card>)Cards).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Card>)Cards).GetEnumerator();
        }
    }
}