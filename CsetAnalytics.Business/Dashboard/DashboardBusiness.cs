using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsetAnalytics.DomainModels;
using CsetAnalytics.DomainModels.Models;
using CsetAnalytics.Interfaces.Dashboard;
using CsetAnalytics.ViewModels.Dashboard;

namespace CsetAnalytics.Business.Dashboard
{
    public class DashboardBusiness : IDashboardBusiness
    {
        private readonly CsetContext _context;

        private const string IndustryAverageName = "Industry Average";
        private const string SectorAverageName = "Sector Average";
        private const string MyAssesmentAverageName = "Assessment Average";


        public DashboardBusiness(CsetContext context)
        {
            _context = context;
        }

        private List<Series> GetSectorAnalytics(int sector_id)
        {
            //performance on this is going to such and I'm going to end up 
            //wrapping it in a stored procedure some day but until then
            //here we go. 

            /*
            select a."Assessment_Id", q."Answer_Text", count(q."Answer_Text") Answer_Count from "Assessments" a
            join "AnalyticDemographics" d on a."AnalyticDemographicId" = d."AnalyticDemographicId"
            join "AnalyticQuestionAnswer" q on a."Assessment_Id" = q."Assessment_Id"
            where d."SectorId" = 15
            group by a."Assessment_Id", q."Answer_Text"
            */

            var query = from a in _context.Assessments
                        join d in _context.AnalyticDemographics on a.AnalyticDemographicId equals d.AnalyticDemographicId
                        join q in _context.AnalyticQuestionAnswers on a.Assessment_Id equals q.Assessment_Id
                        where d.SectorId == sector_id
            group new { q.Assessment_Id,q.Answer_Text } by new
            {
                q.Assessment_Id,
                q.Answer_Text
             } into g
            select new
            {
                g.Key.Assessment_Id,
                g.Key.Answer_Text,
                Count = g.Count()
            };



            //go through get the sum total of all
            //get the sum of yes and alts
            //then calc the percent of each assessment and 
            //sector average.

            Dictionary<int, QuickSum> sums = new Dictionary<int, QuickSum>();
            foreach(var a in query.ToList())
            {
                QuickSum quickSum;
                if(sums.TryGetValue(a.Assessment_Id,out quickSum))
                {
                    quickSum.TotalCount += a.Count;
                    if(a.Answer_Text == "Y" || a.Answer_Text == "A")
                    {
                        quickSum.YesAltCount += a.Count;
                    }                    
                }
                else
                {
                    int yaltCount = 0;
                    if (a.Answer_Text == "Y" || a.Answer_Text == "A")
                    {
                        yaltCount = a.Count;
                    }
                    sums.Add(a.Assessment_Id, new QuickSum() { assesment_id = a.Assessment_Id, TotalCount = a.Count, YesAltCount = yaltCount });

                }
            }

            //calculate the average percentage of all the assessments
            double average = 0;
            foreach(QuickSum s in sums.Values)
            {
                average += s.Percentage;
            }
            average = average / sums.Values.Count();

            return new List<Series>() { new Series() { name = SectorAverageName, value = average*100 } };
        }

        private List<Series> GetIndustryAnalytics(int sector_id, int industry_id)
        {
            var query = from a in _context.Assessments
                        join d in _context.AnalyticDemographics on a.AnalyticDemographicId equals d.AnalyticDemographicId
                        join q in _context.AnalyticQuestionAnswers on a.Assessment_Id equals q.Assessment_Id
                        where d.IndustryId == industry_id && d.SectorId == sector_id
                        group new { q.Assessment_Id, q.Answer_Text } by new
                        {
                            q.Assessment_Id,
                            q.Answer_Text
                        } into g
                        select new
                        {
                            g.Key.Assessment_Id,
                            g.Key.Answer_Text,
                            Count = g.Count()
                        };



            //go through get the sum total of all
            //get the sum of yes and alts
            //then calc the percent of each assessment and 
            //sector average.

            Dictionary<int, QuickSum> sums = new Dictionary<int, QuickSum>();
            foreach (var a in query.ToList())
            {
                QuickSum quickSum;
                if (sums.TryGetValue(a.Assessment_Id, out quickSum))
                {
                    quickSum.TotalCount += a.Count;
                    if (a.Answer_Text == "Y" || a.Answer_Text == "A")
                    {
                        quickSum.YesAltCount += a.Count;
                    }
                }
                else
                {
                    int yaltCount = 0;
                    if (a.Answer_Text == "Y" || a.Answer_Text == "A")
                    {
                        yaltCount = a.Count;
                    }
                    sums.Add(a.Assessment_Id, new QuickSum() { assesment_id = a.Assessment_Id, TotalCount = a.Count, YesAltCount = yaltCount });

                }
            }

            //calculate the average percentage of all the assessments
            double average = 0;
            foreach (QuickSum s in sums.Values)
            {
                average += s.Percentage;
            }
            average = average / sums.Values.Count();

            return new List<Series>() { new Series() { name = IndustryAverageName, value = average * 100 } };
        }

