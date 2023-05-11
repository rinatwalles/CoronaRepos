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

        //[HttpGet("GetSickPeoplePerDay")]
        //public ActionResult<IDictionary<string, int>> GetSickPeoplePerDay()
        //{
        //    DateTime now = DateTime.Now;
        //    var z = _coronaContext.Employees
        //        .Include(x => x.CoronaDetails)
        //        .Where(x => x.CoronaDetails != null
        //                    && x.CoronaDetails.Any(cd => cd.InfectionDate!.Value.Month == now.Month
        //                    && cd.InfectionDate.Value.Year == now.Year)).ToArray();
        //    return _coronaContext.Employees
        //        .Include(x => x.CoronaDetails)
        //        .Where(x => x.CoronaDetails != null
        //                    && x.CoronaDetails.Any(cd => cd.InfectionDate!.Value.Month == now.Month
        //                    && cd.InfectionDate.Value.Year == now.Year))
        //        .GroupBy(x => x.CoronaDetails!.InfectionDate!.Value)
        //        .ToDictionary(
        //        k => k.Key.ToShortDateString(),
        //        v => v.Select(x => x.Id).Distinct().Count());
        //}
    }
}
