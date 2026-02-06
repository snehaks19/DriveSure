using MotorPolicyApi.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorPolicyApi.Core.Interfaces
{
    public interface IUserMasterService
    {
        Task<int> SaveUser(UserMasterDto dto);
        Task<string> GetUser(string userId, string password);
    }
}
