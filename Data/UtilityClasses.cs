using FutManager.Models;

namespace FutManager.Data
{
    public class PlayerAndClubsAndNations : Player
    {
        public List<Nation>? Nations;
        public List<Club>? Clubs;
        public Player? player;
    }

    public class ManagerAndClubsAndNations : Manager
    {
        public List<Nation>? Nations;
        public List<Club>? Clubs;
        internal Manager? manager;
    }

    public class DraftAndPlayersAndManager : Draft
    {
        public List<Player>? GoalKeeper;
        public List<Player>? RightDefender;
        public List<Player>? LeftDefender;
        public List<Player>? RightMidfielder;
        public List<Player>? LeftMidfielder;
        public List<Player>? RightForward;
        public List<Player>? LeftForward;
        public List<Manager>? Managers;
        public Draft? draft;
        
        public DraftAndPlayersAndManager()
        {
            GoalKeeper = new List<Player>();
            RightDefender = new List<Player>();
            LeftDefender = new List<Player>();
            RightMidfielder = new List<Player>();
            LeftMidfielder = new List<Player>();
            RightForward = new List<Player>();
            LeftForward = new List<Player>();
            Managers = new List<Manager>();
        }
    }
}
