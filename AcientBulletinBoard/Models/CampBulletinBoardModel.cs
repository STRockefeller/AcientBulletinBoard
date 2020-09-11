using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using AcientBulletinBoard.Services;

namespace AcientBulletinBoard.Models
{
    public class CampBulletinBoardModel
    {
        public UserData user;
        public string targetBoard;
        public string comment { get; set; }
        public List<Comment> comments = new List<Comment>();
        public CampBulletinBoardModel()
        {
            user = Helper._userData;
            switch(user.camp)
            {
                case enumCamp.Wei:
                    targetBoard = "Wei";
                    break;
                case enumCamp.Shu:
                    targetBoard = "Shu";
                    break;
                case enumCamp.Wu:
                    targetBoard = "Wu";
                    break;
                case enumCamp.Foreign:
                    targetBoard = "Foreign";
                    break;
                case enumCamp.God:
                    targetBoard = "God";
                    break;
            }
            updateComment();
        }
        public void updateComment()
        {
            comments.Clear();
            BulletinBoardData data = new BulletinBoardData();
            comments.AddRange(data.getCommentList(targetBoard+"CampBulletinBoard"));
        }
    }
}
