using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using LinqToDB;
using DataModels;

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
        private User linqUser;
        private SQLiteConnection connection;
        public void logIn(string account, string password)
        {
            if (!accountCheck(account, password))
                return;
            if(linqUser!=null)
                setValueLinq();
        }
        private bool accountCheck(string account, string password)
        {
            try
            {
                using (var db = new UserDataDB())
                {
                    if (db.Users.Any(user => user.Account == account && user.Password == password))
                        linqUser = db.Users.Where(user => user.Account == account && user.Password == password).Single();
                    return db.Users.Any(user => user.Account == account && user.Password == password);
                }
            }
            catch (Exception ex)
            {
                connection = new SQLiteConnection("data source = C:\\Users\\admin\\source\\repos\\AcientBulletinBoard\\AcientBulletinBoard\\DataBases\\UserData.db");
                connection.Open();
                string commandString = $"Select * From Users Where Account = '{account}' And Password = '{password}';";
                SQLiteCommand command = new SQLiteCommand(commandString, connection);
                SQLiteDataReader dataReader = command.ExecuteReader();
                while(dataReader.Read())
                {
                    if(!dataReader[0].Equals(DBNull.Value))
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
        private void setValueLinq()
        {
            account = linqUser.Account;
            password = linqUser.Password;
            name = linqUser.Name;
            emailAddress = linqUser.EmailAddress;
            switch (linqUser.Camp)
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
            }
            switch (linqUser.Role)
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
    }
}
