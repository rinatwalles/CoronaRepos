using Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaEmployeesInfo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly CoronaContext _coronaContext;
        public EmployeeController(CoronaContext coronaContext)
        {
            _coronaContext = coronaContext;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _coronaContext.Employees.ToArray();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{emplyeeId}")]
        public ActionResult<Employee> Get(string emplyeeId)
        {
            var employee = _coronaContext.Employees.FirstOrDefault(x => x.Id == emplyeeId);
            return employee is null ? new NotFoundResult() : Ok(employee);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Employee employee)
        {
            if (_coronaContext.Employees.Count(x => x.Id == employee.Id) == 1)
                return BadRequest("Employee already exists");
            await _coronaContext.Employees.AddAsync(employee);
            await _coronaContext.SaveChangesAsync();
            return Ok();
        }

    }
}
