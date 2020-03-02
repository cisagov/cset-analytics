using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CsetAnalytics.DomainModels.Models
{
    [Table("AnalyticQuestion", Schema = "public")]
    public class AnalyticQuestion
    {
        public AnalyticQuestion() { }
        [Key]
        public int AnalyticQuestionId { get; set; }
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string Answer { get; set; }
        [ForeignKey("AnalyticDemographicId")]
        public int AnalyticDemographicId { get; set; }
        public virtual AnalyticDemographic AnalyticDemographic { get; set; }
    }
}
