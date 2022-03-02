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
            Clubs.Add(new Club(6, "BVB", "Bundesliga", 20));
            Clubs.Add(new Club(7, "Real Madrid", "la Liga", 20));

            return Clubs;
        }

        public static List<Player> GetPlayers()
        {
            List<Player> Players = new List<Player>();

            Players.Add(new Player( 1,
                                    "Lionel",
                                    "Messi",
                                    "Forward",
                                    34,
                                    30,
                                    GetNations().Where(nat => nat.Name == "Argentina").First().Id,
                                    GetClubs().Where(c => c.Name == "PSG").First().Id,
                                    93,
                                    true));
            Players.Add(new Player( 2,
                                    "Cristiano",
                                    "Ronaldo",
                                    "Forward",
                                    37,
                                    7,
                                    GetNations().Where(nat => nat.Name == "Portugal").First().Id,
                                    GetClubs().Where(c => c.Name == "Manchester United").First().Id,
                                    91,
                                    true));
            Players.Add(new Player( 3,
                                    "Neymar",
                                    "Jr",
                                    "Forward",
                                    30,
                                    10,
                                    GetNations().Where(nat => nat.Name == "Brazil").First().Id,
                                    GetClubs().Where(c => c.Name == "PSG").First().Id,
                                    91,
                                    true));
            Players.Add(new Player( 4,
                                    "Kylian",
                                    "Mbappe",
                                    "Forward",
                                    23,
                                    7,
                                    GetNations().Where(nat => nat.Name == "France").First().Id,
                                    GetClubs().Where(c => c.Name == "PSG").First().Id,
                                    91,
                                    true));
            Players.Add(new Player( 5,
                                    "Erling",
                                    "Haaland",
                                    "Forward",
                                    21,
                                    9,
                                    GetNations().Where(nat => nat.Name == "Norway").First().Id,
                                    GetClubs().Where(c => c.Name == "BVB").First().Id,
                                    88,
                                    true));
            Players.Add(new Player( 6,
                                    "Viksata",
                                    "Georgiev",
                                    "Forward",
                                    17,
                                    11,
                                    GetNations().Where(nat => nat.Name == "Bulgaria").First().Id,
                                    GetClubs().Where(c => c.Name == "Real Madrid").First().Id,
                                    99,
                                    false));

            return Players;
        }

        public static List<Manager> GetManagers()
        {
            List<Manager> Managers = new List<Manager>();

            Managers.Add(new Manager(1,
                                      "Pep",
                                      "Guardiola",
                                      51,
                                      GetNations().Where(nat => nat.Name == "Spain").First().Id,
                                      GetClubs().Where(c => c.Name == "Manchester City").First().Id,
                                      90,
                                      true));
            Managers.Add(new Manager(2,
                                      "Jose",
                                      "Mourinho",
                                      59,
                                      GetNations().Where(nat => nat.Name == "Portugal").First().Id,
                                      GetClubs().Where(c => c.Name == "Roma").First().Id,
                                      90,
                                      true));
            Managers.Add(new Manager(3,
                                      "Stoicho",
                                      "Mladenov",
                                      64,
                                      GetNations().Where(nat => nat.Name == "Bulgaria").First().Id,
                                      GetClubs().Where(c => c.Name == "CSKA").First().Id,
                                      60,
                                      true));
            Managers.Add(new Manager(4,
                                      "Ernesto",
                                      "Valverde",
                                      58,
                                      GetNations().Where(nat => nat.Name == "Spain").First().Id,
                                      GetClubs().Where(c => c.Name == "None").First().Id,
                                      80,
                                      true));
            Managers.Add(new Manager(5,
                                      "Jurgen",
                                      "Klopp",
                                      54,
                                      GetNations().Where(nat => nat.Name == "Germany").First().Id,
                                      GetClubs().Where(c => c.Name == "Liverpool").First().Id,
                                      91,
                                      true));
            Managers.Add(new Manager(6 ,
                                      "Ico",
                                      "Kanev",
                                      17,
                                      GetNations().Where(nat => nat.Name == "Bulgaria").First().Id,
                                      GetClubs().Where(c => c.Name == "Vtori otbor").First().Id,
                                      99,
                                      false));

            return Managers;
        }
    }
}
