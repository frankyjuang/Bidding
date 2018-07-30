// P.11
using System.Collections.Generic;
using Bidding.Common;

namespace Bidding.Bidding.Rules
{
    public class StrongOneClub : IRule
    {
        private static readonly HashSet<Contract> _applicableContracts = new HashSet<Contract>(
            new Contract[] {
                new Contract(Level.One, Suit.Club)
            });
        private static readonly IEnumerable<Convention> _applicableConventions = new Convention[] { Convention.Precision };

        public ISet<Contract> ApplicableContracts => _applicableContracts;
        public IEnumerable<Convention> ApplicableConventions => _applicableConventions;
        public bool IsForcing => true;

        public RevealedInfo InformationRevealed(Bid bid, BidState state)
        {
            // HCP => 16-40
            return new RevealedInfo { HCP = new List<Range>() { new Range { Min = 16, Max = 40 } } };
        }

        public bool MatchesConditions(Bid bid, BidState state)
        {
            return true;
        }
    }
}