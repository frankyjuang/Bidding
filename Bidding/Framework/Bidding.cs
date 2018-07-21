using EnumsNET;
using System.Collections.Generic;

namespace Bidding.Framework
{
    public class Bidding
    {
        private readonly List<Contract> Contracts;

        public Bidding()
        {
            foreach (var level in Enums.GetValues<Level>())
            {
                foreach (var suit in Enums.GetValues<Suit>())
                {
                    Contracts.Add(new Contract { Suit = suit, Level = level });
                }
            }
        }
    }
}