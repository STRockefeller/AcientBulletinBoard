using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AcientBulletinBoard.Services
{
    public static class Helper
    {
        public static UserData _userData = new UserData();
        public static List<UserData> getDefaultUsers()
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
        public static void setUser(UserData userData)
        {
            _userData = userData;
        }
        public static void resetUser()
        {
            _userData = new UserData();
        }
        public static void createUser(UserData user)
        {
            //todo
        }
    }
}