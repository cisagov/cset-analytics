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

        public int Assessment_Id { get; set; }
        public virtual Assessment Assessment { get; set; }

        public int Question_Or_Requirement_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Answer_Text { get; set; }
        public virtual ANSWER_LOOKUP ANSWER_LOOKUP { get; set; }

        public Guid? Component_Guid { get; set; }

        [StringLength(50)]
        public string Custom_Question_Guid { get; set; }

        public bool Is_Requirement { get; set; }

        public bool Is_Component { get; set; }

        public bool Is_Framework { get; set; }
    }
        

}
