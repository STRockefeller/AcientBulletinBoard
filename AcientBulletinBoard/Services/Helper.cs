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

        public static void setUser(UserData userData)
        {
            _userData = userData;
        }
        public static void resetUser()
        {
            _userData = new UserData();
        }
    }
}