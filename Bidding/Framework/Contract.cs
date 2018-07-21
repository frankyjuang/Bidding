using EnumsNET;
using System;

namespace Bidding.Framework
{
    public class Contract : IComparable<Contract>
    {
        public Level Level { get; set; }
        public Suit? Suit { get; set; }

        private int Order() => (int)Level * 4 + (int)Suit;

        public int CompareTo(Contract other)
        {
            if (Level == other.Level && Suit == other.Suit)
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
            string suit;
            if (Suit == null)
            {
                suit = "NT";
            }
            else
            {
                suit = Suit.GetValueOrDefault().GetAttributes().Get<SymbolAttribute>().Symbol;
            }
            var level = Level.GetAttributes().Get<SymbolAttribute>().Symbol;
            return suit + level;
        }
    }
}