using FutManager.Models;

namespace FutManager.Data
{
    public class DataService
    {
        private static List<Club> Clubs;
        private static List<Nation> Nations;
        private static List<Player> Players;
        private static List<Manager> Managers;
        private static List<Draft> Drafts;

        public static void Initialize()
        {
            Clubs = new List<Club>();
            Clubs.Add(new Club(0, "No Club", "No League", 0));
            Clubs.Add(new Club(1, "Manchester United", "Premier League", 90));
            Clubs.Add(new Club(2, "Manchester City", "Premier League", 95));
            Clubs.Add(new Club(3, "Levski", "Efbet Liga", 20));
            Clubs.Add(new Club(4, "CSKA", "Efbet Liga", 20));
            Clubs.Add(new Club(5, "PSG", "Ligue 1", 20));
            Clubs.Add(new Club(6, "BVB", "Bundesliga", 20));
            Clubs.Add(new Club(7, "Real Madrid", "La Liga", 20));
            Clubs.Add(new Club(8, "Roma", "Serie A", 20));
            Clubs.Add(new Club(9, "Liverpool", "Premier League", 20));
            Clubs.Add(new Club(10, "Barcelona", "La Liga", 20));
            Clubs.Add(new Club(11, "Bayern Munich", "Bundesliga", 20));
            Clubs.Add(new Club(12, "Parva Atomna Kozlodui", "B Okrajna Vraca", 99));
            Clubs.Add(new Club(13, "Nice", "Ligue 1", 20));
            Clubs.Add(new Club(14, "Hertha BSC", "Bundesliga", 20));
            Clubs.Add(new Club(15, "Ajax", "Eredivisie", 20));
            Clubs.Add(new Club(16, "1. FC Koln", "Bundesliga", 20));

            Nations = new List<Nation>();
            Nations.Add(new Nation(0, "No Nation", "No Confederation", 0));
            Nations.Add(new Nation(1, "Bulgaria", "UEFA", 70));
            Nations.Add(new Nation(2, "Italy", "UEFA", 83));
            Nations.Add(new Nation(3, "USA", "CONCACAF", 75));
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

            Players = new List<Player>();

            Players.Add(new Player(1,
                                    "Lionel",
                                    "Messi",
                                    "Forward",
                                    34,
                                    30,
                                    GetNations().Where(nat => nat.Name == "Argentina").First().Id,
                                    GetClubs().Where(c => c.Name == "PSG").First().Id,
                                    93,
                                    true));
            Players.Add(new Player(2,
                                    "Cristiano",
                                    "Ronaldo",
                                    "Forward",
                                    37,
                                    7,
                                    GetNations().Where(nat => nat.Name == "Portugal").First().Id,
                                    GetClubs().Where(c => c.Name == "Manchester United").First().Id,
                                    91,
                                    true));
            Players.Add(new Player(3,
                                    "Neymar",
                                    "Jr",
                                    "Forward",
                                    30,
                                    10,
                                    GetNations().Where(nat => nat.Name == "Brazil").First().Id,
                                    GetClubs().Where(c => c.Name == "PSG").First().Id,
                                    91,
                                    true));
            Players.Add(new Player(4,
                                    "Kylian",
                                    "Mbappe",
                                    "Forward",
                                    23,
                                    7,
                                    GetNations().Where(nat => nat.Name == "France").First().Id,
                                    GetClubs().Where(c => c.Name == "PSG").First().Id,
                                    91,
                                    true));
            Players.Add(new Player(5,
                                    "Erling",
                                    "Haaland",
                                    "Forward",
                                    21,
                                    9,
                                    GetNations().Where(nat => nat.Name == "Norway").First().Id,
                                    GetClubs().Where(c => c.Name == "BVB").First().Id,
                                    88,
                                    true));
            Players.Add(new Player(6,
                                    "Viksata",
                                    "Georgiev",
                                    "Forward",
                                    17,
                                    11,
                                    GetNations().Where(nat => nat.Name == "Bulgaria").First().Id,
                                    GetClubs().Where(c => c.Name == "Real Madrid").First().Id,
                                    99,
                                    false));
            Players.Add(new Player(7,
                                    "Virgil",
                                    "van Dijk",
                                    "Defender",
                                    30,
                                    4,
                                    GetNations().Where(nat => nat.Name == "Netherlands").First().Id,
                                    GetClubs().Where(c => c.Name == "Liverpool").First().Id,
                                    89,
                                    true));
            Players.Add(new Player(8,
                                    "Pedri",
                                    "Gonzalez",
                                    "Midfielder",
                                    19,
                                    16,
                                    GetNations().Where(nat => nat.Name == "Spain").First().Id,
                                    GetClubs().Where(c => c.Name == "Barcelona").First().Id,
                                    81,
                                    true));
            Players.Add(new Player(9,
                                    "Pablo",
                                    "Gavi",
                                    "Midfielder",
                                    17,
                                    30,
                                    GetNations().Where(nat => nat.Name == "Spain").First().Id,
                                    GetClubs().Where(c => c.Name == "Barcelona").First().Id,
                                    74,
                                    true));
            Players.Add(new Player(10,
                                    "Jadon",
                                    "Sancho",
                                    "Midfielder",
                                    21,
                                    25,
                                    GetNations().Where(nat => nat.Name == "England").First().Id,
                                    GetClubs().Where(c => c.Name == "Barcelona").First().Id,
                                    87,
                                    true));
            Players.Add(new Player(11,
                                    "Jude",
                                    "Bellingham",
                                    "Midfielder",
                                    18,
                                    22,
                                    GetNations().Where(nat => nat.Name == "England").First().Id,
                                    GetClubs().Where(c => c.Name == "BVB").First().Id,
                                    81,
                                    true));
            Players.Add(new Player(12,
                                    "Maestro",
                                    "Kimpembe",
                                    "Defender",
                                    26,
                                    3,
                                    GetNations().Where(nat => nat.Name == "France").First().Id,
                                    GetClubs().Where(c => c.Name == "PSG").First().Id,
                                    83,
                                    true));
            Players.Add(new Player(13,
                                   "Bude",
                                   "Jellingham2",
                                   "Midfielder",
                                   18,
                                   22,
                                   GetNations().Where(nat => nat.Name == "England").First().Id,
                                   GetClubs().Where(c => c.Name == "BVB").First().Id,
                                   81,
                                   true));

            Players.Add(new Player(14,
                                    "Roberto",
                                    "Firmino",
                                    "Defender",
                                    37,
                                    6,
                                    GetNations().Where(nat => nat.Name == "Brazil").First().Id,
                                    GetClubs().Where(c => c.Name == "Liverpool").First().Id,
                                    85,
                                    true));

            Players.Add(new Player(15,
                                   "Axel",
                                   "Witsel",
                                   "Midfielder",
                                   33,
                                   28,
                                   GetNations().Where(nat => nat.Name == "Belgium").First().Id,
                                   GetClubs().Where(c => c.Name == "BVB").First().Id,
                                   83,
                                   true));
            Players.Add(new Player(16,
                                   "Ico",
                                   "Kotva",
                                   "Midfielder",
                                   33,
                                   28,
                                   GetNations().Where(nat => nat.Name == "Belgium").First().Id,
                                   GetClubs().Where(c => c.Name == "BVB").First().Id,
                                   83,
                                   true));
            Players.Add(new Player(17,
                                   "Perling",
                                   "Paaland",
                                   "Forward",
                                   21,
                                   9,
                                   GetNations().Where(nat => nat.Name == "Norway").First().Id,
                                   GetClubs().Where(c => c.Name == "BVB").First().Id,
                                   88,
                                   true));
            Players.Add(new Player(18,
                                   "Terling",
                                   "Taaland",
                                   "Forward",
                                   21,
                                   9,
                                   GetNations().Where(nat => nat.Name == "Norway").First().Id,
                                   GetClubs().Where(c => c.Name == "BVB").First().Id,
                                   88,
                                   true));
            Players.Add(new Player(19,
                                   "Kerling",
                                   "Kaaland",
                                   "Forward",
                                   21,
                                   9,
                                   GetNations().Where(nat => nat.Name == "Norway").First().Id,
                                   GetClubs().Where(c => c.Name == "BVB").First().Id,
                                   88,
                                   true));

            Players.Add(new Player(20,
                                   "Serling",
                                   "Saaland",
                                   "Forward",
                                   21,
                                   9,
                                   GetNations().Where(nat => nat.Name == "Norway").First().Id,
                                   GetClubs().Where(c => c.Name == "BVB").First().Id,
                                   88,
                                   true));

            Players.Add(new Player(21,
                                   "Ferling",
                                   "Faaland",
                                   "Forward",
                                   21,
                                   9,
                                   GetNations().Where(nat => nat.Name == "Norway").First().Id,
                                   GetClubs().Where(c => c.Name == "BVB").First().Id,
                                   88,
                                   true));

            Players.Add(new Player(22,
                                   "Werling",
                                   "Waaland",
                                   "Forward",
                                   21,
                                   9,
                                   GetNations().Where(nat => nat.Name == "Norway").First().Id,
                                   GetClubs().Where(c => c.Name == "BVB").First().Id,
                                   88,
                                   true));

            Players.Add(new Player(23,
                                   "Rerling",
                                   "Raaland",
                                   "Forward",
                                   21,
                                   9,
                                   GetNations().Where(nat => nat.Name == "Norway").First().Id,
                                   GetClubs().Where(c => c.Name == "BVB").First().Id,
                                   88,
                                   true));
            Players.Add(new Player(24,
                                  "Lerling",
                                  "Laaland",
                                  "Forward",
                                  21,
                                  9,
                                  GetNations().Where(nat => nat.Name == "Norway").First().Id,
                                  GetClubs().Where(c => c.Name == "BVB").First().Id,
                                  88,
                                  true));
            Players.Add(new Player(25,
                                  "Gerling",
                                  "Gaaland",
                                  "Forward",
                                  21,
                                  9,
                                  GetNations().Where(nat => nat.Name == "Norway").First().Id,
                                  GetClubs().Where(c => c.Name == "BVB").First().Id,
                                  88,
                                  true));
            Players.Add(new Player(26,
                                  "Nerling",
                                  "Naaland",
                                  "Forward",
                                  21,
                                  9,
                                  GetNations().Where(nat => nat.Name == "Norway").First().Id,
                                  GetClubs().Where(c => c.Name == "BVB").First().Id,
                                  88,
                                  true));
            Players.Add(new Player(27,
                                  "Derling",
                                  "Daaland",
                                  "Forward",
                                  21,
                                  9,
                                  GetNations().Where(nat => nat.Name == "Norway").First().Id,
                                  GetClubs().Where(c => c.Name == "BVB").First().Id,
                                  88,
                                  true));
            Players.Add(new Player(28,
                                  "Berling",
                                  "Baaland",
                                  "Forward",
                                  21,
                                  9,
                                  GetNations().Where(nat => nat.Name == "Norway").First().Id,
                                  GetClubs().Where(c => c.Name == "BVB").First().Id,
                                  88,
                                  true));

            Managers = new List<Manager>();

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
                                      GetClubs().Where(c => c.Name == "Levski").First().Id,
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
            Managers.Add(new Manager(6,
                                      "Ico",
                                      "Kanev",
                                      17,
                                      GetNations().Where(nat => nat.Name == "Bulgaria").First().Id,
                                      GetClubs().Where(c => c.Name == "Real Madrid").First().Id,
                                      99,
                                      false));
            Managers.Add(new Manager(7,
                                      "Xavi",
                                      "Hernandez",
                                      42,
                                      GetNations().Where(nat => nat.Name == "Spain").First().Id,
                                      GetClubs().Where(c => c.Name == "Barcelona").First().Id,
                                      88,
                                      true));
            Managers.Add(new Manager(8,
                                      "Julian",
                                      "Nagelsmann",
                                      34,
                                      GetNations().Where(nat => nat.Name == "Germany").First().Id,
                                      GetClubs().Where(c => c.Name == "Bayern Munich").First().Id,
                                      88,
                                      true));
            Managers.Add(new Manager(9,
                                      "Edin",
                                      "Terzic",
                                      39,
                                      GetNations().Where(nat => nat.Name == "Germany").First().Id,
                                      GetClubs().Where(c => c.Name == "BVB").First().Id,
                                      88,
                                      true));
            Drafts = new List<Draft>();

            Drafts.Add(new Draft(1,"Some Draft", "Naiden", 1, 2, 3, 4, 5, 6, 7, 2));
        }        

