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
            connection.Open();
            string commandString = $"INSERT INTO {targetBoard} (Name,Camp ,Comment,DateTime) VALUES('{user.name}', '{user.camp.ToString()}','{comment}','{DateTime.Now}'); ";
            SQLiteCommand command = new SQLiteCommand(commandString, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public List<Comment> getCommentList(string targetBoard)
        {
            connection.Open();
            List<Comment> returnValue = new List<Comment>();
            string commandString = $"Select * From {targetBoard};";
            SQLiteCommand command = new SQLiteCommand(commandString, connection);
            SQLiteDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read())
            {
                if(!dataReader[0].Equals(DBNull.Value))
                {
                    Comment comment = new Comment();
                    comment.name = dataReader["Name"].ToString();
                    comment.camp = dataReader["Camp"].ToString();
                    comment.comment = dataReader["Comment"].ToString();
                    comment.dateTime = dataReader["DateTime"].ToString();
                    returnValue.Add(comment);
                }
            }
            connection.Close();
            return returnValue;
        }
        public void clearBoard(string targetBoard)
        {
            connection.Open();
            string commandString = $"Delete From {targetBoard};";
            SQLiteCommand command = new SQLiteCommand(commandString, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    public struct Comment
    {
        public string name { get; set; }
        public string camp { get; set; }
        public string comment { get; set; }
        public string dateTime { get; set; }
    }
}
