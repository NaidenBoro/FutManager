namespace FutManager.Models
{
    public class DreamTeam
    {
        public string? Name { get; set; }
        public string? Creator { get; set; }
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
