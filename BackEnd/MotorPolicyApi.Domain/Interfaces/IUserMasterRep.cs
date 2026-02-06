using MotorPolicyApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorPolicyApi.Domain.Interfaces
{
    public interface IUserMasterRep
    {
        public Task<int> SaveUser(UserMaster userMaster);
        public Task<string> GetUser(string userId, string password);
    }
}
