using MySql.Data.MySqlClient;

namespace FutManager.Data
{
    public static class DataBase
    {
        private const string ConnectionString = "Server=localhost;Database=futManager;Uid=root;Pwd=mTopkaKir1;";

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
                                    "FOREIGN KEY(nationality_id) REFERENCES nations(id), " +
                                    "CONSTRAINT fk_players_clubs " + 
                                    "FOREIGN KEY(club_id) REFERENCES clubs(id) " +
                                    ")";

                MySqlCommand commandPlayer = new MySqlCommand(sqlPlayer, connection);
                commandPlayer.ExecuteNonQuery();
            }


            connection.Close();
        }

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
