using EnumsNET;

namespace Bidding.Framework
{
    public class Card
    {
        public Suit suit { get; }
        public Rank rank { get; }

        public Card(Suit s, Rank r)
        {
            suit = s;
            rank = r;
        }

        public int Order() => (int)suit * 13 + (int)rank;

        public static bool operator >(Card c1, Card c2) => c1.Order() > c2.Order();
        public static bool operator <(Card c1, Card c2) => c1.Order() < c2.Order();

        public override string ToString()
        {
            var rank = this.rank.GetAttributes().Get<SymbolAttribute>().Symbol;
            var suit = this.suit.GetAttributes().Get<SymbolAttribute>().Symbol;
            var color = this.suit.GetAttributes().Get<ColorAttribute>().AnsiCode;
            return color + suit + rank + "\u001b[0m";
        }
    }
}