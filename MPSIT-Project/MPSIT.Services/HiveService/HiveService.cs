using MPSIT.Data.Database;
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

        public object getHives() {
            var hives = _dbEntities.Tests.FirstOrDefault(f=>f.Id == 1);

            return new
            {
                hives.Name
            };
        }
    }
}
