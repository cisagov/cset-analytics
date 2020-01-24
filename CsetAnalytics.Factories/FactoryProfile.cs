using System;
using System.Collections.Generic;
using AutoMapper;
using CsetAnalytics.DomainModels.Models;
using CsetAnalytics.ViewModels;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace CsetAnalytics.Factories
{
    public class FactoryProfile : Profile
    {
        public FactoryProfile()
        {
            RegisterMappings();
        }

        private void RegisterMappings()
        {
            CreateMap<AnalyticDemographic, AnalyticDemographicViewModel>();
            CreateMap<AnalyticQuestion, AnalyticQuestionViewModel>();
            CreateMap<AnalyticDemographicViewModel, AnalyticDemographic>();
            CreateMap<AnalyticQuestionViewModel, AnalyticQuestion>()
                .ForMember(x=>x.AnalyticDemographicId, opt=>opt.Ignore())
                .ForMember(x=>x.AnalyticDemographic, opt=>opt.Ignore());
           
        }
    }
}
