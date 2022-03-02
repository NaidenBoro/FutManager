using FutManager.Models;

namespace FutManager.Data
{
    public class DataService
    {
        public static List<Nation> GetNations()
        {
            List<Nation> Nations = new List<Nation>();
            Nations.Add(new Nation(1,"Bulgaria", "UEFA", 50));
            Nations.Add(new Nation(2,"Italy", "UEFA", 100));
            Nations.Add(new Nation(3,"USA", "CONCACAF", 80));

            return Nations;
        }

        public static List<Club> GetClubs()
        {
            List<Club> Clubs = new List<Club>();
            Clubs.Add(new Club(1,"Manchester United", "Premire League", 90));
            Clubs.Add(new Club(2,"Manchester City", "Premire League", 95));
            Clubs.Add(new Club(3,"Levski", "Efbet Liga", 20));
            Clubs.Add(new Club(4,"CSKA", "Efbet Liga", 20));

            return Clubs;
        }
    }
}
