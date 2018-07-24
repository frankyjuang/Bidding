namespace Bidding.Bidding
{
    public class RevealedInfo
    {
        public Position Position { get; set; }
        public int MinHCP { get; set; } = 0;
        public int MaxHCP { get; set; } = 40;
        public int MinTotalPoints { get; set; } = 0;
        public int MaxTotalPoints { get; set; } = 40;
        public int MinClubs { get; set; } = 0;
        public int MaxClubs { get; set; } = 13;
        public int MinDiamonds { get; set; } = 0;
        public int MaxDiamonds { get; set; } = 13;
        public int MinHearts { get; set; } = 0;
        public int MaxHearts { get; set; } = 13;
        public int MinSpades { get; set; } = 0;
        public int MaxSpades { get; set; } = 13;
    }
}