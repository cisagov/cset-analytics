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
        Task<DashboardChartData> GetAverages(int assessment_id);
    }
}
