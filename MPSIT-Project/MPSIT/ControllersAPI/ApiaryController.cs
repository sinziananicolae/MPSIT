using Microsoft.AspNet.Identity;
using MPSIT.Services.ApiaryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MPSIT.ControllersAPI
{
    public class ApiaryController : ApiController
    {
        private ApiaryService _apiaryService;

        public ApiaryController()
        {
            _apiaryService = new ApiaryService();
        }

        // GET api/<controller>
        public object Get()
        {
            var userId = User.Identity.GetUserId();

            return new
            {
                data = _apiaryService.GetApiaries(userId)
            };
        }

        [HttpGet]
        [Route("api/apiary/all")]
        public object GetAllApiaries()
        {
            return new
            {
                data = _apiaryService.GetApiariesInfo()
            };
        }
    }
}