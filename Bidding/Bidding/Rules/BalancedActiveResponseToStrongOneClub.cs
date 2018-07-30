// P.13
using System.Collections.Generic;
using Bidding.Common;

namespace Bidding.Bidding.Rules
{
    public class BalancedActiveResponseToStrongOneClub : IRule
    {
        private static readonly HashSet<Contract> _applicableContracts = new HashSet<Contract>(
            new Contract[] {
                new Contract(Level.One, null),
                new Contract(Level.Two, null),
            });
        private static readonly IEnumerable<Convention> _applicableConventions = new Convention[] { Convention.Precision };

        public ISet<Contract> ApplicableContracts => _applicableContracts;
        public IEnumerable<Convention> ApplicableConventions => _applicableConventions;
        public bool IsForcing => false;

        public RevealedInfo InformationRevealed(Bid bid, BidState state)
        {
            // Suit => [1-4]{4}
            // HCP =>
            // 1NT: 8-13, 16-24
            // 2NT: 14-15
            var info = new RevealedInfo();
            info.MaxAllSuits(4);
            info.MinAllSuits(1);
            if (bid.Contract.Level == Level.One)
            {
                info.HCP = new List<Range> {
                    new Range { Min = 8, Max = 13 },
                    new Range { Min = 16, Max = 24 }
                };
            }
            else if (bid.Contract.Level == Level.Two)
            {
                info.HCP = new List<Range> { new Range { Min = 14, Max = 15 } };
            }
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