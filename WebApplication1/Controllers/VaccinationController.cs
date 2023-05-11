using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaEmployeesInfo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationController : ControllerBase
    {
        private readonly CoronaContext _coronaContext;

        public VaccinationController(CoronaContext coronaContext)
        {
            _coronaContext = coronaContext;
        }

        [HttpGet("{emplyeeId}")]
        public ActionResult<IEnumerable<VaccineInfo>> Get(string emplyeeId)
        {
            return _coronaContext.Employees
                .Include(x => x!.VaccineInfos)
                .Where(x => x.Id == emplyeeId)
                .SelectMany(x => x.VaccineInfos!)
                .ToArray();
        }

        // GET api/<EmployeeController>/5
        //[HttpGet("{vaccineInfoId}")]
        //public ActionResult<VaccineInfo> Get(int vaccineInfoId)
        //{
        //    var info = _coronaContext.VaccinesInfo.FirstOrDefault(x => x.Id == vaccineInfoId);
        //    return info is null ? new NotFoundResult() : Ok(info);
        //}

        // POST api/<EmployeeController>
        [HttpPost("{emplyeeId}")]
        public async Task<ActionResult<VaccineInfo>> Post(string emplyeeId, [FromBody] VaccineInfo vaccineInfo)
        {
            if (_coronaContext.VaccinesInfo.Count(x => x.EmployeeId == emplyeeId) == 4)
                return BadRequest("Employee was already four times vaccinated");
            vaccineInfo.EmployeeId = emplyeeId;
            vaccineInfo.Employee = default!;
            var employee = _coronaContext.Employees.FirstOrDefault(x => x.Id == emplyeeId);
            //employee.VaccineInfos.Add(vaccineInfo);
            await _coronaContext.VaccinesInfo.AddAsync(vaccineInfo);
            await _coronaContext.SaveChangesAsync();
            return Ok(vaccineInfo);
        }
    }
}
