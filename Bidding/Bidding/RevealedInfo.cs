namespace Bidding.Bidding
{
    public class RevealedInfo
    {
        public Position position { get; set; }
        public int minPoints { get; set; } = 0;
        public int maxPoints { get; set; } = 40;
        public int minClubs { get; set; } = 0;
        public int maxClubs { get; set; } = 13;
        public int minDiamonds { get; set; } = 0;
        public int maxDiamonds { get; set; } = 13;
        public int minHearts { get; set; } = 0;
        public int maxHearts { get; set; } = 13;
        public int minSpades { get; set; } = 0;
        public int maxSpades { get; set; } = 13;
        public string Note { get; set; }
    }
}