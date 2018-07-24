using EnumsNET;

namespace Bidding.Common
{
    public class Contract
    {
        private Level _level { get; }
        private Suit? _suit { get; }

        public Contract(Level level, Suit? suit)
        {
            _level = level;
            _suit = suit;
        }

        private int Order()
        {
            if (_suit == null)
            {
                return (int)_level * 5 + 5;
            }
            return (int)_level * 5 + (int)_suit;
        }

        public static bool operator >(Contract c1, Contract c2) => c1.Order() > c2.Order();
        public static bool operator <(Contract c1, Contract c2) => c1.Order() < c2.Order();

        public bool IsGame()
        {
            var level = (int)_level;
            if (_suit == null && level >= 3) return true;
            var suit = _suit.GetValueOrDefault();
            if (suit.GetAttributes().Has<MajorAttribute>() && level >= 4) return true;
            if (suit.GetAttributes().Has<MinorAttribute>() && level >= 5) return true;
            return false;
        }

        public override string ToString()
        {
            var level = _level.GetAttributes().Get<SymbolAttribute>().Symbol;
            string suit;
            string color;
            if (_suit == null)
            {
                suit = "NT";
                color = "\u001b[0;35m";
            }
            else
            {
                var attributes = _suit.GetValueOrDefault().GetAttributes();
                suit = attributes.Get<SymbolAttribute>().Symbol;
                color = attributes.Get<ColorAttribute>().AnsiCode;
            }
            return color + level + suit + "\u001b[0m";
        }
    }
}