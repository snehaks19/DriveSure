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
    public class MotorPolicyService : IMotorPolicyService
    {
        private readonly IMotorPolicyRep _motorPolicyRep;
        public MotorPolicyService(IMotorPolicyRep motorPolicyRep)
        {
            _motorPolicyRep = motorPolicyRep;
        }
        public async Task<int> SavePolicy(MotorPolicyDto dto)
        {
            var entity = new MotorPolicy
            {
                PolNo = dto.polNo,
                PolFmDt = dto.fromDate,
                PolToDt = dto.toDate,
                PolAssrName = dto.name,
                PolAssrMobile = dto.mobile,
                PolVehMake = dto.vehMake,
                PolVehModel = dto.vehModel,
                PolVehRegnNo = dto.regNo,
                PolVehValue = dto.vehValue,
                PolGrossFcPrem = dto.fcPremium,
                PolGrossLcPrem = dto.lcPremium,

                // system-controlled fields
                PolApprStatus = "N",
                PolCrBy = "SNEHA",
                PolCrDt = DateTime.Now

            };

            await _motorPolicyRep.SavePolicy(entity);
            return entity.PolUid;
        }
        public async Task UpdatePolicy(MotorPolicyDto dto)
        {
            var entity = await _motorPolicyRep.GetPolicy(dto.polUid)
                ?? throw new Exception("Policy not found");


            entity.PolAssrName = dto.name;
            entity.PolAssrMobile = dto.mobile;
            entity.PolVehValue = dto.vehValue;
            entity.PolGrossLcPrem = dto.lcPremium;

            entity.PolUpBy = "SNEHA";
            entity.PolUpDt = DateTime.Now;

            await _motorPolicyRep.UpdatePolicy(entity);
        }

        // APPROVE
        public async Task ApprovePolicy(MotorPolicyDto policy)
        {
            var entity = await _motorPolicyRep.GetPolicy(policy.polUid)
                ?? throw new Exception("Policy not found");

            if (entity.PolApprStatus != "N")
                throw new Exception("Policy already processed");

            entity.PolApprStatus = "A";
            entity.PolApprBy = "sneha";
            entity.PolApprDt = DateTime.Now;

            await _motorPolicyRep.ApprovePolicy(entity);
        }

        // DELETE (SOFT DELETE)
        public async Task DeletePolicy(int polUid)
        {
            var entity = await _motorPolicyRep.GetPolicy(polUid)
                ?? throw new Exception("Policy not found");

            entity.PolApprStatus = "C"; // Cancelled
            entity.PolUpBy = "SYSTEM";
            entity.PolUpDt = DateTime.Now;

            await _motorPolicyRep.DeletePolicy(polUid);
        }
        public async Task<MotorPolicy> GetPolicy(int polUid)
        {
            var entity = await _motorPolicyRep.GetPolicy(polUid);
            return entity;
        }
    }
}
