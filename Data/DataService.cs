using FutManager.Models;
using MySql.Data.MySqlClient;

namespace FutManager.Data
{
    public class DataService
    {
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
        public static void EditClub(int id, string name, string league, int rating)
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
                string sql1 = "SELECT * FROM nations";
                MySqlCommand command1 = new MySqlCommand(sql1, mySqlConnection);
                MySqlDataReader reader = command1.ExecuteReader();



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
                string sql1 = "INSERT INTO nations(name, confederation, rating) " +
                                "VALUES (@name, @confederation, @rating)";
                MySqlCommand command1 = new MySqlCommand(sql1, mySqlConnection);
                command1.Parameters.AddWithValue("@name", name);
                command1.Parameters.AddWithValue("@confederation", confederation);
                command1.Parameters.AddWithValue("@rating", rating);
                command1.ExecuteNonQuery();
            }
}
        public static void EditNation(int id, string name, string confederation, int rating)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql1 = "UPDATE nations " +
                                "SET name = @name, confederation = @confederation, rating = @rating " +
                                "WHERE id = @id";

                MySqlCommand command1 = new MySqlCommand(sql1, mySqlConnection);
                command1.Parameters.AddWithValue("@id", id);
                command1.Parameters.AddWithValue("@name", name);
                command1.Parameters.AddWithValue("@confederation", confederation);
                command1.Parameters.AddWithValue("@rating", rating);
                command1.ExecuteNonQuery();
            }
        }
        public static void DeleteNation(int id)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql1 = "DELETE FROM nations " +
                                "WHERE id = @id";
                MySqlCommand command1 = new MySqlCommand(sql1, mySqlConnection);
                command1.Parameters.AddWithValue("@id", id);
                command1.ExecuteNonQuery();
            }
        }

        public static List<Player> GetPlayers()
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();
            List<Player> players = new List<Player>();

            using (mySqlConnection)
            {
                string sql = "SELECT * FROM players";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                MySqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {
                    Player player = new Player();
                    player.Id = reader.GetInt32(0);
                    player.FirstName = reader.GetString(1);
                    player.LastName = reader.GetString(2);
                    player.Position = reader.GetString(3);
                    player.Age = reader.GetInt32(4);
                    player.ShirtNumber = reader.GetInt32(5);
                    player.NationalityId = reader.GetInt32(6);
                    player.ClubId = reader.GetInt32(7);
                    player.Overall = reader.GetInt32(8);
                    player.isReal = reader.GetBoolean(9);

                    players.Add(player);
                }
            }

            return players;
            //return Players;
        }
        public static void AddPlayer(string first_name, string last_name, string position, int age, int shirt_number, int nationality_id, int club_id, int overall, bool is_real)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "INSERT INTO players(first_name, last_name, position, age, shirt_number, nationality_id, club_id, overall, is_real) " +
                                "VALUES (@first_name, @last_name, @position, @age, @shirt_number, @nationality_id, @club_id, @overall, @is_real)";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@first_name", first_name);
                command.Parameters.AddWithValue("@last_name", last_name);
                command.Parameters.AddWithValue("@position", position);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@shirt_number", shirt_number);
                command.Parameters.AddWithValue("@nationality_id", nationality_id);
                command.Parameters.AddWithValue("@club_id", club_id);
                command.Parameters.AddWithValue("@overall", overall);
                command.Parameters.AddWithValue("@is_real", is_real);
                command.ExecuteNonQuery();
            }
        }
        public static void DeletePlayer(int id)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "DELETE FROM players " +
                                "WHERE id = @id";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
        public static void EditPlayer(int id, string first_name, string last_name, string position, int nationality_id, int club_id, int age, int shirt_number, int overall, bool is_real)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {

                string sql = "UPDATE players " +
                                "SET first_name = @first_name, last_name = @last_name, position = @position, age = @age, shirt_number = @shirt_number, nationality_id = @nationality_id, club_id = @club_id, overall = @overall, is_real = @is_real " +
                                "WHERE id = @id";

                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@first_name", first_name);
                command.Parameters.AddWithValue("@last_name", last_name);
                command.Parameters.AddWithValue("@position", position);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@shirt_number", shirt_number);
                command.Parameters.AddWithValue("@nationality_id", nationality_id);
                command.Parameters.AddWithValue("@club_id", club_id);
                command.Parameters.AddWithValue("@overall", overall);
                command.Parameters.AddWithValue("@is_real", is_real);
                command.ExecuteNonQuery();
            }

        }

        public static List<Manager> GetManagers()
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();
            List<Manager> managers = new List<Manager>();

            using (mySqlConnection)
            {
                string sql = "SELECT * FROM managers";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Manager manager = new Manager();
                    manager.Id = reader.GetInt32(0);
                    manager.FirstName = reader.GetString(1);
                    manager.LastName = reader.GetString(2);
                    manager.Age = reader.GetInt32(3);
                    manager.NationalityId = reader.GetInt32(4);
                    manager.ClubId = reader.GetInt32(5);
                    manager.Rating = reader.GetInt32(6);
                    manager.isReal = reader.GetBoolean(7);

                    managers.Add(manager);
                }
            }

            return managers;
        }
        public static void AddManager(string first_name, string last_name, int age, int nationality_id, int club_id, int rating, bool is_real)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "INSERT INTO managers(first_name, last_name, age, nationality_id, club_id, rating, is_real) " +
                                "VALUES (@first_name, @last_name, @age, @nationality_id, @club_id, @rating, @is_real)";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@first_name", first_name);
                command.Parameters.AddWithValue("@last_name", last_name);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@nationality_id", nationality_id);
                command.Parameters.AddWithValue("@club_id", club_id);
                command.Parameters.AddWithValue("@rating", rating);
                command.Parameters.AddWithValue("@is_real", is_real);
                command.ExecuteNonQuery();
            }
        }
        public static void DeleteManager(int id)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "DELETE FROM managers " +
                                "WHERE id = @id";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
        public static void EditManager(int id, string first_name, string last_name, int nationality_id, int club_id, int age, int rating, bool is_real)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {

                string sql = "UPDATE managers " +
                                "SET first_name = @first_name, last_name = @last_name, age = @age, nationality_id = @nationality_id, club_id = @club_id, rating = @rating, is_real = @is_real " +
                                "WHERE id = @id";

                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@first_name", first_name);
                command.Parameters.AddWithValue("@last_name", last_name);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@nationality_id", nationality_id);
                command.Parameters.AddWithValue("@club_id", club_id);
                command.Parameters.AddWithValue("@rating", rating);
                command.Parameters.AddWithValue("@is_real", is_real);
                command.ExecuteNonQuery();
            }

        }

        public static List<Draft> GetDrafts()
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();
            List<Draft> drafts = new List<Draft>();

            using (mySqlConnection)
            {
                string sql = "SELECT * FROM drafts";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Draft draft = new Draft();
                    draft.Id = reader.GetInt32(0);
                    draft.Name = reader.GetString(1);
                    draft.Creator = reader.GetString(2);
                    draft.GoalkeeperId = reader.GetInt32(3);
                    draft.LeftDefenderId = reader.GetInt32(4);
                    draft.RightDefenderId = reader.GetInt32(5);
                    draft.LeftMidfielderId = reader.GetInt32(6);
                    draft.RightMidfielderId = reader.GetInt32(7);
                    draft.LeftForwardId = reader.GetInt32(8);
                    draft.RightForwardId = reader.GetInt32(9);
                    draft.ManagerId = reader.GetInt32(10);

                    drafts.Add(draft);
                }
            }

            return drafts;
        }
        public static void AddDraft(string name, string creator, int GoalkeeperId, int LeftDefenderId, int RightDefenderId, int LeftMidfielderId, int RightMidfielderId, int LeftForwardId, int RightForwardId, int ManagerId)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "INSERT INTO drafts(name, creator, goalkeeper_id, leftdefender_id, rightdefender_id, leftmidfielder_id,rightmidfielder_id, leftforward_id,rightforward_id,manager_id) " +
                                "VALUES (@name, @creator, @goalkeeper_id, @leftdefender_id, @rightdefender_id, @leftmidfielder_id,@rightmidfielder_id, @leftforward_id,@rightforward_id,@manager_id)";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@creator", creator);
                command.Parameters.AddWithValue("@goalkeeper_id", GoalkeeperId);
                command.Parameters.AddWithValue("@leftdefender_id", LeftDefenderId);
                command.Parameters.AddWithValue("@rightdefender_id", RightDefenderId);
                command.Parameters.AddWithValue("@leftmidfielder_id", LeftMidfielderId);
                command.Parameters.AddWithValue("@rightmidfielder_id", RightMidfielderId);
                command.Parameters.AddWithValue("@leftforward_id", LeftForwardId);
                command.Parameters.AddWithValue("@rightforward_id", RightForwardId);
                command.Parameters.AddWithValue("@manager_id", ManagerId);
                command.ExecuteNonQuery();
            }
        }
        public static void DeleteDraft(int id)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "DELETE FROM drafts " +
                                "WHERE id = @id";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        public static List<DreamTeam> GetDreamTeams()
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();
            List<DreamTeam> dreamTeams = new List<DreamTeam>();

            using (mySqlConnection)
            {
                string sql = "SELECT * FROM dreamteams";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DreamTeam dreamTeam = new DreamTeam();
                    dreamTeam.Id = reader.GetInt32(0);
                    dreamTeam.Name = reader.GetString(1);
                    dreamTeam.Creator = reader.GetString(2);
                    dreamTeam.GoalkeeperId = reader.GetInt32(3);
                    dreamTeam.LeftDefenderId = reader.GetInt32(4);
                    dreamTeam.RightDefenderId = reader.GetInt32(5);
                    dreamTeam.LeftMidfielderId = reader.GetInt32(6);
                    dreamTeam.RightMidfielderId = reader.GetInt32(7);
                    dreamTeam.LeftForwardId = reader.GetInt32(8);
                    dreamTeam.RightForwardId = reader.GetInt32(9);
                    dreamTeam.ManagerId = reader.GetInt32(10);

                    dreamTeams.Add(dreamTeam);
                }
            }

            return dreamTeams;
        }
        public static void AddDreamTeam(string name, string creator, int GoalkeeperId, int LeftDefenderId, int RightDefenderId, int LeftMidfielderId, int RightMidfielderId, int LeftForwardId, int RightForwardId, int ManagerId)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "INSERT INTO dreamteams(name, creator, goalkeeper_id, leftdefender_id, rightdefender_id, leftmidfielder_id,rightmidfielder_id, leftforward_id,rightforward_id,manager_id) " +
                                "VALUES (@name, @creator, @goalkeeper_id, @leftdefender_id, @rightdefender_id, @leftmidfielder_id,@rightmidfielder_id, @leftforward_id,@rightforward_id,@manager_id)";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@creator", creator);
                command.Parameters.AddWithValue("@goalkeeper_id", GoalkeeperId);
                command.Parameters.AddWithValue("@leftdefender_id", LeftDefenderId);
                command.Parameters.AddWithValue("@rightdefender_id", RightDefenderId);
                command.Parameters.AddWithValue("@leftmidfielder_id", LeftMidfielderId);
                command.Parameters.AddWithValue("@rightmidfielder_id", RightMidfielderId);
                command.Parameters.AddWithValue("@leftforward_id", LeftForwardId);
                command.Parameters.AddWithValue("@rightforward_id", RightForwardId);
                command.Parameters.AddWithValue("@manager_id", ManagerId);
                command.ExecuteNonQuery();
            }
        }
        public static void DeleteDreamTeam(int id)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "DELETE FROM dreamteams " +
                                "WHERE id = @id";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        public static void EditDreamTeam(int id, string name, string creator, int GoalkeeperId, int LeftDefenderId, int RightDefenderId, int LeftMidfielderId, int RightMidfielderId, int LeftForwardId, int RightForwardId, int ManagerId)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "UPDATE dreamteams " +
                                "SET name = @name, creator = @creator, goalkeeper_id = @goalkeeper_id, leftdefender_id = @leftdefender_id, rightdefender_id = @rightdefender_id, leftmidfielder_id = @leftmidfielder_id, rightmidfielder_id = @rightmidfielder_id, leftforward_id = @leftforward_id,rightforward_id = @rightforward_id,manager_id = @manager_id " +
                                "WHERE id = @id";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@creator", creator);
                command.Parameters.AddWithValue("@goalkeeper_id", GoalkeeperId);
                command.Parameters.AddWithValue("@leftdefender_id", LeftDefenderId);
                command.Parameters.AddWithValue("@rightdefender_id", RightDefenderId);
                command.Parameters.AddWithValue("@leftmidfielder_id", LeftMidfielderId);
                command.Parameters.AddWithValue("@rightmidfielder_id", RightMidfielderId);
                command.Parameters.AddWithValue("@leftforward_id", LeftForwardId);
                command.Parameters.AddWithValue("@rightforward_id", RightForwardId);
                command.Parameters.AddWithValue("@manager_id", ManagerId);
                command.ExecuteNonQuery();
            }
        }

    }
}
