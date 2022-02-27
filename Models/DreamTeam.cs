namespace FutManager.Models
{
    public class DreamTeam
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        public Player? Goalkeeper { get; set; }
        public Player? LeftDefender { get; set; }
        public Player? RightDefender { get; set; }
        public Player? LeftMidfielder { get; set; }
        public Player? RightMidfielder { get; set; }
        public Player? LeftForward { get; set; }
        public Player? RightForward { get; set; }
        public Manager? Manager { get; set; }

        public DreamTeam(string name, string creator, Player goalk, Player LDef, Player RDef, Player LMid, Player RMid, Player LForw, Player RForw, Manager manager)
        {
            Name = name;
            Creator = creator;
            Goalkeeper = goalk;
            LeftDefender = LDef;
            RightDefender = RDef;
            LeftMidfielder = LMid;
            RightMidfielder = RMid;
            LeftForward = LForw;
            RightForward = RForw;
            Manager = manager;
        }

        public DreamTeam()
        {
            Name = "Uknown";
            Creator = "Unknwon";

        }
    }
}
