using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcientBulletinBoard.Services;

namespace AcientBulletinBoard.Models
{
    public class PublicBulletinBoardModel
    {
        public UserData user;
        public string comment { get; set; }
        public List<Comment> comments = new List<Comment>();
        public PublicBulletinBoardModel()
        {
            user = Helper._userData;
            updateComment();
        }
        public void updateComment()
        {
            comments.Clear();
            BulletinBoardData data = new BulletinBoardData();
            comments.AddRange(data.getCommentList("PublicBulletinBoard"));
        }
    }
}
