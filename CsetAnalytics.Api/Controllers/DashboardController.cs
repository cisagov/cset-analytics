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
        public async Task<DashboardChartData> GetDashBoardChart()
        {
            //TODO Flush out the controller to get the dependency injected viewmodel
            //create it from the factory and interface and 
            //IRON OUT the TASK vs ACTIONRESULT to return the object.

            try
            {
                //this.context.AnalyticQuestions.Where(x => x.Assessment_Id == 0);
                return await Task.Run(() =>{ return new DashboardChartData();});                
            }
            catch (Exception ex)
            {
                //return ex.Message;
                return null;
            }
        }
    }
}
