using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CsetAnalytics.DomainModels.Models;

namespace CsetAnalytics.Interfaces.Analytics
{
    public interface IAnalyticBusiness
    {
        Task<AnalyticDemographic> SaveAnalyticDemographic(AnalyticDemographic demographic);
        Task SaveAnalyticQuestions(List<AnalyticQuestion> questions);
    }
}
