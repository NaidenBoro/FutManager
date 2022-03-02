using FutManager.Models;

namespace FutManager.Data
{
    public class DataService
    {
        public static List<Nation> GetNations()
        {
            List<Nation> Nations = new List<Nation>();
            Nations.Add(new Nation(1,"Bulgaria", "UEFA", 70));
            Nations.Add(new Nation(2,"Italy", "UEFA", 83));
            Nations.Add(new Nation(3,"USA", "CONCACAF", 75));
            Nations.Add(new Nation(4, "Spain", "UEFA", 84));
            Nations.Add(new Nation(5, "Mexico", "CONCACAF", 78));
            Nations.Add(new Nation(6, "Brazil", "CONMEBOL", 84));
            Nations.Add(new Nation(7, "Argentina", "CONMEBOL", 84));
            Nations.Add(new Nation(8, "Brazil", "CONMEBOL", 84));
            Nations.Add(new Nation(9, "Canada", "CONCACAF", 73));
            Nations.Add(new Nation(10, "England", "UEFA", 84));
            Nations.Add(new Nation(11, "Portugal", "UEFA", 84));
            Nations.Add(new Nation(12, "Belgium", "UEFA", 83));
            Nations.Add(new Nation(13, "Germany", "UEFA", 83));
            Nations.Add(new Nation(14, "Netherlands", "UEFA", 82));
            Nations.Add(new Nation(15, "Denmark", "UEFA", 79));
            Nations.Add(new Nation(16, "Poland", "UEFA", 77));
            Nations.Add(new Nation(17, "Austria", "UEFA", 77));
            Nations.Add(new Nation(18, "Sweden", "UEFA", 77));
            Nations.Add(new Nation(19, "Czech Republic", "UEFA", 77));
            Nations.Add(new Nation(20, "Norway", "UEFA", 76));
            Nations.Add(new Nation(21, "France", "UEFA", 85));
            Nations.Add(new Nation(22, "Ukraine", "UEFA", 76));
            Nations.Add(new Nation(23, "Scotland", "UEFA", 75));
            Nations.Add(new Nation(24, "Greece", "UEFA", 75));
            Nations.Add(new Nation(25, "Wales", "UEFA", 74));
            Nations.Add(new Nation(26, "Hungary", "UEFA", 73));
            Nations.Add(new Nation(27, "Romania", "UEFA", 71));
            Nations.Add(new Nation(28, "Finland", "UEFA", 71));
            Nations.Add(new Nation(29, "Iceland", "UEFA", 71));
            Nations.Add(new Nation(30, "Northern Ireland", "UEFA", 70));
            Nations.Add(new Nation(31, "Russia", "UEFA", 75));
            return Nations;
        }

        public static List<Club> GetClubs()
        {
            List<Club> Clubs = new List<Club>();
            Clubs.Add(new Club(1,"Manchester United", "Premire League", 90));
            Clubs.Add(new Club(2,"Manchester City", "Premire League", 95));
            Clubs.Add(new Club(3,"Levski", "Efbet Liga", 20));
            Clubs.Add(new Club(4,"CSKA", "Efbet Liga", 20));
            Clubs.Add(new Club(5, "PSG", "Ligue 1", 20));
            Clubs.Add(new Club(5, "BVB", "Bundesliga", 20));

            return Clubs;
        }
    }
}
