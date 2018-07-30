using System.Collections.Generic;
using Bidding.Common;

namespace Bidding.Bidding.Rules
{
    public interface IRule
    {
        ISet<Contract> ApplicableContracts { get; }
        IEnumerable<Convention> ApplicableConventions { get; }
        bool IsForcing { get; }

        RevealedInfo InformationRevealed(Bid bid, BidState state);
        bool MatchesConditions(Bid bid, BidState state);
    }
}