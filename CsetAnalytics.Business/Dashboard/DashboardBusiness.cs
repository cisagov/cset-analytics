using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CsetAnalytics.DomainModels;
using CsetAnalytics.Interfaces.Dashboard;
using CsetAnalytics.ViewModels.Dashboard;

namespace CsetAnalytics.Business.Dashboard
{
    public class DashboardBusiness : IDashboardBusiness
    {
        private readonly CsetContext _context;

        public DashboardBusiness(CsetContext context)
        {
            _context = context;
        }

        public async Task<List<Series>> GetSectorAnalytics(string section)
        {
            /*
             select "Answer_Text", avg(Answer_Count) from
            (
            select a."Assessment_Id", q."Answer_Text", count(q."Answer_Text") Answer_Count from "Assessments" a
	            join "AnalyticDemographics" d on a."AnalyticDemographicId" = d."AnalyticDemographicId"
	            join "AnalyticQuestionAnswer" q on a."Assessment_Id" = q."Assessment_Id"
            where d."SectorId" = 1 
            group by a."Assessment_Id", q."Answer_Text") a
            group by "Answer_Text"
            */
            return null;
        }

        public async Task<List<Series>> GetIndustryAnalytics(string industry)
        {
            return null;
        }

        public async Task<List<Series>> GetMyAnalytics(string userId)
        {
            return null;
        }
    }
}
