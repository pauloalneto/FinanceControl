using Common.Domain.Enum;
using FinanceControl.Application.Interfaces;
using FinanceControl.Domain.Filter;
using FinanceControl.Domain.Interface.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplicationService app;
        private readonly IUserRepository rep;

        public UserController(IUserApplicationService app, IUserRepository rep)
        {
            this.app = app;
            this.rep = rep;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] UserFilter filters)
        {
            if (filters.FilterBehavior == EFilterBehavior.GetDataCustom)
            {
                var dataCustom = await this.rep.GetDataCustom(filters);

                var ob = new ObjectResult(dataCustom)
                {
                    StatusCode = 200,
                    Value = dataCustom
                };

                return ob;
            }

            var result = await this.app.GetByFilters(filters);

            if (!result.Any())
            {
                return NotFound();
            }

            return new ObjectResult(result);
        }
    }
}
