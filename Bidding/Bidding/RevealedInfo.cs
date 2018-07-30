using System.Collections.Generic;
using Bidding.Common;

namespace Bidding.Bidding
{
    public class RevealedInfo
    {
        public Position Position { get; set; }
        public IEnumerable<Range> HCP { get; set; }
        public IEnumerable<Range> TotalPoints { get; set; }
        public int MinClubs { get; set; } = 0;
        public int MaxClubs { get; set; } = 13;
        public int MinDiamonds { get; set; } = 0;
        public int MaxDiamonds { get; set; } = 13;
        public int MinHearts { get; set; } = 0;
        public int MaxHearts { get; set; } = 13;
        public int MinSpades { get; set; } = 0;
        public int MaxSpades { get; set; } = 13;

        public void MinSuit(Suit suit, int value) => Reflect($"Min{suit}s", value);
        public void MaxSuit(Suit suit, int value) => Reflect($"Max{suit}s", value);
        public void ExactSuit(Suit suit, int value)
        {
            Reflect($"Min{suit}s", value);
            Reflect($"Max{suit}s", value);
        }
        public void MinAllSuits(int value) => ReflectAll("Min", value);
        public void MaxAllSuits(int value) => ReflectAll("Max", value);

        private void Reflect(string propertyName, int value) => typeof(RevealedInfo).GetProperty(propertyName).SetValue(this, value);
        private void ReflectAll(string propertyPrefix, int value)
        {
            foreach (var p in typeof(RevealedInfo).GetProperties())
            {
                if (p.Name.StartsWith(propertyPrefix))
                {
                    p.SetValue(this, value);
                }
            }
        }
    }
}