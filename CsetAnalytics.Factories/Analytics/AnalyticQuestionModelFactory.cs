using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CsetAnalytics.DomainModels.Models;
using CsetAnalytics.Interfaces.Factories;
using CsetAnalytics.ViewModels;

namespace CsetAnalytics.Factories.Analytics
{
    public class AnalyticQuestionModelFactory : IBaseFactoryAsync<AnalyticQuestionViewModel, AnalyticQuestion>
    {
        private readonly IMapper _mapper;

        public AnalyticQuestionModelFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<AnalyticQuestion> CreateAsync(AnalyticQuestionViewModel question)
        {
            return _mapper.Map<AnalyticQuestion>(question);
        }

        public async Task<IQueryable<AnalyticQuestion>> CreateAsync(IQueryable<AnalyticQuestionViewModel> questions)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AnalyticQuestionViewModel, AnalyticQuestion >()
                .ForMember(x => x.AnalyticDemographicId, opt => opt.Ignore())
                .ForMember(x => x.AnalyticDemographic, opt => opt.Ignore()));
            return questions.ProjectTo<AnalyticQuestion>(config);
        }
    }
}
