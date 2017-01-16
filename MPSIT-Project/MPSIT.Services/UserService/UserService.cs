using MPSIT.Data.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPSIT.Services.UserService
{
    public class UserService
    {
        private Entities _dbEntities;

        public UserService()
        {
            _dbEntities = new Entities();
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
    }
}
