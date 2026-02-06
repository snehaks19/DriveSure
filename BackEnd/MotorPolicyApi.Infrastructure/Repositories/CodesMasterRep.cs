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
    public  class CodesMasterRep: ICodesMasterRep
    {
        private readonly MotorPolicyDbContext _context;

        public CodesMasterRep(MotorPolicyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CodesMaster>> GetAllAsync()
        {
            try
            {
                var data = await _context.CodesMasters.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
