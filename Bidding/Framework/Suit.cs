namespace Bidding.Framework
{
    public enum Suit
    {
        [Minor, Symbol("♣")]
        Club,
        [Minor, Symbol("♦")]
        Diamond,
        [Major, Symbol("♥")]
        Heart,
        [Major, Symbol("♠")]
        Spade
    }
}