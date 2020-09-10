using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AcientBulletinBoard.Controllers
{
    [Route("System")]
    public class SystemController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("SignUp")]
        public IActionResult SignUp()
        {
            Models.SystemModel model = new Models.SystemModel();
            return View(model);
        }
    }
}
