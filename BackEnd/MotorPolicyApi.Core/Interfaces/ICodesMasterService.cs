using MotorPolicyApi.Core.Dtos;
using MotorPolicyApi.Domain.Entities;
using MotorPolicyApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorPolicyApi.Core.Interfaces
{
    public interface ICodesMasterService
    {
        Task<List<DropDownDto>> GetDropDown(string type);
        Task<List<DropDownDto>> GetDropDown(string type, string parent);
    }
}
