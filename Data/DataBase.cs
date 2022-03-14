using MySql.Data.MySqlClient;

namespace FutManager.Data
{
    public static class DataBase
    {
        private const string ConnectionString = "Server=localhost;Database=futmanager;Uid=root;Pwd=;";

        static DataBase()
        {
            MySqlConnection connection = GetConnection();
            connection.Open();

            using (connection)
            {
                string sql = "CREATE TABLE IF NOT EXISTS clubs( " +
    "id INT PRIMARY KEY AUTO_INCREMENT,          " +
    "name VARCHAR(50) NOT NULL,                  " +
    "league VARCHAR(50) NOT NULL,                       " +
    "rating INT                                   " +
    ")";

                MySqlCommand command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
            using (connection)
            {
                string sql = "CREATE TABLE IF NOT EXISTS nations( " +
    "id INT PRIMARY KEY AUTO_INCREMENT,          " +
    "name VARCHAR(50) NOT NULL,                  " +
    "confederation VARCHAR(50) NOT NULL,                       " +
    "rating INT                                   " +
    ")";

                MySqlCommand command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }


            connection.Close();
        }

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
