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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnalyticQuestionId { get; set; }

        [Required]
        [ForeignKey("Assessment")]
        public int Assessment_Id { get; set; }

        public int Question_Or_Requirement_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Answer_Text { get; set; }

        [Required]
        public string QuestionText { get; set; }

        public Guid? Component_Guid { get; set; }

        [StringLength(50)]
        public string Custom_Question_Guid { get; set; }

        public bool Is_Requirement { get; set; }

        public bool Is_Component { get; set; }

        public bool Is_Framework { get; set; }

        public virtual Answer_Lookup Answer_Lookup { get; set; }

        public virtual Assessment Assessment { get; set; }
    }
        

}
