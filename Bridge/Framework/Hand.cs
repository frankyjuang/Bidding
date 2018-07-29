using System.Collections.Generic;
using System.Linq;

namespace Bidding.Framework
{
    public class Hand
    {
        private readonly HashSet<Card> _cards;
        private HashSet<Card> _playedCards = new HashSet<Card>();

        public Hand(List<Card> cards)
        {
            _cards = cards.ToHashSet();
        }

        public List<Card> Show()
        {
            return _cards.Except(_playedCards).OrderByDescending(c => c.Order()).ToList();
        }

        public bool Play(Card card)
        {
            if (!_cards.Contains(card) || _playedCards.Contains(card))
            {
                return false;
            }
            _playedCards.Add(card);
            return true;
        }

        public override string ToString()
        {
            return string.Join(" ", Show());
        }
    }
}