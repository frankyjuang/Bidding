namespace Bidding.Framework
{
    public enum Suit
    {
        [Minor, Symbol("♣"), Color("\u001b[0;32m")]
        Club = 1,
        [Minor, Symbol("♦"), Color("\u001b[0;33m")]
        Diamond,
        [Major, Symbol("♥"), Color("\u001b[0;31m")]
        Heart,
        [Major, Symbol("♠"), Color("\u001b[0;34m")]
        Spade
    }
}