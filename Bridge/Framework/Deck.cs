using EnumsNET;
using System;
using System.Collections.Generic;

namespace Bidding.Framework
{
    public class Deck
    {
        private readonly List<Card> _cards = new List<Card>();

        public Deck()
        {
            foreach (var suit in Enums.GetValues<CardSuit>())
            {
                foreach (var rank in Enums.GetValues<Rank>())
                {
                    _cards.Add(new Card(suit, rank));
                }
            }
            Shuffle(_cards);
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

        public IEnumerable<List<Card>> Deal()
        {
            for (var i = 0; i < 52; i += 13)
            {
                yield return _cards.GetRange(i, 13);
            }
        }
    }
}