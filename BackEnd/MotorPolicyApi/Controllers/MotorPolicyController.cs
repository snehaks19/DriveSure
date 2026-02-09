using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorPolicyApi.Core.Dtos;
using MotorPolicyApi.Core.Interfaces;

namespace MotorPolicyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorPolicyController : ControllerBase
    {
        private readonly IMotorPolicyService _service;
        public MotorPolicyController(IMotorPolicyService service)
        {
            _service = service;
        }

        [HttpGet("main-list")]
        public async Task<IActionResult> GetPolicies()
        {
            var data = await _service.GetAllPolicies();
            return Ok(data);
        }


        [HttpPost]
        public async Task<IActionResult> SavePolicy(MotorPolicyDto policy)
        {
            Console.WriteLine("POST API HIT ✅");
            await _service.SavePolicy(policy);
            return Ok("Policy Saved Successfully");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePolicy(MotorPolicyDto policy)
        {
            await _service.UpdatePolicy(policy);
            return Ok("Policy Updated Successfully");
        }
        //[HttpPut]
        //[Route("{id}/approve")]
        //public async Task<IActionResult> ApprovePolicy(MotorPolicyDto policy)
        //{
        //    await _service.ApprovePolicy(policy);
        //    return Ok("Policy Updated Successfully");
        //}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePolicy(int polUid)
        {
            await _service.DeletePolicy(polUid);
            return Ok("Policy Deleted Successfully");
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPolicy(int id)
        {
            var data=await _service.GetPolicy(id);
            return Ok(data);
        }
    }
}   
