using FinanceControl.Application.Interfaces;
using FinanceControl.Dto.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FinanceControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlagController : ControllerBase
    {
        private readonly IFlagApplicationService app;

        public FlagController(IFlagApplicationService app)
        {
            this.app = app;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.app.GetByFilters();

            if (!result.Any())
            {
                return NotFound();
            }

            return new ObjectResult(result);
        }
    }
}
