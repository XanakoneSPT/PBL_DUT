using System;
using System.Data;
using System.Data.SqlClient;

namespace PBL3.Model.Dao
{
    internal class dbConnection
    {
        private SqlConnection connection;
        private string connectionString;

        public dbConnection()
        {
            connectionString = @"Data Source=XANAKONE\SQLEXPRESS;Initial Catalog=PBL3Final;Integrated Security=True;Encrypt=False";
            connection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
                Console.WriteLine("Connection opened successfully.");
            }
        }

        public void CloseConnection()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
                Console.WriteLine("Connection closed successfully.");
            }
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
