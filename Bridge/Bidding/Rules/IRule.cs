using System.Collections.Generic;
using Bidding.Common;
using Bidding.Bidding;

namespace Bidding.Bidding.Rules
{
    public interface IRule
    {
        IEnumerable<Convention> GetConventions();
        ISet<Contract> GetApplicableContracts();
        bool MatchesConditions(Bid bid, BidState state);
        RevealedInfo InformationRevealed(Bid bid, BidState state);
    }
}