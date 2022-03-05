using FutManager.Models;

namespace FutManager.Data
{
    public class PlayerAndClubsAndNations : Player
    {
        public List<Nation>? Nations;
        public List<Club>? Clubs;
    }

    public class ManagerAndClubsAndNations : Manager
    {
        public List<Nation>? Nations;
        public List<Club>? Clubs;
    }
}
