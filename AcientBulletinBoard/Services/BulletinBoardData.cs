using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace AcientBulletinBoard.Services
{
    public class BulletinBoardData
    {
        SQLiteConnection connection = new SQLiteConnection();
        public BulletinBoardData()
        {
            connection = new SQLiteConnection(@"data source = C:\Users\admin\source\repos\AcientBulletinBoard\AcientBulletinBoard\DataBases\BulletinBoard.db");
        }

        public void submitComment(string targetBoard,UserData user,string comment)
        {
            string commandString = $"INSERT INTO {targetBoard} (Name,Camp ,Comment,DateTime) VALUES('{user.name}', '{user.camp.ToString()}','{comment}','{DateTime.Now}'); ";
            SQLiteCommand command = new SQLiteCommand(commandString, connection);
            command.ExecuteNonQuery();
        }
    }

}
