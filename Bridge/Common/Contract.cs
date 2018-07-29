using EnumsNET;

namespace Bidding.Common
{
    public class Contract
    {
        public Level Level { get; }
        public Suit? Suit { get; }

        public Contract(Level level, Suit? suit)
        {
            Level = level;
            Suit = suit;
        }

        private int Order()
        {
            if (Suit == null)
            {
                return (int)Level * 5 + 5;
            }
            return (int)Level * 5 + (int)Suit;
        }

        public static bool operator >(Contract c1, Contract c2) => c1.Order() > c2.Order();
        public static bool operator <(Contract c1, Contract c2) => c1.Order() < c2.Order();

        public bool IsGame()
        {
            var level = (int)Level;
            if (Suit == null && level >= 3) return true;
            var suit = Suit.GetValueOrDefault();
            if (suit.GetAttributes().Has<MajorAttribute>() && level >= 4) return true;
            if (suit.GetAttributes().Has<MinorAttribute>() && level >= 5) return true;
            return false;
        }

        public override string ToString()
        {
            var level = Level.GetAttributes().Get<SymbolAttribute>().Symbol;
            string suit;
            string color;
            if (Suit == null)
            {
                suit = "NT";
                color = "\u001b[0;35m";
            }
            else
            {
                var attributes = Suit.GetValueOrDefault().GetAttributes();
                suit = attributes.Get<SymbolAttribute>().Symbol;
                color = attributes.Get<ColorAttribute>().AnsiCode;
            }
            return color + level + suit + "\u001b[0m";
        }
    }
}