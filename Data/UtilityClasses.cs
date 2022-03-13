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
        public List<Player>? GoalKeepers;
        public List<Player>? RightDefenders;
        public List<Player>? LeftDefenders;
        public List<Player>? RightMidfielders;
        public List<Player>? LeftMidfielders;
        public List<Player>? RightForwards;
        public List<Player>? LeftForwards;
        public List<Manager>? Managers;
        public Draft? draft;
        
        public DraftAndPlayersAndManager()
        {
            GoalKeepers = new List<Player>();
            RightDefenders = new List<Player>();
            LeftDefenders = new List<Player>();
            RightMidfielders = new List<Player>();
            LeftMidfielders = new List<Player>();
            RightForwards = new List<Player>();
            LeftForwards = new List<Player>();
            Managers = new List<Manager>();
        }
    }

    public class DreamTeamAndPlayersAndManager : DreamTeam
    {
        public List<Player>? GoalKeepers;
        public List<Player>? RightDefenders;
        public List<Player>? LeftDefenders;
        public List<Player>? RightMidfielders;
        public List<Player>? LeftMidfielders;
        public List<Player>? RightForwards;
        public List<Player>? LeftForwards;
        public List<Manager>? Managers;
        public DreamTeam? dreamTeam;

        public DreamTeamAndPlayersAndManager()
        {
            GoalKeepers = new List<Player>();
            RightDefenders = new List<Player>();
            LeftDefenders = new List<Player>();
            RightMidfielders = new List<Player>();
            LeftMidfielders = new List<Player>();
            RightForwards = new List<Player>();
            LeftForwards = new List<Player>();
            Managers = new List<Manager>();
        }
    }
}
