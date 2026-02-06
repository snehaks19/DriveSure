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
                PolUid = dto.PolUid,
                PolNo = dto.PolNo,
                PolFmDt = dto.PolFmDt,
                PolToDt = dto.PolToDt,
                PolAssrName = dto.PolAssrName,
                PolAssrMobile = dto.PolAssrMobile,
                PolVehMake = dto.PolVehMake,
                PolVehModel = dto.PolVehModel,
                PolVehRegnNo = dto.PolVehRegnNo,
                PolVehValue = dto.PolVehValue,
                PolGrossLcPrem = dto.PolGrossLcPrem,

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
            var entity = await _motorPolicyRep.GetPolicy(dto.PolUid)
                ?? throw new Exception("Policy not found");


            entity.PolAssrName = dto.PolAssrName;
            entity.PolAssrMobile = dto.PolAssrMobile;
            entity.PolVehValue = dto.PolVehValue;
            entity.PolGrossLcPrem = dto.PolGrossLcPrem;

            entity.PolUpBy = "SNEHA";
            entity.PolUpDt = DateTime.Now;

            await _motorPolicyRep.UpdatePolicy(entity);
        }

        // APPROVE
        public async Task ApprovePolicy(MotorPolicyDto policy)
        {
            var entity = await _motorPolicyRep.GetPolicy(policy.PolUid)
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
