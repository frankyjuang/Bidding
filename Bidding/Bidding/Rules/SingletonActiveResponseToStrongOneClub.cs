// P.14
using System.Collections.Generic;
using System.Linq;
using Bidding.Common;
using EnumsNET;

namespace Bidding.Bidding.Rules
{
    public class SingletonActiveResponseToStrongOneClub : IRule
    {
        private static readonly HashSet<Contract> _applicableContracts = new HashSet<Contract>(
            new Contract[] {
                new Contract(Level.Two, Suit.Heart),
                new Contract(Level.Two, Suit.Spade),
                new Contract(Level.Three, Suit.Club),
                new Contract(Level.Three, Suit.Diamond)
            });
        private static readonly IEnumerable<Convention> _applicableConventions = new Convention[] { Convention.Precision };

        public ISet<Contract> ApplicableContracts => _applicableContracts;
        public IEnumerable<Convention> ApplicableConventions => _applicableConventions;
        public bool IsForcing => false;

        public RevealedInfo InformationRevealed(Bid bid, BidState state)
        {
            // HCP => 8-24, Suit => 4441
            var info = new RevealedInfo { HCP = new List<Range>() { new Range { Min = 8, Max = 24 } } };
            var singletonSuit = bid.Contract.Suit.Value.Next();
            info.ExactSuit(singletonSuit, 1);
            foreach (var suit in Enums.GetValues<Suit>().Where(s => s != singletonSuit))
            {
                info.ExactSuit(suit, 4);
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