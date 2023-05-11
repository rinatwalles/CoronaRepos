using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaEmployeesInfo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoronaDetailsController : ControllerBase
    {
        private readonly CoronaContext _coronaContext;

        public CoronaDetailsController(CoronaContext coronaContext)
        {
            _coronaContext = coronaContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CoronaDetails>> Get()
        {
            return _coronaContext.CoronaDetails.ToArray();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{employeeId}")]
        public ActionResult<CoronaDetails> Get(string employeeId)
        {
            var info = _coronaContext.CoronaDetails.FirstOrDefault(x => x.EmployeeId == employeeId);
            return info is null ? new NotFoundResult() : Ok(info);
        }

        // POST api/<EmployeeController>
        [HttpPost("{emplyeeId}")]
        public async Task<ActionResult<CoronaDetails>> Post(string emplyeeId, [FromBody] CoronaDetails coronaDetails)
        {
            if (_coronaContext.CoronaDetails.Count(x => x.EmployeeId == emplyeeId) == 1)
                return BadRequest("Employee has been infected already");
            coronaDetails.EmployeeId = emplyeeId;
            coronaDetails.Employee = default!;

            await _coronaContext.CoronaDetails.AddAsync(coronaDetails);
            await _coronaContext.SaveChangesAsync();
            return Ok(coronaDetails);
        }
    }
}
