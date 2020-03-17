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

        public async Task<List<Series>> GetSectionAnalytics(string section)
        {
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
