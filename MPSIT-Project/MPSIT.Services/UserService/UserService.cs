using MPSIT.Data.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MPSIT.Services.UserService
{
    public class UserService
    {
        private Entities _dbEntities;
        private HiveService.HiveService _hiveService;

        public UserService()
        {
            _dbEntities = new Entities();
            _hiveService = new HiveService.HiveService();
        }

        public object GetUserProfile(string userId)
        {
            AspNetUser userProfile = _dbEntities.AspNetUsers.FirstOrDefault(f => f.Id == userId);

            return new
            {
                userProfile.Email,
                userProfile.UserName
            };
        }

        public void SendReport(string userId)
        {
            AspNetUser user = _dbEntities.AspNetUsers.FirstOrDefault(f => f.Id == userId);

            #region SendEmail
            var today = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            MailMessage mail = new MailMessage("event.report.office@gmail.com", user.Email);
            mail.Subject = "[Beehive Monitor] Report of " + today.ToString();
            mail.Body = "Below you can find the beehives that need your attention:<br/>";

            IEnumerable<Apiary> allApiaries = _dbEntities.Apiaries.Where(f => f.UserId == userId).ToList();
            foreach (Apiary apiary in allApiaries)
            {
                IEnumerable<Hive> allHives = apiary.Hives;
                List<object> hives = new List<object>();
                var temperature = "Too low or too high temperature: ";
                var humidity = "Too low or too high humidity: ";
                var weight = "Over normal weight: ";
                var status = "Status: ";

                foreach (Hive hive in allHives)
                {
                    SensorData lastSensorData = hive.SensorDatas.OrderByDescending(f => f.Timestamp).FirstOrDefault();
                    
                    if (lastSensorData.Humidity < 30 || lastSensorData.Humidity > 70)
                        humidity += "<a style='color: black' href='http://localhost:2276/#/hive/" + hive.Id + "' targer='_blank'>Hive_" + hive.Id + "</a> (<span style='color: red'>" + lastSensorData.Humidity + "%</span>), ";
                    if (lastSensorData.Temperature > 30)
                        temperature += "<a style='color: black' href='http://localhost:2276/#/hive/" + hive.Id + "' targer='_blank'>Hive_" + hive.Id + "</a> (<span style='color: red'>" + lastSensorData.Temperature + "&#8451;)</span>, ";
                    if (lastSensorData.Temperature < 5)
                        temperature += "<a style='color: black' href='http://localhost:2276/#/hive/" + hive.Id + "' targer='_blank'>Hive_" + hive.Id + "</a> (<span style='color: deepskyblue'>" + lastSensorData.Temperature + "&#8451;)</span>, ";
                    if (lastSensorData.Weight > 25)
                        weight += "<a style='color: black' href='http://localhost:2276/#/hive/" + hive.Id + "' targer='_blank'>Hive_" + hive.Id + "</a> (<span style='color: green'>" + lastSensorData.Weight.ToString("####0.00") + "kg</span>), ";

                    var hiveInfo = _dbEntities.HiveInfoes.OrderByDescending(f => f.Timestamp).FirstOrDefault(f => f.HiveId == hive.Id);
                    if (hiveInfo != null)
                        if (hiveInfo.Status == "Weak")
                            status += "<a style='color: black' href='http://localhost:2276/#/hive/" + hive.Id + "' targer='_blank'>Hive_" + hive.Id + "</a> (<span style='color: deepskyblue'>" + hiveInfo.Status + "</span>), ";
                    else if (hiveInfo.Status == "Sick")
                        status += "<a style='color: black' href='http://localhost:2276/#/hive/" + hive.Id + "' targer='_blank'>Hive_" + hive.Id + "</a> (<span style='color: red'>" + hiveInfo.Status + "</span>), ";
                }

                mail.Body += "<h4><a style='color: black' href='http://localhost:2276/#/apiary/" + apiary.Id + "' targer='_blank'>Apiary_" + apiary.Id + "</a></h4><br/><ul><li>" + temperature + " </li><li> " + humidity + " </li><li> " + weight + " </li><li> " + status + "</li></ul></br>";
            }

            mail.IsBodyHtml = true;
            SmtpClient client = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                Credentials = new System.Net.NetworkCredential("event.report.office@gmail.com", "Start1234.")
            };

            client.Send(mail);
            #endregion
        }
    }
}
