using MotorPolicyApi.Core.Dtos;
using MotorPolicyApi.Core.Interfaces;
using MotorPolicyApi.Domain.Entities;
using MotorPolicyApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorPolicyApi.Core.Services
{
    public class UserMasterService: IUserMasterService
    {
        private readonly IUserMasterRep _userMasterRep;
        public UserMasterService(IUserMasterRep userMasterRep)
        {
            _userMasterRep = userMasterRep;
        }
        public async Task<int> SaveUser(UserMasterDto dto)
        {
            var entity = new UserMaster
            {
                UserId= dto.Id,
                UserName= dto.Name,
            };

            int rows=await _userMasterRep.SaveUser(entity);
            return rows;
        }

        public async Task<string> GetUser(string userId, string password)
        {
           
            string usertype = await _userMasterRep.GetUser(userId, password);
            return usertype;
        }
    }
}
