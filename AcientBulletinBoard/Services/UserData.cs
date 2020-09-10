using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace AcientBulletinBoard.Services
{
    public class UserData
    {
        public enumRole role { get; set; }
        public string name { get; set; }
        public string account { get; set; }
        public string password { get; set; }
        public string emailAddress { get; set; }
        public enumCamp camp { get; set; }
        private SQLiteConnection connection;

        public bool logIn(string account, string password)
        {
            if (!accountCheck(account, password))
                return false;
            return true;
        }

        private bool accountCheck(string account, string password)
        {
            connection = new SQLiteConnection("data source = C:\\Users\\admin\\source\\repos\\AcientBulletinBoard\\AcientBulletinBoard\\DataBases\\UserData.db");
            connection.Open();
            string commandString = $"Select * From Users Where Account = '{account}' And Password = '{password}';";
            SQLiteCommand command = new SQLiteCommand(commandString, connection);
            SQLiteDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                if (!dataReader[0].Equals(DBNull.Value))
                {
                    this.account = dataReader["Account"].ToString();
                    this.password = dataReader["Password"].ToString();
                    this.name = dataReader["Name"].ToString();
                    this.emailAddress = dataReader["EmailAddress"].ToString();
                    switch (dataReader["Camp"].ToString())
                    {
                        case "Wei":
                            camp = enumCamp.Wei;
                            break;

                        case "Shu":
                            camp = enumCamp.Shu;
                            break;

                        case "Wu":
                            camp = enumCamp.Wu;
                            break;

                        case "God":
                            camp = enumCamp.God;
                            break;

                        case "Neutral":
                            camp = enumCamp.Neutral;
                            break;
                        case "Foreign":
                            camp = enumCamp.Foreign;
                            break;
                    }
                    switch (dataReader["Role"].ToString())
                    {
                        case "admin":
                            role = enumRole.admin;
                            break;

                        case "normal":
                            role = enumRole.normal;
                            break;

                        case "guest":
                            role = enumRole.guest;
                            break;
                    }
                    connection.Close();
                    return true;
                }
            }
            connection.Close();
            return false;
        }
    }

    public enum enumRole
    {
        admin,
        normal,
        guest
    }

    public enum enumCamp
    {
        Wei,
        Shu,
        Wu,
        God,
        Neutral,
        Foreign,
    }
}