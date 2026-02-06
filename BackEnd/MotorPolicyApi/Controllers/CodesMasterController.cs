using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorPolicyApi.Core.Interfaces;
using MotorPolicyApi.Domain.Entities;

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

        // GET: api/CodesMaster
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var data = await _ICodesMasterService.GetAllAsync();
        //    return Ok(data);
        //}


        //private readonly ILogger<CodesMasterController> _logger;
        //private readonly IConfiguration _configuration;
        //private readonly ICodesMasterService _ICodesMasterService;
        //public CodesMasterController(ILogger<CodesMasterController> logger, IConfiguration configuration, ICodesMasterService ICodesMasterService)
        //{
        //    _logger = logger;
        //    _configuration = configuration;
        //    _ICodesMasterService = ICodesMasterService;
        //}


        //[HttpGet]
        //[Route("{ccType}/{ccCode}/{compCode}")]
        //public async Task<ActionResult<Codes>> GetCodesMaster(string ccType, string ccCode, string compCode)
        //{
        //    try
        //    {
        //        Codes objCodes = await _ICodesMasterService.GetCodesMaster(ccType, ccCode, compCode);
        //        if (objCodes == null)
        //            return NotFound();
        //        return Ok(objCodes);
        //    }
        //    catch (Exception ex)
        //    {

        //        LoggerHelper.WriteToLogException("CodesMasterController.GetCodesMaster", ex);
        //        _logger.LogError(ex, string.Empty);
        //        return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetchig of Codes");
        //    }
        //}

    }
}
