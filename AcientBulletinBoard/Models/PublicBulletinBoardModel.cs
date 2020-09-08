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
        public PublicBulletinBoardModel()
        {
            user = Helper._userData;
        }
        public void submitWithOtherIdentity()
        {

        }
        public void submit()
        {
            BulletinBoardData bulletinBoardData = new BulletinBoardData();
            bulletinBoardData.submitComment("PublicBulletinBoard",user,comment);
        }
    }
}
