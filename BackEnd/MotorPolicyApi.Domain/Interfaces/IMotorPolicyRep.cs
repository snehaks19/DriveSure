using MotorPolicyApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorPolicyApi.Domain.Interfaces
{
    public interface IMotorPolicyRep
    {
        Task<int> SavePolicy(MotorPolicy entity);
        Task UpdatePolicy(MotorPolicy entity);
        Task ApprovePolicy(MotorPolicy entity);
        Task DeletePolicy(int polUid);
        Task<MotorPolicy> GetPolicy(int polUid);
        Task<List<MotorPolicy>> GetAllPolicies();
    }
}
