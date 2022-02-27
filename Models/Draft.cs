namespace FutManager.Models
{
    public class Draft
    {
        public string? Creator { get; set; }
        //Type - 1 for only real playes, 2 for only fake players, 3 with both fake and real
        public int Type { get; set; }
        public Player? Goalkeeper { get; set; }
        public Player? LeftDefender { get; set; }
        public Player? RightDefender { get; set; }
        public Player? LeftMidfielder { get; set; }
        public Player? RightMidfielder { get; set; }
        public Player? LeftForward { get; set; }
        public Player? RightForward { get; set; }
        public Manager? Manager { get; set; }

    }
}
