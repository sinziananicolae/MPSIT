using Microsoft.AspNet.Identity;
using MPSIT.Services.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MPSIT.ControllersAPI
{
    public class UserController : ApiController
    {

        private UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        public object Get()
        {
            var userId = User.Identity.GetUserId();

            if (userId == null)
            {
                return new
                {
                    success = false,
                    message = "Please login to acces your account!"
                };
            }

            var userProfile = _userService.GetUserProfile(userId);


            return new
            {
                success = true,
                data = userProfile
            };
        }

        [HttpGet]
        [Route("api/user/report")]
        public void SendReport()
        {
            var userId = User.Identity.GetUserId();

            _userService.SendReport(userId);
        }
    }
}