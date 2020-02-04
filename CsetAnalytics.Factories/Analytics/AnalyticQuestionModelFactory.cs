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
    public class AnalyticQuestionModelFactory : IBaseFactory<AnalyticQuestionViewModel, AnalyticQuestion>
    {
        private readonly IMapper _mapper;

        public AnalyticQuestionModelFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public AnalyticQuestion Create(AnalyticQuestionViewModel question)
        {
            return _mapper.Map<AnalyticQuestion>(question);
        }

        public IQueryable<AnalyticQuestion> Create(IQueryable<AnalyticQuestionViewModel> questions)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AnalyticQuestionViewModel, AnalyticQuestion>());
            return questions.ProjectTo<AnalyticQuestion>(config);
        }
    }
}
