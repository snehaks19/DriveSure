using MotorPolicyApi.Core.Dtos;
using MotorPolicyApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorPolicyApi.Core.Interfaces
{
    public interface IMotorPolicyService
    {
        Task<int> SavePolicy(MotorPolicyDto policy);
        Task ApprovePolicy(MotorPolicyDto policy);
        Task UpdatePolicy(MotorPolicyDto policy);
        Task DeletePolicy(int polUid);
        Task<MotorPolicy> GetPolicy(int policyId);
    }
}
