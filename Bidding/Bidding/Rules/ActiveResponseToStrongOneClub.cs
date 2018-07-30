// P.12
using System.Collections.Generic;
using Bidding.Common;

namespace Bidding.Bidding.Rules
{
    public class ActiveResponseToStrongOneClub : IRule
    {
        private static readonly HashSet<Contract> _applicableContracts = new HashSet<Contract>(
            new Contract[] {
                new Contract(Level.One, Suit.Heart),
                new Contract(Level.One, Suit.Spade),
                new Contract(Level.Two, Suit.Club),
                new Contract(Level.Two, Suit.Diamond)
            });
        private static readonly IEnumerable<Convention> _applicableConventions = new Convention[] { Convention.Precision };

        public ISet<Contract> ApplicableContracts => _applicableContracts;
        public IEnumerable<Convention> ApplicableConventions => _applicableConventions;
        public bool IsForcing => false;

        public RevealedInfo InformationRevealed(Bid bid, BidState state)
        {
            // HCP => 8-24, Suit => 5xyz
            var info = new RevealedInfo { HCP = new List<Range>() { new Range { Min = 8, Max = 24 } } };
            info.MinSuit(bid.Contract.Suit.Value, 5);
            return info;
        }

        public bool MatchesConditions(Bid bid, BidState state)
        {
            if (state.BiddingHistory.ElementAtLast(2).Contract == new Contract(Level.One, Suit.Club))
            {
                return true;
            }
            return false;
        }
    }
}