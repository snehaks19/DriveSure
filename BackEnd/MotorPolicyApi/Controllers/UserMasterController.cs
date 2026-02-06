using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MotorPolicyApi.Core.Dtos;
using MotorPolicyApi.Core.Interfaces;

namespace MotorPolicyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMasterController : ControllerBase
    {
        private readonly IUserMasterService _service;
        public UserMasterController(IUserMasterService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser(UserMasterDto userdto)
        {
            await _service.SaveUser(userdto);
            return Ok("User Saved Successfully");
        }
        [HttpGet]
        public async Task<IActionResult> GetUser(string userId, string password)
        {
            var result = await _service.GetUser(userId, password);
            if (result == null)
                return Unauthorized("Invalid login");

            return Ok(new { userType = result });
        }
    }   
}
