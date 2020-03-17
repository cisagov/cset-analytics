using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;
using CsetAnalytics.ViewModels.Dashboard;

namespace CsetAnalytics.Interfaces.Dashboard
{
    public interface IDashboardBusiness
    {
        Task<List<Series>> GetSectionAnalytics(string section);
        Task<List<Series>> GetIndustryAnalytics(string industry);
        Task<List<Series>> GetMyAnalytics(int assessmentId);
    }
}
