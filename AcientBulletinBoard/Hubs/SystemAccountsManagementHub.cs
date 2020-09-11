using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcientBulletinBoard.Services;
using Microsoft.AspNetCore.SignalR;

namespace AcientBulletinBoard.Hubs
{
    public class SystemAccountsManagementHub : Hub
    {
        public async Task UpdateAccountsList(string searchByAccount, string searchByEmail, string searchByCamp)
        {
            await Clients.All.SendAsync("GenerateAccountsList", search(searchByAccount, searchByEmail, searchByCamp).ToArray());
        }
        private List<string[]> search(string searchByAccount, string searchByEmail, string searchByCamp)
        {
            List<UserData> users = Helper.SearchUser(searchByAccount, searchByEmail, searchByCamp);
            List<string[]> usersDisplay = new List<string[]>();
            foreach (UserData user in users)
                usersDisplay.Add(new string[4] { user.account, user.emailAddress, user.name, user.camp.ToString() });
            return usersDisplay;
        }
    }
}
