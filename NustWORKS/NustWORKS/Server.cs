using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace NustWORKS
{
    public static class Server
    {
        const string Host = "localhost";
        const string Username = "root";
        const string Password = "zdsalpha";
        const string Dataset = "nustworks";

        public static UserInfo CurrentUser { get; private set; }

        public static MySqlConnection Connection { get; private set; }

        public static void Connect()
        {
            string connectionString = "server=" + Host + ";uid=" + Username + ";pwd=" + Password + ";database=" + Dataset;
            Connection = new MySqlConnection(connectionString);
            Connection.Open();
        }

        public static void Register(string cms, string fn, string ln, string pn, string pass, string email)
        {
            string commandString = "INSERT INTO user VALUES (@cms,@fn,@ln,@pn,@pass,@email)";
            MySqlCommand command = new MySqlCommand(commandString, Connection);
            command.Parameters.AddWithValue("@cms", cms);
            command.Parameters.AddWithValue("@fn", fn);
            command.Parameters.AddWithValue("@ln", ln);
            command.Parameters.AddWithValue("@pn", pn);
            command.Parameters.AddWithValue("@pass", pass);
            command.Parameters.AddWithValue("@email", email);
            command.ExecuteNonQuery();
        }

        public static UserInfo Login(string cms, string password)
        {
            string commandString = "SELECT * FROM user WHERE cmsid=@cms AND password=@password";
            MySqlCommand command = new MySqlCommand(commandString, Connection);
            command.Parameters.AddWithValue("@cms", cms);
            command.Parameters.AddWithValue("@password", password);
            UserInfo user = null;
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                user = new UserInfo();
                user.cms = (string)reader["cmsid"];
                user.fn = (string)reader["firstname"];
                user.ln = (string)reader["lastname"];
                user.pn = (string)reader["phone"];
                user.email = (string)reader["emailid"];
            }
            reader.Close();
            return user;
        }

    }
}
