namespace Bidding.Bidding
{
    public class BidEngine
    {
        public BidEngine()
        {
            // specify the convention, read rules
        }

        public BidState MakeBid(Bid bid, BidState bidState)
        {
            return bidState;
        }

        public string QueryBid(Bid bid, BidState bidState)
        {
            // check against all known rules.
            // if does not match, use Natural rule
            return "";
        } 
    }
}