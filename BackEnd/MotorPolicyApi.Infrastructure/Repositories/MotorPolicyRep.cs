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
    public class MotorPolicyRep: IMotorPolicyRep
    {
        private readonly MotorPolicyDbContext _dbContext;
        public MotorPolicyRep(MotorPolicyDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<int> SavePolicy(MotorPolicy entity)
        {
            await _dbContext.MotorPolicies.AddAsync(entity);
            var rows=await _dbContext.SaveChangesAsync();
            return rows;
        }
        public async Task UpdatePolicy(MotorPolicy entity)
        {
             _dbContext.MotorPolicies.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<MotorPolicy> GetPolicy(int polUid)
        {
            var data= await _dbContext.MotorPolicies
                .FirstOrDefaultAsync(p => p.PolUid == polUid);
            return data;
        }

        public async Task ApprovePolicy(MotorPolicy entity)
        {
            _dbContext.MotorPolicies.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeletePolicy(int polUid)
        {
            var entity = await _dbContext.MotorPolicies
        .FirstOrDefaultAsync(p => p.PolUid == polUid);

            if (entity == null)
                throw new Exception("Policy not found");

            _dbContext.MotorPolicies.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
