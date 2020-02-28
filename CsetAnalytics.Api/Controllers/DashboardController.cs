using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CsetAnalytics.DomainModels;
using CsetAnalytics.ViewModels.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CsetAnalytics.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        
        private readonly IConfiguration config;
        private readonly CsetContext context;
        
        

        public DashboardController(IConfiguration config, CsetContext context)
        {   
            this.config = config;
            this.context = context;
        }


        [Authorize]
        [HttpGet]
        [Route("dashboardChart")]
        public async ActionResult<DashboardChartData> GetDashBoardChart()
        {
            try
            {
                
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Analytics information was not saved: {ex.Message}");
            }
        }
    }
}
}