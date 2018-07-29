using System.Collections.Generic;

namespace Bidding.Bidding
{
    public class BidState
    {
        public IEnumerable<Bid> BiddingHistory = new List<Bid>();
        public RevealedInfo SouthRevealedInfo = new RevealedInfo { Position=Position.South }; 
        public RevealedInfo WestRevealedInfo = new RevealedInfo { Position=Position.West }; 
        public RevealedInfo NorthRevealedInfo = new RevealedInfo { Position=Position.North }; 
        public RevealedInfo EastRevealedInfo = new RevealedInfo { Position=Position.East }; 
    }
}