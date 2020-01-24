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
    public class AnalyticDemographicModelFactory : IBaseFactoryAsync<AnalyticDemographicViewModel, AnalyticDemographic>
    {
        private readonly IMapper _mapper;

        public AnalyticDemographicModelFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<AnalyticDemographic> CreateAsync(AnalyticDemographicViewModel model)
        {
            return _mapper.Map<AnalyticDemographic>(model);
        }

        public async Task<IQueryable<AnalyticDemographic>> CreateAsync(IQueryable<AnalyticDemographicViewModel> models)
        {
            var config = new MapperConfiguration(cfg => cfg.DisableConstructorMapping());
            return models.ProjectTo<AnalyticDemographic>(config);
        }
    }
}
