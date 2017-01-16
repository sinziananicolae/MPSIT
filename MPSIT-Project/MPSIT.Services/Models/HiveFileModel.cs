using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPSIT.Services.Models
{
    public class HiveFileModel
    {
        public int HiveId { get; set; }
        public int Id { get; set; }
        public string Health { get; set; }
        public string Food { get; set; }
        public string Cleanness { get; set; }
        public string Larvae { get; set; }
        public string Status { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
