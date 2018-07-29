using Bidding.Common;
using System;
using System.Collections.Generic;

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
            if (bid.Contract.Suit == ContractSuit.Club && bid.Contract.Level == Level.One)
            {
                return true;
            }
            return false;
        }
    }
}