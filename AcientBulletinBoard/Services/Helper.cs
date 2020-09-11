using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data.SQLite;

namespace AcientBulletinBoard.Services
{
    public static class Helper
    {
        public static UserData _userData = new UserData();
        public static List<UserData> GetDefaultUsers()
        {
            List<UserData> users = new List<UserData>();

            users.Add(new UserData() { name = "曹操", camp = enumCamp.Wei });

            users.Add(new UserData() { name = "劉備", camp = enumCamp.Shu });
            users.Add(new UserData() { name = "關羽", camp = enumCamp.Shu });
            users.Add(new UserData() { name = "張飛", camp = enumCamp.Shu });
            users.Add(new UserData() { name = "趙雲", camp = enumCamp.Shu });
            users.Add(new UserData() { name = "諸葛亮", camp = enumCamp.Shu });

            users.Add(new UserData() { name = "孫堅", camp = enumCamp.Wu });

            return users;
        }
        public static void SetUser(UserData userData)
        {
            _userData = userData;
        }
        public static void ResetUser()
        {
            _userData = new UserData();
        }
        public static void CreateUser(UserData user)
        {
            SQLiteConnection connection = new SQLiteConnection();
            connection = new SQLiteConnection("data source = C:\\Users\\admin\\source\\repos\\AcientBulletinBoard\\AcientBulletinBoard\\DataBases\\UserData.db");
            connection.Open();
            string commandString = $"Insert into Users (role,name,account,password,emailAddress,camp)" +
                $" Values ('{user.role.ToString()}','{user.name}','{user.account}','{user.password}','{user.emailAddress}','{user.camp.ToString()}');";
            SQLiteCommand command = new SQLiteCommand(commandString, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static List<UserData> SearchUser(string searchByAccount, string searchByEmail, string searchByCamp)
        {
            List<UserData> AllUserList = new List<UserData>();
            SQLiteConnection connection = new SQLiteConnection();
            connection = new SQLiteConnection("data source = C:\\Users\\admin\\source\\repos\\AcientBulletinBoard\\AcientBulletinBoard\\DataBases\\UserData.db");
            connection.Open();
            string commandString = $"Select * From Users;";
            SQLiteCommand command = new SQLiteCommand(commandString, connection);
            SQLiteDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                if (!dataReader[0].Equals(DBNull.Value))
                {
                    Services.UserData user = new UserData();
                    user.account = dataReader["Account"].ToString();
                    user.password = dataReader["Password"].ToString();
                    user.name = dataReader["Name"].ToString();
                    user.emailAddress = dataReader["EmailAddress"].ToString();
                    switch (dataReader["Camp"].ToString())
                    {
                        case "Wei":
                            user.camp = enumCamp.Wei;
                            break;

                        case "Shu":
                            user.camp = enumCamp.Shu;
                            break;

                        case "Wu":
                            user.camp = enumCamp.Wu;
                            break;

                        case "God":
                            user.camp = enumCamp.God;
                            break;

                        case "Neutral":
                            user.camp = enumCamp.Neutral;
                            break;
                        case "Foreign":
                            user.camp = enumCamp.Foreign;
                            break;
                    }
                    switch (dataReader["Role"].ToString())
                    {
                        case "admin":
                            user.role = enumRole.admin;
                            break;

                        case "normal":
                            user.role = enumRole.normal;
                            break;

                        case "guest":
                            user.role = enumRole.guest;
                            break;
                    }
                    AllUserList.Add(user);
                }
            }

            List<UserData> searchUserList = new List<UserData>();
            searchUserList.AddRange(AllUserList);
            if (searchByAccount != "")
                searchUserList = searchUserList.Where(user => user.account == searchByAccount).ToList();
            if (searchByEmail != "")
                searchUserList = searchUserList.Where(user => user.emailAddress == searchByEmail).ToList();
            if (searchByCamp != "")
                searchUserList = searchUserList.Where(user => user.camp.ToString() == searchByCamp).ToList();
            connection.Close();
            return searchUserList;
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}