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
            Models.SystemModel model = new Models.SystemModel();
            if (Services.Helper._userData.role != Services.enumRole.admin)
                return Redirect("/");
            return View(model);
        }
        [Route("SignUp")]
        public IActionResult SignUp()
        {
            Models.SystemSignUpModel model = new Models.SystemSignUpModel();
            return View(model);
        }
        [Route("AccountsManagement")]
        public IActionResult AccountsManagement()
        {
            Models.SystemAccountsManagementModel model = new Models.SystemAccountsManagementModel();
            if (Services.Helper._userData.role != Services.enumRole.admin)
                return Redirect("/");
            return View(model);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult SignUpInputCheck([FromForm]Models.SystemSignUpModel signUpModel)
        //{
        //    if (ModelState.IsValid)
        //        return Ok(signUpModel);
        //    return BadRequest(ModelState);
        //}
    }
}