        private List<Series> GetMyAnalytics(int myAssessment_Id)
        {
            var query = from a in _context.Assessments
                        join d in _context.AnalyticDemographics on a.AnalyticDemographicId equals d.AnalyticDemographicId
                        join q in _context.AnalyticQuestionAnswers on a.Assessment_Id equals q.Assessment_Id
                        where a.Assessment_Id == myAssessment_Id
                        group new { q.Assessment_Id, q.Answer_Text } by new
                        {
                            q.Assessment_Id,
                            q.Answer_Text
                        } into g
                        select new
                        {
                            g.Key.Assessment_Id,
                            g.Key.Answer_Text,
                            Count = g.Count()
                        };



            //go through get the sum total of all
            //get the sum of yes and alts
            //then calc the percent of each assessment and 
            //sector average.

            Dictionary<int, QuickSum> sums = new Dictionary<int, QuickSum>();
            foreach (var a in query.ToList())
            {
                QuickSum quickSum;
                if (sums.TryGetValue(a.Assessment_Id, out quickSum))
                {
                    quickSum.TotalCount += a.Count;
                    if (a.Answer_Text == "Y" || a.Answer_Text == "A")
                    {
                        quickSum.YesAltCount += a.Count;
                    }
                }
                else
                {
                    int yaltCount = 0;
                    if (a.Answer_Text == "Y" || a.Answer_Text == "A")
                    {
                        yaltCount = a.Count;
                    }
                    sums.Add(a.Assessment_Id, new QuickSum() { assesment_id = a.Assessment_Id, TotalCount = a.Count, YesAltCount = yaltCount });

                }
            }

            //calculate the average percentage of all the assessments
            double average = 0;
            foreach (QuickSum s in sums.Values)
            {
                average += s.Percentage;
            }
            average = average / sums.Values.Count();

            return new List<Series>() { new Series() { name = MyAssesmentAverageName, value = average * 100 } };
        }

        public async Task<DashboardChartData> GetAverages(int assessment_id)
        {
            var assessment =  _context.Assessments.Where(x => x.Assessment_Id == assessment_id).FirstOrDefault();
            
            if(assessment != null)
            {
                var demographic = _context.AnalyticDemographics.Where(x => x.AnalyticDemographicId == assessment.AnalyticDemographicId).FirstOrDefault();
                var sectionAnalytics = GetSectorAnalytics(demographic.SectorId);
                var industryAnalytics = GetIndustryAnalytics(demographic.SectorId,demographic.IndustryId);
                var myAnalytics = GetMyAnalytics(assessment_id);
                List<Series> series = new List<Series>();
                series.Union(sectionAnalytics).Union(industryAnalytics).Union(myAnalytics);
                return new DashboardChartData() { name = "Top Averages",series=series};
            }
            else
            {
                return new DashboardChartData
                {
                    name = string.Empty,
                    series = new List<Series>() { new Series() { name = SectorAverageName, value = 0 }, new Series() { name = IndustryAverageName, value = 0 }, new Series() { name = MyAssesmentAverageName, value = 0 } }
                };
            }

            
        }

        public async Task<List<Assessment>> GetUserAssessments(string userId)
        {
            return _context.Assessments.Where(x => x.AssessmentCreatorId == userId).ToList();
        }
    }

    internal class QuickSum
    {
        public int assesment_id { get; set; }
        public int TotalCount { get; set; }
        public int YesAltCount { get; set; }
        public double Percentage { 
            get
            {
                return (double) YesAltCount / (double) TotalCount;
            }
        }
    }
}
