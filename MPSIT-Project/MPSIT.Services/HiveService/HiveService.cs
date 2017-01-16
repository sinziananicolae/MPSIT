using MPSIT.Data.Database;
using MPSIT.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPSIT.Services.HiveService
{
    public class HiveService
    {
        private readonly Entities _dbEntities;

        public HiveService()
        {
            _dbEntities = new Entities();
        }

        public List<object> GetAllHiveFiles(int hiveId)
        {
            List<HiveInfo> hiveInfos = _dbEntities.HiveInfoes.OrderByDescending(f => f.Timestamp).Where(f => f.HiveId == hiveId).ToList();

            List<object> allInfo = new List<object>();
            foreach (HiveInfo hiveInfo in hiveInfos) {
                allInfo.Add(new {
                    hiveInfo.HiveId,
                    hiveInfo.Id,
                    hiveInfo.Health,
                    hiveInfo.Food,
                    hiveInfo.Cleanness,
                    hiveInfo.Larvae,
                    hiveInfo.Status,
                    hiveInfo.Timestamp
                });
            }
            return allInfo;
        }

        public object GetLastHiveFile(int hiveId) {
            var hiveInfo = _dbEntities.HiveInfoes.OrderByDescending(f => f.Timestamp).FirstOrDefault(f => f.HiveId == hiveId) ;

            return new
            {
                hiveInfo.HiveId,
                hiveInfo.Id,
                hiveInfo.Health,
                hiveInfo.Food,
                hiveInfo.Cleanness,
                hiveInfo.Larvae,
                hiveInfo.Status,
                hiveInfo.Timestamp
            };
        }

        public void InsertHivesData(List<SensorsDataModel> model) {

            foreach(SensorsDataModel hiveData in model)
            {
                Hive newHive = new Hive
                {
                    ApiaryId = hiveData.ApiaryId,
                    GUID = hiveData.GUID
                };
                _dbEntities.Hives.Add(newHive);
            }
            _dbEntities.SaveChanges();
        }

        public void SaveSensorsData(List<SensorsDataModel> model)
        {

            foreach (SensorsDataModel hiveData in model)
            {
                var hive = _dbEntities.Hives.FirstOrDefault(f => f.GUID == hiveData.GUID);
                SensorData newSensorInfo = new SensorData
                {
                    HiveId = hive.Id,
                    Humidity = hiveData.Humidity,
                    Light = hiveData.Light,
                    Temperature = hiveData.Temperature,
                    Weight = hiveData.Weight,
                    Timestamp = hiveData.Timestamp
                };
                _dbEntities.SensorDatas.Add(newSensorInfo);
            }
            _dbEntities.SaveChanges();
        }


    }
}
