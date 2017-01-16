using MPSIT.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPSIT.Services.ApiaryService
{
    public class ApiaryService
    {
        private Entities _dbEntities;
        private HiveService.HiveService _hiveService;

        public ApiaryService()
        {
            _dbEntities = new Entities();
            _hiveService = new HiveService.HiveService();
        }

        public List<object> GetApiaries(string userId)
        {
            List<object> apiaries = new List<object>();

            IEnumerable<Apiary> allApiaries = _dbEntities.Apiaries.Where(f => f.UserId == userId).ToList();
            foreach (Apiary apiary in allApiaries)
            {
                IEnumerable<Hive> allHives = apiary.Hives;
                List<object> hives = new List<object>();

                foreach (Hive hive in allHives)
                {
                    IEnumerable<SensorData> allSensorData = hive.SensorDatas;
                    List<object> sensorDatas = new List<object>();

                    foreach (SensorData sensorData in allSensorData.OrderByDescending(f => f.Timestamp).Take(1))
                    {
                        sensorDatas.Add(new
                        {
                            sensorData.Id,
                            sensorData.Humidity,
                            sensorData.Light,
                            sensorData.Temperature,
                            sensorData.Weight,
                            sensorData.Timestamp
                        });
                    }

                    hives.Add(new
                    {
                        hive.Id,
                        SensorData = sensorDatas[0],
                        HiveFile = _hiveService.GetLastHiveFile(hive.Id)
                    });
                }

                apiaries.Add(new
                {
                    apiary.Id,
                    apiary.Latitude,
                    apiary.Longitude,
                    apiary.BeeSpecies,
                    Hives = hives
                });
            }

            return apiaries;
        }

        public List<object> GetApiariesInfo(string userId)
        {
            List<object> apiaries = new List<object>();
            IEnumerable<Apiary> allApiaries = _dbEntities.Apiaries.ToList();

            foreach (Apiary apiary in allApiaries)
            {
                apiaries.Add(new
                {
                    apiary.Id,
                    apiary.Latitude,
                    apiary.Longitude,
                    apiary.BeeSpecies,
                    HivesNo = apiary.Hives.Count(),
                    OwnerEmail = apiary.AspNetUser.Email,
                    IsOwner = apiary.UserId == userId ? true : false
                });
            }


            return apiaries;
        }

        public List<object> GetApiariesLocation(string userId) {
            List<object> apiaries = new List<object>();
            IEnumerable<Apiary> allApiaries = _dbEntities.Apiaries.Where(f=>f.UserId == userId).ToList();

            foreach (Apiary apiary in allApiaries)
            {
                apiaries.Add(new
                {
                    apiary.Id,
                    apiary.Latitude,
                    apiary.Longitude,
                    apiary.BeeSpecies,
                    HivesNo = apiary.Hives.Count()
                });
            }


            return apiaries;
        }
    }
}
