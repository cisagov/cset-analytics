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
    public class AnalyticQuestionViewModelFactory : IBaseFactory<AnalyticQuestion, AnalyticQuestionViewModel>
    {
        private readonly IMapper _mapper;

        public AnalyticQuestionViewModelFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public AnalyticQuestionViewModel Create(AnalyticQuestion question)
        {
            return _mapper.Map<AnalyticQuestionViewModel>(question);
        }

        public IQueryable<AnalyticQuestionViewModel> Create(IQueryable<AnalyticQuestion> questions)
        {
            var config = new MapperConfiguration(cfg => cfg.DisableConstructorMapping());
            return questions.ProjectTo<AnalyticQuestionViewModel>(config);
        }
    }
}
