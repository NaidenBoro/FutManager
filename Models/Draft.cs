namespace FutManager.Models
{
    public class Draft
    {
        public string Name { get; set; }
        public string Creator { get; set; }
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

        public Draft(string name,string creator,int type, Player goalk,Player LDef,Player RDef,Player LMid,Player RMid,Player LForw,Player RForw, Manager manager)
        {
            Name = name;
            Creator = creator;
            Type = type;
            Goalkeeper = goalk;
            LeftDefender = LDef;
            RightDefender = RDef;
            LeftMidfielder = LMid;
            RightMidfielder = RMid;
            LeftForward = LForw;
            RightForward = RForw;
            Manager = manager;

        }

        public Draft()
        {
            Name = "Unknown";
            Creator = "Unknwon";
            Type = 3;
        }

    }
}
