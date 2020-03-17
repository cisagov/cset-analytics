using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CsetAnalytics.DomainModels.Models
{
    [Table("AnalyticQuestionAnswer", Schema = "public")]
    public class AnalyticQuestionAnswer
    {
        public AnalyticQuestionAnswer() { }
        [Key]
        public int AnalyticQuestionId { get; set; }
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string Answer { get; set; }
        public int Assessment_Id { get; set; }
        public virtual Assessment Assessment { get; set; }
    }
}
