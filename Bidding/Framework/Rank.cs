namespace Bidding.Framework
{
    public enum Rank
    {
        [Symbol("2")]
        Two,
        [Symbol("3")]
        Three,
        [Symbol("4")]
        Four,
        [Symbol("5")]
        Five,
        [Symbol("6")]
        Six,
        [Symbol("7")]
        Seven,
        [Symbol("8")]
        Eight,
        [Symbol("9")]
        Nine,
        [Symbol("T")]
        Ten,
        [Symbol("J"), Hcp(1)]
        Jack,
        [Symbol("Q"), Hcp(2)]
        Queen,
        [Symbol("K"), Hcp(3)]
        King,
        [Symbol("A"), Hcp(4)]
        Ace
    }
}