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
    }
}
