using System;
using System.Collections.Generic;
using Bidding.Common;

namespace Bidding.Bidding.Rules
{
    public class Natural : IRule
    {
        public ISet<Contract> GetApplicableContracts()
        {
            HashSet<Contract> applicableContracts = new HashSet<Contract>();
            foreach (Level level in Enum.GetValues(typeof(Level)))
            {
                foreach(Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    applicableContracts.Add(new Contract(level, suit));
                }
                applicableContracts.Add(new Contract(level, null));
            }
            return applicableContracts;
        }

        public IEnumerable<Convention> GetConventions()
        {
            return new List<Convention> { Convention.Precision };
        }

        public RevealedInfo InformationRevealed(Bid bid, BidState state)
        {
            throw new System.NotImplementedException();
        }

        public bool MatchesConditions(Bid bid, BidState state)
        {
            throw new System.NotImplementedException();
        }
    }
}