// P.12
using System.Collections.Generic;
using Bidding.Common;

namespace Bidding.Bidding.Rules
{
    public class PassiveResponseToStrongOneClub : IRule
    {
        private static readonly HashSet<Contract> _applicableContracts = new HashSet<Contract>(
            new Contract[] {
                new Contract(Level.One, Suit.Diamond)
            });
        private static readonly IEnumerable<Convention> _applicableConventions = new Convention[] { Convention.Precision };

        public ISet<Contract> ApplicableContracts => _applicableContracts;
        public IEnumerable<Convention> ApplicableConventions => _applicableConventions;
        public bool IsForcing => false;

        public RevealedInfo InformationRevealed(Bid bid, BidState state)
        {
            return new RevealedInfo { HCP = new List<Range>() { new Range { Min = 0, Max = 7 } } };
        }

        public bool MatchesConditions(Bid bid, BidState state)
        {
            if (bid.Contract == new Contract(Level.One, Suit.Diamond))
            {
                if (state.BiddingHistory.ElementAtLast(2).Contract == new Contract(Level.One, Suit.Club))
                {
                    return true;
                }
            }
            return false;
        }
    }
}