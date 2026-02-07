using MotorPolicyApi.Core.Dtos;
using MotorPolicyApi.Core.Interfaces;
using MotorPolicyApi.Domain.Entities;
using MotorPolicyApi.Domain.Interfaces;
using MotorPolicyApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorPolicyApi.Core.Services
{
    public class CodesMasterService: ICodesMasterService
    {
        private readonly ICodesMasterRep _repository;

        public CodesMasterService(ICodesMasterRep repository)
        {
            _repository = repository;
        }

        public async Task<List<DropDownDto>> GetDropDown(string type)
        {
            return await _repository.GetDropDown(type);
        }
        public async Task<List<DropDownDto>> GetDropDown(string type, string parent)
        {
            return await _repository.GetDropDown(type, parent);
        }
    }
}
