using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorPolicyApi.Core.Dtos;
using MotorPolicyApi.Core.Interfaces;
using MotorPolicyApi.Domain.Entities;
using MotorPolicyApi.Shared;

namespace MotorPolicyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodesMasterController : ControllerBase
    {

        private readonly ICodesMasterService _ICodesMasterService;

        public CodesMasterController(ICodesMasterService ICodesMasterService)
        {
            _ICodesMasterService = ICodesMasterService;
        }

        [HttpGet]
        [Route("{type}/list")]
        public async Task<ActionResult<CodesMaster>> GetDropdown(string type)
        {
            try
            {
                List<DropDownDto> list = await _ICodesMasterService.GetDropDown(type);
                if (list == null)
                    return NotFound();
                return Ok(list);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        [Route("{type}/{parent}/list")]
        public async Task<ActionResult<CodesMaster>> GetDropdown(string type,string parent)
        {
            try
            {
                List<DropDownDto> list = await _ICodesMasterService.GetDropDown(type, parent);
                if (list == null)
                    return NotFound();
                return Ok(list);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
