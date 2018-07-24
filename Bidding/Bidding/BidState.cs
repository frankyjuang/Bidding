using System.Collections.Generic;

namespace Bidding.Bidding
{
    public class BidState
    {
        public IEnumerable<Bid> BiddingHistory = new List<Bid>();
        public RevealedInfo SouthRevealedInfo = new RevealedInfo { position=Position.South }; 
        public RevealedInfo WestRevealedInfo = new RevealedInfo { position=Position.West }; 
        public RevealedInfo NorthRevealedInfo = new RevealedInfo { position=Position.North }; 
        public RevealedInfo EastRevealedInfo = new RevealedInfo { position=Position.East }; 
    }
}