namespace FutManager.Models
{
    public class Draft
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        //Type - 1 for only real playes, 2 for only fake players, 3 with both fake and real
        public int Type { get; set; }
        public int GoalkeeperId { get; set; }
        public Player? Goalkeeper { get; set; }
        public int LeftDefenderId { get; set; }
        public Player? LeftDefender { get; set; }
        public int RightDefenderId { get; set; }
        public Player? RightDefender { get; set; }
        public int LeftMidfielderId { get; set; }
        public Player? LeftMidfielder { get; set; }
        public int RightMidfielderId { get; set; }
        public Player? RightMidfielder { get; set; }
        public int LeftForwardId { get; set; }
        public Player? LeftForward { get; set; }
        public int RightForwardId { get; set; }
        public Player? RightForward { get; set; }
        public int ManagerId { get; set; }
        public Manager? Manager { get; set; }

        public Draft(string name,string creator,int type, int goalk,int LDef,int RDef,int LMid,int RMid,int LForw,int RForw, int manager)
        {
            Name = name;
            Creator = creator;
            Type = type;
            GoalkeeperId = goalk;            
            LeftDefenderId = LDef;
            RightDefenderId = RDef;
            LeftMidfielderId = LMid;
            RightMidfielderId = RMid;
            LeftForwardId = LForw;
            RightForwardId = RForw;
            ManagerId = manager;

        }

        public Draft()
        {
            Name = "Unknown";
            Creator = "Unknwon";
            Type = 3;
        }

    }
}
