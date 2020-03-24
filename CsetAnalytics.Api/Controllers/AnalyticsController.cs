using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CsetAnalytics.DomainModels.Models;
using Microsoft.AspNetCore.Mvc;
using CsetAnalytics.ViewModels;
using CsetAnalytics.Interfaces.Analytics;
using CsetAnalytics.Interfaces.Factories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CsetAnalytics.Api.Controllers
{
    [Route("api/Analytics")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly IBaseFactory<AnalyticDemographicViewModel, AnalyticDemographic> _demographicViewModelFactory;
        private readonly IBaseFactory<AnalyticQuestionViewModel, AnalyticQuestion> _questionViewModelFactory;
        private readonly IAnalyticBusiness _analyticsBusiness;

        public AnalyticsController(IBaseFactory<AnalyticDemographicViewModel, AnalyticDemographic> demographicViewModelFactory,
            IBaseFactory<AnalyticQuestionViewModel, AnalyticQuestion> questionViewModelFactory, IAnalyticBusiness analyticsBusiness )
        {
            _demographicViewModelFactory = demographicViewModelFactory;
            _questionViewModelFactory = questionViewModelFactory;
            _analyticsBusiness = analyticsBusiness;
        }

        [Authorize]
        [HttpPost]
        [Route("postAnalyticsAnonymously")]
        public async Task<IActionResult> PostAnalyticsAnonymously([FromBody]AnalyticsViewModel analytics)
        {
            try
            {
                AnalyticDemographic demographic = _demographicViewModelFactory.Create(analytics.Demographics);
                AnalyticDemographic rDemographic = await _analyticsBusiness.SaveAnalyticDemographic(demographic);

                List<AnalyticQuestion> questions =
                    (_questionViewModelFactory.Create(analytics.QuestionAnswers.AsQueryable())).ToList();
                questions.ForEach(x => x.AnalyticDemographicId = rDemographic.AnalyticDemographicId);
                await _analyticsBusiness.SaveAnalyticQuestions(questions);
                return Ok(new { message = "Analytics data saved" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Analytic information was not saved: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPost]
        [Route("postAnalytics")]
        public async Task<IActionResult> PostAnalytics([FromBody]AnalyticsViewModel analytics){
            try
            {
                string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                AnalyticDemographic demographic = _demographicViewModelFactory.Create(analytics.Demographics);
                demographic.AspNetUserId = userId;
                AnalyticDemographic rDemographic = await _analyticsBusiness.SaveAnalyticDemographic(demographic);

                List<AnalyticQuestion> questions =
                    (_questionViewModelFactory.Create(analytics.QuestionAnswers.AsQueryable())).ToList();
                questions.ForEach(x => x.AnalyticDemographicId = rDemographic.AnalyticDemographicId);
                await _analyticsBusiness.SaveAnalyticQuestions(questions);
                return Ok(new { message = "Analytics data saved" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Analytics information was not saved: {ex.Message}");
            }
        }
    }
}