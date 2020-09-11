using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcientBulletinBoard.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcientBulletinBoard.Controllers
{
    [Route("CampBulletinBoard")]
    public class CampBulletinBoardController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            if (Helper._userData.camp == enumCamp.Neutral)
                return Redirect("/PublicBulletinBoard");
            Models.CampBulletinBoardModel model = new Models.CampBulletinBoardModel();
            return View(model);
        }
    }
}
