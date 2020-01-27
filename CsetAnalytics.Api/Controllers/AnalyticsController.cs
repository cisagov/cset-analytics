using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsetAnalytics.Api.ViewModels;
using CsetAnalytics.Business.Analytics;
using CsetAnalytics.DomainModels;
using CsetAnalytics.DomainModels.Models;
using CsetAnalytics.Factories.Analytics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CsetAnalytics.ViewModels;
using CsetAnalytics.Interfaces.Analytics;
using CsetAnalytics.Interfaces.Factories;

namespace CsetAnalytics.Api.Controllers
{
    [Route("api/Analytics")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly IBaseFactoryAsync<AnalyticDemographicViewModel, AnalyticDemographic> _demographicViewModelFactory;
        private readonly IBaseFactoryAsync<AnalyticQuestionViewModel, AnalyticQuestion> _questionViewModelFactory;
        private readonly IAnalyticBusiness _analyticsBusiness;

        public AnalyticsController(IBaseFactoryAsync<AnalyticDemographicViewModel, AnalyticDemographic> demographicViewModelFactory,
            IBaseFactoryAsync<AnalyticQuestionViewModel, AnalyticQuestion> questionViewModelFactory, IAnalyticBusiness analyticsBusiness)
        {
            _demographicViewModelFactory = demographicViewModelFactory;
            _questionViewModelFactory = questionViewModelFactory;
            _analyticsBusiness = analyticsBusiness;
        }

        [HttpPost]
        [Route("postAnalyticsAnonymously")]
        public async Task<IActionResult> PostAnalyticsAnonymously([FromBody]AnalyticsViewModel analytics)
        {
            try
            {
                AnalyticDemographic demographic = await _demographicViewModelFactory.CreateAsync(analytics.Demographics);
                AnalyticDemographic rDemographic = await _analyticsBusiness.SaveAnalyticDemographic(demographic);

                List<AnalyticQuestion> questions =
                    (await _questionViewModelFactory.CreateAsync(analytics.QuestionAnswers.AsQueryable())).ToList();
                questions.ForEach(x=>x.AnalyticDemographicId = rDemographic.AnalyticDemographicId);
                await _analyticsBusiness.SaveAnalyticQuestions(questions);
                return Ok(new {message="Analytics data saved"});
            }
            catch (Exception ex)
            {
                return BadRequest($"Analytic information was not saved: {ex.Message}");
            }
        }
    }
}