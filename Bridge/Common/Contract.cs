using EnumsNET;

namespace Bidding.Common
{
    public class Contract
    {
        public Level Level { get; }
        public ContractSuit Suit { get; }

        public Contract(Level level, ContractSuit suit)
        {
            Level = level;
            Suit = suit;
        }

        private int Order() => (int)Level * 5 + (int)Suit;

        public static bool operator >(Contract c1, Contract c2) => c1.Order() > c2.Order();
        public static bool operator <(Contract c1, Contract c2) => c1.Order() < c2.Order();

        public bool IsGame()
        {
            var level = (int)Level;
            if (Suit == ContractSuit.NoTrump && level >= 3) return true;
            if (Suit.GetAttributes().Has<MajorAttribute>() && level >= 4) return true;
            if (Suit.GetAttributes().Has<MinorAttribute>() && level >= 5) return true;
            return false;
        }

        public override string ToString()
        {
            var level = Level.GetAttributes().Get<SymbolAttribute>().Symbol;
            var suit = Suit.GetAttributes().Get<SymbolAttribute>().Symbol;
            var color = Suit.GetAttributes().Get<ColorAttribute>().AnsiCode;
            return color + level + suit + "\u001b[0m";
        }
    }
}