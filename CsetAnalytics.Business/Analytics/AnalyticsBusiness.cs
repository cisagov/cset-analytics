using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CsetAnalytics.DomainModels;
using CsetAnalytics.DomainModels.Models;
using CsetAnalytics.Interfaces.Analytics;

namespace CsetAnalytics.Business.Analytics
{
    public class AnalyticsBusiness : IAnalyticBusiness
    {
        private readonly CsetContext _context;

        public AnalyticsBusiness(CsetContext context)
        {
            _context = context;
        }

        public async Task<Assessment> SaveAssessment(Assessment assessment)
        {
            _context.Assessments.Add(assessment);
            await _context.SaveChangesAsync();
            return assessment;
        }

        public async Task<AnalyticDemographic> SaveAnalyticDemographic(AnalyticDemographic demographic)
        {
            _context.AnalyticDemographics.Add(demographic);
            await _context.SaveChangesAsync();
            return demographic;
        }

        public async Task SaveAnalyticQuestions(List<AnalyticQuestionAnswer> questions)
        {
            await _context.AnalyticQuestions.AddRangeAsync(questions);
            await _context.SaveChangesAsync();
        }
    }
}
