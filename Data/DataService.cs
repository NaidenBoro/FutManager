using FutManager.Models;
using MySql.Data.MySqlClient;

namespace FutManager.Data
{
    public class DataService
    {
        private static List<Club> Clubs;
        private static List<Nation> Nations;
        private static List<Player> Players;
        private static List<Manager> Managers;
        private static List<Draft> Drafts;
        private static List<DreamTeam> DreamTeams;

        public static void Initialize()
        {
            Clubs = new List<Club>();
            

            Nations = new List<Nation>();
           //AddNation("No Nation", "No Confederation", 0);
           AddNation("Bulgaria", "UEFA", 70);
           AddNation("Italy", "UEFA", 83);
           AddNation("USA", "CONCACAF", 75);
           AddNation("Spain", "UEFA", 84);
           AddNation("Mexico", "CONCACAF", 78);
           AddNation("Brazil", "CONMEBOL", 84);
           AddNation("Argentina", "CONMEBOL", 84);
           AddNation("Brazil", "CONMEBOL", 84);
           AddNation("Canada", "CONCACAF", 73);
           AddNation( "England", "UEFA", 84);
           AddNation( "Portugal", "UEFA", 84);
           AddNation( "Belgium", "UEFA", 83);
           AddNation( "Germany", "UEFA", 83);
           AddNation( "Netherlands", "UEFA", 82);
           AddNation( "Denmark", "UEFA", 79);
           AddNation( "Poland", "UEFA", 77);
           AddNation( "Austria", "UEFA", 77);
           AddNation( "Sweden", "UEFA", 77);
           AddNation( "Czech Republic", "UEFA", 77);
           AddNation( "Norway", "UEFA", 76);
           AddNation( "France", "UEFA", 85);
           AddNation( "Ukraine", "UEFA", 76);
           AddNation( "Scotland", "UEFA", 75);
           AddNation( "Greece", "UEFA", 75);
           AddNation( "Wales", "UEFA", 74);
           AddNation( "Hungary", "UEFA", 73);
           AddNation( "Romania", "UEFA", 71);
           AddNation( "Finland", "UEFA", 71);
           AddNation( "Iceland", "UEFA", 71);
           AddNation( "Northern Ireland", "UEFA", 70);
           AddNation( "Russia", "UEFA", 75);
/*
            AddClub("No Club", "No League", 0);
            AddClub("Manchester United", "Premier League", 90);
            AddClub("Manchester City", "Premier League", 95);
            AddClub("Levski", "Efbet Liga", 20);
            AddClub("CSKA", "Efbet Liga", 20);
            AddClub("PSG", "Ligue 1", 20);
            AddClub("BVB", "Bundesliga", 20);
            AddClub("Real Madrid", "La Liga", 20);
            AddClub("Roma", "Serie A", 20);
            AddClub("Liverpool", "Premier League", 20);
            AddClub("Barcelona", "La Liga", 20);
            AddClub("Bayern Munich", "Bundesliga", 20);
            AddClub("Parva Atomna Kozlodui", "B Okrajna Vraca", 99);
            AddClub("Nice", "Ligue 1", 20);
            AddClub("Hertha BSC", "Bundesliga", 20);
            AddClub("Ajax", "Eredivisie", 20);
            AddClub("1. FC Koln", "Bundesliga", 20);*/

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
            Players.Add(new Player(29,
                                  "Vratar",
                                  "Baaland",
                                  "Goalkeeper",
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

            DreamTeams = new List<DreamTeam>();

            DreamTeams.Add(new DreamTeam(1, "Some Dream Team", "Martin", 2, 4, 8, 9, 11, 23, 6, 9));

            
        }        

        public static List<Club> GetClubs()
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();
            List<Club> clubs = new List<Club>();

            using (mySqlConnection)
            {
                string sql = "SELECT * FROM clubs";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                MySqlDataReader reader = command.ExecuteReader();

                

                while (reader.Read())
                {
                    Club club = new Club();
                    club.Id=reader.GetInt32(0);
                    club.Name=reader.GetString(1);
                    club.League=reader.GetString(2);
                    club.Rating=reader.GetInt32(3);

                    clubs.Add(club);
                }
            }
            return clubs;
            //return Clubs;
        }
        public static void AddClub(string name, string league, int rating)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "INSERT INTO clubs(name, league, rating) " +
                "VALUES (@name, @league, @rating)";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@league", league);
                command.Parameters.AddWithValue("@rating", rating);
                command.ExecuteNonQuery();
            }

        }
        public static void DeleteClub(int id)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "DELETE FROM clubs " +
                    "WHERE id = @id";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
        internal static void EditClub(int id, string name, string league, int rating)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "UPDATE clubs " +
                    "SET name = @name, league = @league, rating = @rating " +
                    "WHERE id = @id";

                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@league", league);
                command.Parameters.AddWithValue("@rating", rating);
                command.ExecuteNonQuery();
            }
        }

        public static List<Nation> GetNations()
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();
            List<Nation> nations = new List<Nation>();

            using (mySqlConnection)
            {
                string sql = "SELECT * FROM nations";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                MySqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {
                    Nation nation = new Nation();
                    nation.Id = reader.GetInt32(0);
                    nation.Name = reader.GetString(1);
                    nation.Confederation = reader.GetString(2);
                    nation.Rating = reader.GetInt32(3);

                    nations.Add(nation);
                }
            }
            return nations;
        }
        public static void AddNation(string name, string confederation, int rating)
        { 
        MySqlConnection mySqlConnection = DataBase.GetConnection();
        mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "INSERT INTO nations(name, confederation, rating) " +
                "VALUES (@name, @confederation, @rating)";
        MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
        command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@confederation", confederation);
                command.Parameters.AddWithValue("@rating", rating);
                command.ExecuteNonQuery();
            }
}
        internal static void EditNation(int id, string name, string confederation, int rating)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "UPDATE nations " +
                    "SET name = @name, confederation = @confederation, rating = @rating " +
                    "WHERE id = @id";

                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@confederation", confederation);
                command.Parameters.AddWithValue("@rating", rating);
                command.ExecuteNonQuery();
            }
        }
        public static void DeleteNation(int id)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "DELETE FROM nations " +
                    "WHERE id = @id";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
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
            Players.FirstOrDefault(x => x.Id == id).FirstName = first_name;
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
            Managers.FirstOrDefault(x => x.Id == id).FirstName = first_name;
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

        public static List<DreamTeam> GetDreamTeams()
        {
            return DreamTeams;
        }
        internal static void AddDreamTeam(string name, string creator, int GoalkeeperId, int LeftDefenderId, int RightDefenderId, int LeftMidfielderId, int RightMidfielder, int LeftForward, int RightForward, int Manager)
        {
            DreamTeams.Add(new DreamTeam(Drafts.Last().Id + 1, name, creator, GoalkeeperId, LeftDefenderId, RightDefenderId, LeftMidfielderId, RightMidfielder, LeftForward, RightForward, Manager));
        }
        internal static void DeleteDreamteam(int id)
        {
            DreamTeams.Remove(DreamTeams.FirstOrDefault(x => x.Id == id));
        }        
    }
}
