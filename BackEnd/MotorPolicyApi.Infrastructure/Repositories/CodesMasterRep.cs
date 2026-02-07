using Microsoft.EntityFrameworkCore;
using MotorPolicyApi.Core.Dtos;
using MotorPolicyApi.Domain.Entities;
using MotorPolicyApi.Domain.Interfaces;
using MotorPolicyApi.Infrastructure.Data;
using MotorPolicyApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorPolicyApi.Infrastructure.Repositories
{
    public  class CodesMasterRep: ICodesMasterRep
    {
        private readonly MotorPolicyDbContext _context;

        public CodesMasterRep(MotorPolicyDbContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<CodesMaster>> GetAllAsync()
        //{
        //    try
        //    {
        //        var data = await _context.CodesMasters.ToListAsync();
        //        return data;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        
        public async Task<List<DropDownDto>> GetDropDown(string type)
        {
            try
            {
                return _context.CodesMasters
                .Where(x => x.CmType == type && x.CmActiveYn == "Y")
                .Select(x =>  new DropDownDto
                {
                    Code = x.CmCode,
                    Text = x.CmDesc
                })
                .ToList();
              
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<List<DropDownDto>> GetDropDown(string type, string parent)
        {
            try
            {
                return _context.CodesMasters
                .Where(x => x.CmType == type && x.CmParentCode==parent && x.CmActiveYn == "Y")
                .Select(x => new DropDownDto
                {
                    Code = x.CmCode,
                    Text = x.CmDesc
                })
                .ToList();


            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
