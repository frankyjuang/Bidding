using System;
using System.Collections.Generic;

namespace Bidding.Framework
{
    public class GamePlay
    {
        private readonly Deck _deck = new Deck();
        private List<Hand> _hands = new List<Hand>();
        private Bidding _bidding = new Bidding();

        public GamePlay()
        {
            foreach (var cards in _deck.Deal())
            {
                _hands.Add(new Hand(cards));
            }
            foreach (var hand in _hands)
            {
                Console.WriteLine(hand);
            }
        }

        public void Start()
        {
            while (true)
            {
                var rawInput = Console.ReadLine();
                if (!TryParseContract(rawInput, out var contract))
                {
                    continue;
                }
                // Console.WriteLine(contract);
                if (!_bidding.Bid(contract))
                {
                    continue;
                }
                Console.WriteLine(_bidding);
            }
        }

        private bool TryParseContract(string rawInput, out Contract contract)
        {
            contract = default(Contract);
            if (!int.TryParse(rawInput, out var bid))
            {
                return false;
            }
            if (bid / 10 < 1 || bid / 10 > 7 || bid % 10 < 1 || bid % 10 > 5)
            {
                return false;
            }
            var level = (Level)(bid / 10);
            Suit? suit = null;
            if (bid % 10 != 5)
            {
                suit = (Suit)(bid % 10);
            }
            contract = new Contract(level, suit);
            return true;
        }
    }
}