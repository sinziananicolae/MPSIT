using MPSIT.Services.HiveService;
using MPSIT.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MPSIT.ControllersAPI
{
    public class SensorsInfoController : ApiController
    {
        private HiveService _hiveService;

        public SensorsInfoController()
        {
            _hiveService = new HiveService();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post(List<SensorsDataModel> model)
        {
            _hiveService.SaveSensorsData(model);
        }
    }
}