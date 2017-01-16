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

        public ApiaryService()
        {
            _dbEntities = new Entities();
        }

        public List<object> GetApiaries(string userId)
        {
            List<object> apiaries = new List<object>();

            IEnumerable<Apiary> allApiaries = _dbEntities.Apiaries.Where(f => f.UserId == userId).ToList();
            foreach (Apiary apiary in apiaries)
            {
                IEnumerable<Hive> allHives = apiary.Hives;
                List<object> hives = new List<object>();

                foreach (Hive hive in allHives)
                {
                    IEnumerable<SensorData> allSensorData = hive.SensorDatas;
                    List<object> sensorDatas = new List<object>();

                    foreach (SensorData sensorData in allSensorData.OrderByDescending(f => f.Timestamp).Take(20))
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
                        SensorData = sensorDatas
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

        public List<object> GetApiariesInfo()
        {
            List<object> apiaries = new List<object>();
            IEnumerable<Apiary> allApiaries = _dbEntities.Apiaries.ToList();

            foreach (Apiary apiary in apiaries)
            {
                apiaries.Add(new
                {
                    apiary.Id,
                    apiary.Latitude,
                    apiary.Longitude,
                    apiary.BeeSpecies,
                    HivesNo = apiary.Hives.Count(),
                    OwnerEmail = apiary.AspNetUser.Email
                });
            }


            return apiaries;
        }
    }
}
