using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaEmployeesInfo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonusController : ControllerBase
    {
        private readonly CoronaContext _coronaContext;

        public BonusController(CoronaContext coronaContext)
        {
            _coronaContext = coronaContext;
        }

        [HttpGet("GetNotVaccinated")]
        public ActionResult<IEnumerable<Employee>> GetNotVaccinated()
        {
            return _coronaContext.Employees
                .Include(x => x.VaccineInfos)
                .Where(x => x.VaccineInfos == null || !x.VaccineInfos.Any())
                .ToArray();
        }

    }
}
