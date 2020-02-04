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
using Microsoft.EntityFrameworkCore;

namespace CsetAnalytics.Factories.Analytics
{
    public class AnalyticDemographicModelFactory : IBaseFactory<AnalyticDemographicViewModel, AnalyticDemographic>
    {
        private readonly IMapper _mapper;

        public AnalyticDemographicModelFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public AnalyticDemographic Create(AnalyticDemographicViewModel model)
        {
            return _mapper.Map<AnalyticDemographic>(model);
        }

        public IQueryable<AnalyticDemographic> Create(IQueryable<AnalyticDemographicViewModel> models)
        {
            var config = new MapperConfiguration(cfg => cfg.DisableConstructorMapping());
            return models.ProjectTo<AnalyticDemographic>(config);
        }
    }
}
