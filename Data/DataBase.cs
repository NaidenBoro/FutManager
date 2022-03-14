using MySql.Data.MySqlClient;

namespace FutManager.Data
{
    public static class DataBase
    {
        private const string ConnectionString = "";

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


        }

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
