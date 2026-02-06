using Microsoft.EntityFrameworkCore;
using MotorPolicyApi.Domain.Entities;
using MotorPolicyApi.Domain.Interfaces;
using MotorPolicyApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorPolicyApi.Infrastructure.Repositories
{
    public class UserMasterRep: IUserMasterRep
    {
        private readonly MotorPolicyDbContext _dbContext;
        public UserMasterRep(MotorPolicyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveUser(UserMaster entity)
        {
            await _dbContext.UserMasters.AddAsync(entity);
            var rows = await _dbContext.SaveChangesAsync();
            return rows;
        }

        public async Task<string> GetUser(string userId, string password)
        {
           var user = await _dbContext.UserMasters.FirstOrDefaultAsync(x=>x.UserId==userId && x.UserPassword==password);
            if (user == null) { return null; }
            else return user.UserType;  
        }
    }
}
