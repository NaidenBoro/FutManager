using MySql.Data.MySqlClient;

namespace FutManager.Data
{
    public static class DataBase
    {
        private const string ConnectionString = "Server=localhost;Database=futManager;Uid=root;Pwd= icko2006;";
        // Mahaite parolata 

        static DataBase()
        {
            MySqlConnection connection = GetConnection();
            connection.Open();

            using (connection)
            {
                string sqlClub = "CREATE TABLE IF NOT EXISTS clubs( " +
                                    "id INT PRIMARY KEY AUTO_INCREMENT, " +
                                    "name VARCHAR(50) NOT NULL, " +
                                    "league VARCHAR(50) NOT NULL, " +
                                    "rating INT " +
                                    ")";

                MySqlCommand commandClub = new MySqlCommand(sqlClub, connection);
                commandClub.ExecuteNonQuery();
            
                string sqlNation = "CREATE TABLE IF NOT EXISTS nations( " +
                                    "id INT PRIMARY KEY AUTO_INCREMENT, " +
                                    "name VARCHAR(50) NOT NULL, " +
                                    "confederation VARCHAR(50) NOT NULL, " +
                                    "rating INT " +
                                    ")";

                MySqlCommand commandNation = new MySqlCommand(sqlNation, connection);
                commandNation.ExecuteNonQuery();

                string sqlPlayer = "CREATE TABLE IF NOT EXISTS players( " +
                                    "id INT PRIMARY KEY AUTO_INCREMENT, " +
                                    "first_name VARCHAR(50) NOT NULL, " +
                                    "last_name VARCHAR(50) NOT NULL, " +
                                    "position VARCHAR(50) NOT NULL, " +
                                    "age INT NOT NULL, " +
                                    "shirt_number INT NOT NULL, " +
                                    "nationality_id INT NOT NULL, " +
                                    "club_id INT NOT NULL, " +
                                    "overall INT, " +
                                    "is_real BOOLEAN, " +
                                    "CONSTRAINT fk_players_nations " +
                                    "FOREIGN KEY(nationality_id) REFERENCES nations(id) ON DELETE CASCADE, " +
                                    "CONSTRAINT fk_players_clubs " +
                                    "FOREIGN KEY(club_id) REFERENCES clubs(id) ON DELETE CASCADE" +
                                    ")";

                MySqlCommand commandPlayer = new MySqlCommand(sqlPlayer, connection);
                commandPlayer.ExecuteNonQuery();

                ///public Manager(int id, string fname, string lname, int age, int nat, int club, int rat, bool real)

                string sqlManager = "CREATE TABLE IF NOT EXISTS managers( " +
                                    "id INT PRIMARY KEY AUTO_INCREMENT, " +
                                    "first_name VARCHAR(50) NOT NULL, " +
                                    "last_name VARCHAR(50) NOT NULL, " +
                                    "age INT NOT NULL, " +
                                    "nationality_id INT NOT NULL, " +
                                    "club_id INT NOT NULL, " +
                                    "rating INT, " +
                                    "is_real BOOLEAN, " +
                                    "CONSTRAINT fk_managers_nations " +
                                    "FOREIGN KEY(nationality_id) REFERENCES nations(id) ON DELETE CASCADE, " +
                                    "CONSTRAINT fk_managers_clubs " +
                                    "FOREIGN KEY(club_id) REFERENCES clubs(id) ON DELETE CASCADE" +
                                    ")";

                MySqlCommand commandManager = new MySqlCommand(sqlManager, connection);
                commandManager.ExecuteNonQuery();

                string sqlDrafts = "CREATE TABLE IF NOT EXISTS drafts( " +
                                    "id INT PRIMARY KEY AUTO_INCREMENT, " +
                                    "name VARCHAR(50) NOT NULL, " +
                                    "creator VARCHAR(50) NOT NULL, " +
                                    "goalkeeper_id INT NOT NULL, " +
                                    "leftdefender_id INT NOT NULL, " +
                                    "rightdefender_id INT NOT NULL, " +
                                    "leftmidfielder_id INT NOT NULL, " +
                                    "rightmidfielder_id INT NOT NULL, " +
                                    "leftforward_id INT NOT NULL, " +
                                    "rightforward_id INT NOT NULL, " +
                                    "manager_id INT NOT NULL, " +

                                    "CONSTRAINT fk_draft_goalkeeper " +
                                    "FOREIGN KEY(goalkeeper_id) REFERENCES players(id) ON DELETE CASCADE, " +

                                    "CONSTRAINT fk_draft_leftd " +
                                    "FOREIGN KEY(leftdefender_id) REFERENCES players(id) ON DELETE CASCADE, " +

                                    "CONSTRAINT fk_draft_rightd " +
                                    "FOREIGN KEY(rightdefender_id) REFERENCES players(id) ON DELETE CASCADE, " +

                                    "CONSTRAINT fk_draft_leftm " +
                                    "FOREIGN KEY(leftmidfielder_id) REFERENCES players(id) ON DELETE CASCADE, " +

                                    "CONSTRAINT fk_draft_rightm " +
                                    "FOREIGN KEY(rightmidfielder_id) REFERENCES players(id) ON DELETE CASCADE, " +

                                    "CONSTRAINT fk_draft_leftf " +
                                    "FOREIGN KEY(leftforward_id) REFERENCES players(id) ON DELETE CASCADE, " +

                                    "CONSTRAINT fk_draft_rightf " +
                                    "FOREIGN KEY(rightforward_id) REFERENCES players(id) ON DELETE CASCADE, " +

                                    "CONSTRAINT fk_draft_manager " +
                                    "FOREIGN KEY(manager_id) REFERENCES managers(id) ON DELETE CASCADE" +
                                    ")";

                MySqlCommand commandDrafts = new MySqlCommand(sqlDrafts, connection);
                commandDrafts.ExecuteNonQuery();

                string sqlDreamTeams = "CREATE TABLE IF NOT EXISTS dreamteams( " +
                                        "id INT PRIMARY KEY AUTO_INCREMENT, " +
                                        "name VARCHAR(50) NOT NULL, " +
                                        "creator VARCHAR(50) NOT NULL, " +
                                        "goalkeeper_id INT NOT NULL, " +
                                        "leftdefender_id INT NOT NULL, " +
                                        "rightdefender_id INT NOT NULL, " +
                                        "leftmidfielder_id INT NOT NULL, " +
                                        "rightmidfielder_id INT NOT NULL, " +
                                        "leftforward_id INT NOT NULL, " +
                                        "rightforward_id INT NOT NULL, " +
                                        "manager_id INT NOT NULL, " +

                                        "CONSTRAINT fk_dreamteams_goalkeeper " +
                                        "FOREIGN KEY(goalkeeper_id) REFERENCES players(id) ON DELETE CASCADE, " +

                                        "CONSTRAINT fk_dreamteams_leftd " +
                                        "FOREIGN KEY(leftdefender_id) REFERENCES players(id) ON DELETE CASCADE, " +

                                        "CONSTRAINT fk_dreamteams_rightd " +
                                        "FOREIGN KEY(rightdefender_id) REFERENCES players(id) ON DELETE CASCADE, " +

                                        "CONSTRAINT fk_dreamteams_leftm " +
                                        "FOREIGN KEY(leftmidfielder_id) REFERENCES players(id) ON DELETE CASCADE, " +

                                        "CONSTRAINT fk_dreamteams_rightm " +
                                        "FOREIGN KEY(rightmidfielder_id) REFERENCES players(id) ON DELETE CASCADE, " +

                                        "CONSTRAINT fk_dreamteams_leftf " +
                                        "FOREIGN KEY(leftforward_id) REFERENCES players(id) ON DELETE CASCADE, " +

                                        "CONSTRAINT fk_dreamteams_rightf " +
                                        "FOREIGN KEY(rightforward_id) REFERENCES players(id) ON DELETE CASCADE, " +

                                        "CONSTRAINT fk_dreamteams_manager " +
                                        "FOREIGN KEY(manager_id) REFERENCES managers(id) ON DELETE CASCADE" +
                                        ")";

                MySqlCommand commandDreamTeams = new MySqlCommand(sqlDreamTeams, connection);
                commandDreamTeams.ExecuteNonQuery();
            }


            connection.Close();
        }

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
