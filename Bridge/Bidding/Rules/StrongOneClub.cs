using System;
using System.Collections.Generic;
using Bidding.Common;

namespace Bidding.Bidding.Rules
{
    public class StrongOneClub : IRule
    {
        public ISet<Contract> GetApplicableContracts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Convention> GetConventions()
        {
            throw new NotImplementedException();
        }

        public RevealedInfo InformationRevealed(Bid bid, BidState state)
        {
            throw new System.NotImplementedException();
        }

        public bool MatchesConditions(Bid bid, BidState state)
        {
            if (bid.Contract.Suit == Suit.Club && bid.Contract.Level == Level.One)
            {
                return true;
            }
            return false;
        }
    }
}