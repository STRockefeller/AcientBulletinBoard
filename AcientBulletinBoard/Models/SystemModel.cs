using AcientBulletinBoard.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcientBulletinBoard.Models
{
    public class SystemModel
    {
    }
    public class SystemSignUpModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string inputName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string inputEmailAddress { get; set; }
        [Required(ErrorMessage = "Account is required")]
        public string inputAccount { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        public string inputPassword { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password is Required")]
        [Compare("inputPassword", ErrorMessage = "Password and Confirm Password do not match")]
        public string inputConfirmPassword { get; set; }
        [Required(ErrorMessage = "Camp  is Required")]
        public string inputCamp { get; set; }
        public enumRole inputRole { get; set; }
    }
    public class SystemAccountsManagementModel
    {
        public List<UserData> userList = new List<UserData>();
        /// <summary>
        /// constructer / get user list from database
        /// </summary>
        public SystemAccountsManagementModel()
        {
            getUserList();
        }
        private void getUserList()
        {

        }
    }
}
