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
    public class AnalyticDemographicViewModelFactory : IBaseFactory<AnalyticDemographic, AnalyticDemographicViewModel>
    {
        private readonly IMapper _mapper;

        public AnalyticDemographicViewModelFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public AnalyticDemographicViewModel Create(AnalyticDemographic demographic)
        {
            return _mapper.Map<AnalyticDemographicViewModel>(demographic);
        }

        public IQueryable<AnalyticDemographicViewModel> Create(IQueryable<AnalyticDemographic> demographics)
        {
            var config = new MapperConfiguration(cfg => cfg.DisableConstructorMapping());
            return demographics.ProjectTo<AnalyticDemographicViewModel>(config);
        }
    }
}