        public static List<Club> GetClubs()
        {
            return Clubs;
        }
        public static void AddClub(string name, string league, int rating)
        {
            Clubs.Add(new Club(Clubs.Last().Id + 1, name, league, rating));
        }
        public static void DeleteClub(int id)
        {
            try
            {
                if (id != 0)
                {
                    while (Players.FirstOrDefault(x => x.ClubId == id) != null)
                    {
                        Players.FirstOrDefault(x => x.ClubId == id).ClubId = 0;
                    }
                    while (Managers.FirstOrDefault(x => x.ClubId == id) != null)
                    {
                        Managers.FirstOrDefault(x => x.ClubId == id).ClubId = 0;
                    }
                    Clubs.Remove(Clubs.FirstOrDefault(x => x.Id == id));
                }
                else
                {
                    throw new Exception("Cannot delete this club");
                }
            }
            catch (Exception ex)
            {

            }
        }
        internal static void EditClub(int id, string name, string league, int rating)
        {
            try
            {
                if (id != 0)
                {
                    Clubs.FirstOrDefault(x => x.Id == id).Name = name;
                    Clubs.FirstOrDefault(x => x.Id == id).League = league;
                    Clubs.FirstOrDefault(x => x.Id == id).Rating = rating;
                }
                else
                {
                    throw new Exception("Cannot edit this club");
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static List<Nation> GetNations()
        {

            return Nations;
        }
        public static void AddNation(string name, string confederation, int rating)
        {
            Nations.Add(new Nation(Nations.Last().Id + 1, name, confederation, rating));
        }
        public static void DeleteNation(int id)
        {
            try
            {
                if (id != 0)
                {
                    while (Players.FirstOrDefault(x => x.NationalityId == id) != null)
                    {
                        Players.FirstOrDefault(x => x.NationalityId == id).NationalityId = 0;
                    }
                    while (Managers.FirstOrDefault(x => x.NationalityId == id) != null)
                    {
                        Managers.FirstOrDefault(x => x.NationalityId == id).NationalityId = 0;
                    }
                    Nations.Remove(Nations.FirstOrDefault(x => x.Id == id));
                }
                else
                {
                    throw new Exception("Cannot delete this nation");
                }
            }
            catch (Exception ex)
            {

            }
        }
        internal static void EditNation(int id, string name, string confederation, int rating)
        {
            try
            {
                if (id != 0)
                {
                    Nations.FirstOrDefault(x => x.Id == id).Name = name;
                    Nations.FirstOrDefault(x => x.Id == id).Confederation = confederation;
                    Nations.FirstOrDefault(x => x.Id == id).Rating = rating;
                }
                else
                {
                    throw new Exception("Cannot edit this nation");
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static List<Player> GetPlayers()
        {
            return Players;
        }
        internal static void AddPlayer(string first_name, string last_name, string position, int age, int shirtnumber, int nationalityId, int clubId, int overall, bool isReal)
        {
            Players.Add(new Player(Players.Last().Id + 1, first_name, last_name, position, age, shirtnumber, nationalityId, clubId, overall, isReal));
        }
        internal static void DeletePlayer(int id)
        {
            Players.Remove(Players.FirstOrDefault(x => x.Id == id));
        }
        internal static void EditPlayer(int id, string first_name, string last_name, string position, int nationalityId, int clubId, int age, int shirtnumber, int overall, bool isReal)
        {
            Players.FirstOrDefault(x => x.Id == id).Age = age;
            Players.FirstOrDefault(x => x.Id == id).FisrtName = first_name;
            Players.FirstOrDefault(x => x.Id == id).LastName = last_name;
            Players.FirstOrDefault(x => x.Id == id).Position = position;
            Players.FirstOrDefault(x => x.Id == id).NationalityId = nationalityId;
            Players.FirstOrDefault(x => x.Id == id).ClubId = clubId;
            Players.FirstOrDefault(x => x.Id == id).ShirtNumber = shirtnumber;
            Players.FirstOrDefault(x => x.Id == id).Overall = overall;
            Players.FirstOrDefault(x => x.Id == id).isReal = isReal;

        }

        public static List<Manager> GetManagers()
        {

            return Managers;
        }
        internal static void AddManager(string first_name, string last_name, int age, int nationalityId, int clubId, int rating, bool isReal)
        {
            Managers.Add(new Manager(Managers.Last().Id + 1, first_name, last_name, age, nationalityId, clubId, rating, isReal));
        }
        internal static void DeleteManager(int id)
        {
            Managers.Remove(Managers.FirstOrDefault(x => x.Id == id));
        }
        internal static void EditManager(int id, string first_name, string last_name, int nationalityId, int clubId, int age, int rating, bool isReal)
        {
            Managers.FirstOrDefault(x => x.Id == id).Age = age;
            Managers.FirstOrDefault(x => x.Id == id).FisrtName = first_name;
            Managers.FirstOrDefault(x => x.Id == id).LastName = last_name;
            Managers.FirstOrDefault(x => x.Id == id).NationalityId = nationalityId;
            Managers.FirstOrDefault(x => x.Id == id).ClubId = clubId;
            Managers.FirstOrDefault(x => x.Id == id).Rating = rating;
            Managers.FirstOrDefault(x => x.Id == id).isReal = isReal;

        }

        public static List<Draft> GetDrafts()
        {
            return Drafts;
        }
        internal static void AddDraft(string name, string creator, int GoalkeeperId, int LeftDefenderId, int RightDefenderId, int LeftMidfielderId, int RightMidfielder, int LeftForward, int RightForward, int Manager)
        {
            Drafts.Add(new Draft(Drafts.Last().Id + 1, name, creator, GoalkeeperId, LeftDefenderId, RightDefenderId, LeftMidfielderId, RightMidfielder, LeftForward, RightForward, Manager));
        }
        internal static void DeleteDraft(int id)
        {
            Drafts.Remove(Drafts.FirstOrDefault(x => x.Id == id));
        }
    }
}
