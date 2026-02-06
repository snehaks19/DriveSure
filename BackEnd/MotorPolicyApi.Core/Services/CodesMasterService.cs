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
    public class CodesMasterService: ICodesMasterService
    {
        private readonly ICodesMasterRep _repository;

        public CodesMasterService(ICodesMasterRep repository)
        {
            _repository = repository;
        }

        //public async Task<IEnumerable<CodesMaster>> GetAllAsync()
        //{
        //    // Business logic can come here later
        //    return await _repository.GetAllAsync();
        //}
    }
}
