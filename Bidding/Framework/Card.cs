using System;
using EnumsNET;

namespace Bidding.Framework
{
    public class Card : IComparable<Card>
    {
        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

        public int Order() => (int)Rank * 4 + (int)Suit;

        public int CompareTo(Card other)
        {
            if (Rank == other.Rank && Suit == other.Suit)
            {
                return 0;
            }
            if (Order() < other.Order())
            {
                return -1;
            }
            return 1;
        }

        public override string ToString()
        {
            var rank = Rank.GetAttributes().Get<SymbolAttribute>().Symbol;
            var suit = Suit.GetAttributes().Get<SymbolAttribute>().Symbol;
            return suit + rank;
        }
    }
}