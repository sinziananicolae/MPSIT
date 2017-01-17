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
    public class HiveController : ApiController
    {
        private HiveService _hiveService;

        public HiveController()
        {
            _hiveService = new HiveService();
        }

        // GET api/<controller>
        public object Get(int id)
        {
            return _hiveService.GetHiveInformation(id);
        }

        public void Post(List<SensorsDataModel> model)
        {
            _hiveService.InsertHivesData(model);
        }

        [HttpPost]
        [Route("api/hive/file")]
        public void SaveHiveFile(HiveFileModel model)
        {
            if (model.Id == 0)
                _hiveService.SaveHiveFile(model);
            else
                _hiveService.UpdateHiveFile(model);
        }

    }
}