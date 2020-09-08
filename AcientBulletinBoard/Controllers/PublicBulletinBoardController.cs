using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcientBulletinBoard.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcientBulletinBoard.Controllers
{
    [Route("PublicBulletinBoard")]
    public class PublicBulletinBoardController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            PublicBulletinBoardModel model = new PublicBulletinBoardModel();
            return View(model);
        }
    }
}
