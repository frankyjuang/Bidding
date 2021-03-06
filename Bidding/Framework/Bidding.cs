using EnumsNET;
using System.Collections.Generic;
using System.Linq;
using Bidding.Common;

namespace Bidding.Framework
{
    public class Bidding
    {
        private readonly List<Contract> _contracts = new List<Contract>();
        private List<Contract> _history = new List<Contract>();

        public Bidding()
        {
            foreach (var level in Enums.GetValues<Level>())
            {
                foreach (var suit in Enums.GetValues<Suit>())
                {
                    _contracts.Add(new Contract(level, suit));
                }
            }
        }

        public bool Bid(Contract contract)
        {
            if (!_history.Any() || contract > _history.Last())
            {
                _history.Add(contract);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return string.Join(" ", _history);
        }
    }
}