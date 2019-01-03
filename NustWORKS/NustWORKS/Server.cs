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
        static Random random = new Random();
        const string Host = "localhost";
        const string Port = "3307";
        const string Username = "root";
        const string Password = "71722550";
        const string Dataset = "nustworks";

        public static UserInfo CurrentUser { get; private set; }

        public static MySqlConnection Connection { get; private set; }

        public static void Connect()
        {
            string connectionString = "server=" + Host + ";port=" + Port + ";uid=" + Username + ";pwd=" + Password + ";database=" + Dataset;
            Connection = new MySqlConnection(connectionString);
            Connection.Open();
        }

        public static MySqlCommand Command(string command)
        {
            return new MySqlCommand(command, Connection);
        }

        public static object[] GetRow(MySqlCommand command, params string[] fields)
        {
            MySqlDataReader reader = command.ExecuteReader();
            if (!reader.Read()) return null;
            object[] row = new object[fields.Length];
            for (int i = 0; i < fields.Length; i++)
                row[i] = reader[fields[i]];
            reader.Close();
            command.Dispose();
            return row;
        }

        public static object[][] GetRows(MySqlCommand command, params string[] fields)
        {
            List<object[]> rows = new List<object[]>();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                object[] row = new object[fields.Length];
                for (int i = 0; i < fields.Length; i++)
                    row[i] = reader[fields[i]];
                rows.Add(row);
            }
            reader.Close();
            command.Dispose();
            return rows.ToArray();
        }

        public static int Count(MySqlCommand command)
        {
            int count = (int)command.ExecuteScalar();
            command.Dispose();
            return count;
        }

        public static bool Exists(MySqlCommand command)
        {
            List<object[]> rows = new List<object[]>();
            MySqlDataReader reader = command.ExecuteReader();
            bool output = reader.Read();
            reader.Close();
            command.Dispose();
            return output;
        }

        public static int Execute(MySqlCommand command)
        {
            int output = command.ExecuteNonQuery();
            command.Dispose();
            return output;
        }

        public static UserInfo[] GetAllUsers()
        {
            object[][] rows = GetRows(Command("SELECT * FROM user"), "cmsid", "firstname", "lastname", "phone", "emailid");
            return rows.Select((row) =>
            {
                UserInfo user = new UserInfo();
                user.CMS = (string)row[0];
                user.FirstName = (string)row[1];
                user.LastName = (string)row[2];
                user.PhoneNo = (string)row[3];
                user.Email = (string)row[4];
                return user;
            }).ToArray();
        }

        public static UserInfo GetUser(string cms)
        {
            var command = Command("SELECT * FROM user WHERE cmsid=@cms");
            command.Parameters.AddWithValue("@cms", cms);
            object[] row = GetRow(command, "cmsid", "firstname", "lastname", "phone", "emailid");
            UserInfo user = new UserInfo();
            user.CMS = (string)row[0];
            user.FirstName = (string)row[1];
            user.LastName = (string)row[2];
            user.PhoneNo = (string)row[3];
            user.Email = (string)row[4];
            return user;
        }

        public static void Register(string cms, string fn, string ln, string phone, string pass, string email)
        {
            string commandString = "INSERT INTO user VALUES (@cms,@fn,@ln,@pn,@pass,@email)";
            MySqlCommand command = new MySqlCommand(commandString, Connection);
            command.Parameters.AddWithValue("@cms", cms);
            command.Parameters.AddWithValue("@fn", fn);
            command.Parameters.AddWithValue("@ln", ln);
            command.Parameters.AddWithValue("@pn", phone);
            command.Parameters.AddWithValue("@pass", pass);
            command.Parameters.AddWithValue("@email", email);
            Execute(command);
        }

        public static UserInfo Login(string cms, string password)
        {
            MySqlCommand command = Command("SELECT * FROM user WHERE cmsid=@cms AND password=@password");
            command.Parameters.AddWithValue("@cms", cms);
            command.Parameters.AddWithValue("@password", password);
            object[] row = GetRow(command, "cmsid", "firstname", "lastname", "phone", "emailid");
            UserInfo user = new UserInfo();
            user.CMS = (string)row[0];
            user.FirstName = (string)row[1];
            user.LastName = (string)row[2];
            user.PhoneNo = (string)row[3];
            user.Email = (string)row[4];
            CurrentUser = user;
            return user;
        }

        public static bool UpdateUser(string cms, string fn, string ln, string pn, string email)
        {
            MySqlCommand command = Command("UPDATE user SET cmsid=@cms, firstname=@fn, lastname=@ln, phone=@pn, emailid=@email WHERE cmsid=@cms");
            command.Parameters.AddWithValue("@cms", cms);
            command.Parameters.AddWithValue("@fn", fn);
            command.Parameters.AddWithValue("@ln", ln);
            command.Parameters.AddWithValue("@pn", pn);
            command.Parameters.AddWithValue("@email", email);
            int changes = Execute(command);
            if (changes < 1) return false;
            CurrentUser.CMS = cms;
            CurrentUser.FirstName = fn;
            CurrentUser.LastName = ln;
            CurrentUser.PhoneNo = pn;
            CurrentUser.Email = email;
            return true;
        }

        public static int GetTagId(string tag)
        {
            tag = tag.ToLower();
            MySqlCommand command = Command("SELECT tagid FROM tags WHERE tagname=@tag");
            command.Parameters.AddWithValue("@tag", tag);
            object[] row = GetRow(command);
            if (row == null)
            {
                return -1;
            }
            else
            {
                return (int)row[0];
            }
        }

        public static int CreateTag(string tag)
        {
            tag = tag.ToLower();
            int tag_id = GetTagId(tag);
            if (tag_id != -1)
                return tag_id;
            tag_id = random.Next(int.MaxValue);
            var command = Command("INSERT INTO tags VALUES (@tagid,@tagname)");
            command.Parameters.AddWithValue("@tagid", tag_id);
            command.Parameters.AddWithValue("@tagname", tag);
            Execute(command);
            return tag_id;
        }

        public static int AddProject(string client, string name, int budget, string duration, string desc)
        {
            int project_id = random.Next(int.MaxValue);
            var command = Command("INSERT INTO project VALUES (@id,@name,@client,@budget,@duration,@desc)");
            command.Parameters.AddWithValue("@id", project_id);
            command.Parameters.AddWithValue("@client", client);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@budget", budget);
            command.Parameters.AddWithValue("@duration", duration);
            command.Parameters.AddWithValue("@desc", desc);
            Execute(command);
            return project_id;
        }

        public static void AddTagToProject(int project, string tag)
        {
            int tag_id = CreateTag(tag);
            var command = Command("INSERT INTO projectags VALUES (@proj,@tag)");
            command.Parameters.AddWithValue("@proj", project);
            command.Parameters.AddWithValue("@tag", tag_id);
            Execute(command);
        }

        public static int AddProject(string client, string name, int budget, string duration, string desc, string[] tags)
        {
            int proj_id = AddProject(client, name, budget, duration, desc);
            //foreach (string tag in tags)
            //    AddTagToProject(proj_id, tag);
            return proj_id;
        }

        public static ProjectInfo[] GetProjects()
        {
            object[][] rows = GetRows(Command("SELECT * FROM project"), "projectid", "projectname", "clientid", "budget", "pduration", "pdetails");
            return rows.Select((row) =>
            {
                ProjectInfo proj = new ProjectInfo();
                proj.ProjectId = int.Parse((string)row[0]);
                proj.Name = (string)row[1];
                proj.Client = (string)row[2];
                proj.Budget = int.Parse((string)row[3]);
                proj.Duration = (string)row[4];
                proj.Details = (string)row[5];
                return proj;
            }).ToArray();
        }

        public static ProjectInfo GetProject(int id)
        {
            var command = Command("SELECT * FROM project WHERE projectid=@id");
            command.Parameters.AddWithValue("@id", id);
            object[] row = GetRow(command, "projectid", "projectname", "clientid", "budget", "pduration", "pdetails");
            ProjectInfo proj = new ProjectInfo();
            proj.ProjectId = int.Parse((string)row[0]);
            proj.Name = (string)row[1];
            proj.Client = (string)row[2];
            proj.Budget = int.Parse((string)row[3]);
            proj.Duration = (string)row[4];
            proj.Details = (string)row[5];
            return proj;
        }

        public static ProjectInfo[] GetAvailableProjects()
        {
            object[][] rows = GetRows(Command("SELECT * FROM project WHERE NOT EXISTS (SELECT * FROM workingprojects WHERE project.projectid = workingprojects.projectid)"), "projectid", "projectname", "clientid", "budget", "pduration", "pdetails");
            return rows.Select((row) =>
            {
                ProjectInfo proj = new ProjectInfo();
                proj.ProjectId = int.Parse((string)row[0]);
                proj.Name = (string)row[1];
                proj.Client = (string)row[2];
                proj.Budget = int.Parse((string)row[3]);
                proj.Duration = (string)row[4];
                proj.Details = (string)row[5];
                return proj;
            }).ToArray();
        }

        public static ProjectInfo[] GetMyProjects()
        {
            var command = Command("SELECT * FROM project WHERE clientid=@cms");
            command.Parameters.AddWithValue("@cms", CurrentUser.CMS);
            object[][] rows = GetRows(command, "projectid", "projectname", "clientid", "budget", "pduration", "pdetails");
            return rows.Select((row) =>
            {
                ProjectInfo proj = new ProjectInfo();
                proj.ProjectId = int.Parse((string)row[0]);
                proj.Name = (string)row[1];
                proj.Client = (string)row[2];
                proj.Budget = int.Parse((string)row[3]);
                proj.Duration = (string)row[4];
                proj.Details = (string)row[5];
                return proj;
            }).ToArray();
        }

        public static ProjectInfo[] GetWorkingProjects()
        {
            var command = Command("SELECT project.projectid AS pid,project.projectname AS name,project.clientid AS client,project.budget AS budget,project.pduration AS duration,project.pdetails AS details FROM project,workingprojects WHERE project.projectid=workingprojects.projectid AND workingprojects.freelancerid = @cms");
            command.Parameters.AddWithValue("@cms", CurrentUser.CMS);
            object[][] rows = GetRows(command, "pid", "name", "client", "budget", "duration", "details");
            return rows.Select((row) =>
            {
                ProjectInfo proj = new ProjectInfo();
                proj.ProjectId = int.Parse((string)row[0]);
                proj.Name = (string)row[1];
                proj.Client = (string)row[2];
                proj.Budget = int.Parse((string)row[3]);
                proj.Duration = (string)row[4];
                proj.Details = (string)row[5];
                return proj;
            }).ToArray();
        }

        public static void AcceptProject(int projectId, string client, string workingStatus, string payStatus)
        {
            var command = Command("INSERT INTO workingprojects VALUES (@pid,@client,@freelancer,@wstatus,@pstatus)");
            command.Parameters.AddWithValue("@pid", projectId);
            command.Parameters.AddWithValue("@client", client);
            command.Parameters.AddWithValue("@freelancer", CurrentUser.CMS);
            command.Parameters.AddWithValue("@wstatus", workingStatus);
            command.Parameters.AddWithValue("@pstatus", payStatus);
            Execute(command);
        }
        
        public static void FinishProject(int projectid)
        {
            var command1 = Command("DELETE FROM project WHERE projectid=@id");
            command1.Parameters.AddWithValue("@id", projectid);
            Execute(command1);
        }
    }
}
