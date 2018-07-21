using System.Collections.Generic;
using System.Linq;

namespace Bidding.Framework
{
    public class Hand
    {
        private readonly HashSet<Card> Cards;
        private HashSet<Card> PlayedCards;

        public Hand(HashSet<Card> cards)
        {
            Cards = cards;
        }

        public List<Card> Show()
        {
            return Cards.Except(PlayedCards).OrderByDescending(c => c.Order()).ToList();
        }

        public bool Play(Card card)
        {
            if (!Cards.Contains(card) || PlayedCards.Contains(card))
            {
                return false;
            }
            PlayedCards.Add(card);
            return true;
        }

        public override string ToString()
        {
            return string.Join(" ", Show());
        }
    }
}