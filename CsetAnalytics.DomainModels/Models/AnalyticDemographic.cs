using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CsetAnalytics.DomainModels.Models
{
    public class AnalyticDemographic
    {
        public AnalyticDemographic() { }
        [Key]
        public int AnalyticDemographicId { get; set; }
        public string IndustryName { get; set; }
        public string SectorName { get; set; }
        public string Size { get; set; }
        public string AssetValue { get; set; }
        [ForeignKey("ApplicationUser")]
        public string AspNetUserId { get; set; }

        public virtual ICollection<AnalyticQuestion> AnalyticQuestions { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
