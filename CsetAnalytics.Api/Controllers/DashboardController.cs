using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CsetAnalytics.DomainModels;
using CsetAnalytics.Interfaces.Dashboard;
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
        private readonly IDashboardBusiness _dashboardBusiness;
        private readonly CsetContext context;
        
        

        public DashboardController(IConfiguration config, IDashboardBusiness dashboardBusiness, CsetContext context)
        {   
            this.config = config;
            this._dashboardBusiness = dashboardBusiness;
            this.context = context;
        }


        [Authorize]
        [HttpGet]
        [Route("GetDashboardChart")]
        public async Task<IActionResult> GetDashBoardChart()
        {
            //TODO Flush out the controller to get the dependency injected viewmodel
            //create it from the factory and interface and 
            //IRON OUT the TASK vs ACTIONRESULT to return the object.

            try
            {
                var sectionAnalytics = await _dashboardBusiness.GetSectionAnalytics(string.Empty);
                var industryAnalytics = await _dashboardBusiness.GetIndustryAnalytics(string.Empty);
                var myAnalytics = await _dashboardBusiness.GetMyAnalytics(0);
                List<Series> series = new List<Series>(); 
                series.Union(sectionAnalytics).Union(industryAnalytics).Union(myAnalytics);

                DashboardChartData dashboardChartData = new DashboardChartData
                {
                    name = string.Empty,
                    series = series
                    
                };

                //this.context.AnalyticQuestions.Where(x => x.Assessment_Id == 0);
                return Ok(dashboardChartData);
            }
            catch (Exception ex)
            {
                //return ex.Message;
                return null;
            }
        }
    }
}
