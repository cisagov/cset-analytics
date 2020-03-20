using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsetAnalytics.ViewModels
{
    public class AnalyticsViewModel
    {
        public AnalyticDemographicViewModel Demographics { get; set; }
        public List<AnalyticQuestionViewModel> QuestionAnswers { get; set; }
        public AnalyticAssessmentViewModel Assessment { get; set; }
     
    }
}
