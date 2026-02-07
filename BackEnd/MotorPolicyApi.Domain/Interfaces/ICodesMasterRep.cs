using MotorPolicyApi.Domain.Entities;
using MotorPolicyApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MotorPolicyApi.Domain.Interfaces
{
    public interface ICodesMasterRep
    {
        //Task<IEnumerable<CodesMaster>> GetAllAsync();

        Task<List<DropDownDto>> GetDropDown(string type);
        Task<List<DropDownDto>> GetDropDown(string type, string parent);

    }
}
