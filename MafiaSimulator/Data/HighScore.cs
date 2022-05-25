using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using Microsoft.Identity.Client;
using Microsoft.Data.SqlClient;

namespace MafiaSimulator.Data
{
    public class HighScore : DataBaseHolder
    {
        public List<HighscoreVariables> Variables = new List<HighscoreVariables>();
        
        private string _connectionString;
        private SqlCredential _sqlCredential;
        private string _assignedTable;

        public class HighscoreVariables
        {
            public HighscoreVariables(string name, int score, string date)
            {
                Name = name;
                Score = score;
                Date = date;
            }
            
            public string Name;

            public int Score;

            public string Date;
        }

        public override void UpdateTable()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString, _sqlCredential))
            {
                conn.Open();
                var selectCommand = new SqlCommand($"INSERT INTO {_assignedTable} ([Names], [Score], [Date]) VALUES ('{Variables[0].Name}', {Variables[0].Name}, {DateTime.Today})", conn);
                selectCommand.ExecuteReader().Close();
                conn.Close();
            }
        }

        public override void UpdateData(int topDisplayed = 1)
        {
            if (topDisplayed < 1)
                topDisplayed = 1;
                
            using (SqlConnection conn = new SqlConnection(_connectionString, _sqlCredential))
            {
                conn.Open();
                Variables.Clear();
                var selectCommand = new SqlCommand($"SELECT TOP {topDisplayed} * FROM {_assignedTable}  order by score desc;", conn); // WhY iS sCoRe HeRe?1!!??++!! calm down buddy. this is made specifically for something that golds score. if there is no score at all it will throw a hissyfit.
                var results = selectCommand.ExecuteReader();
                while (results.Read())
                {
                    Variables.Add(new HighscoreVariables(
                        Convert.ToString(results[0]),
                        Convert.ToInt32(results[1]),
                        Convert.ToString(results[2]).Replace(" 00:00:00", "")
                        )
                    );
                }
                results.Close();
                conn.Close();
            }
        }

        public override void Load(string azureUserId, string azurePassword, string dataBase, string assignedTable)
        { 
            _connectionString = $"Server=tcp:{DataManager.azureServer},1433;"
                                       + $"Database={dataBase};"
                                       + "Encrypt=True;";

            _assignedTable = assignedTable;
            
            var pwd = new SecureString();

            var azurePasswordCharArray = azurePassword.ToCharArray();
            
            for (int i = 0; i < azurePasswordCharArray.Length; i++)
                pwd.AppendChar(azurePasswordCharArray[i]);

            pwd.MakeReadOnly();
            
            _sqlCredential = new SqlCredential(azureUserId, pwd);
        }
    }
}