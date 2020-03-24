using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CsetAnalytics.DomainModels.Models
{
    public partial class Answer_Lookup
    {
        
        public Answer_Lookup()
        {
            AnalyticQuestionAnswers = new HashSet<AnalyticQuestionAnswer>();
        }

        [Key]
        [StringLength(50)]
        public string Answer_Text { get; set; }

        [Required]
        [StringLength(50)]
        public string Answer_Full_Name { get; set; }

        
        public virtual ICollection<AnalyticQuestionAnswer> AnalyticQuestionAnswers { get; set; }
    }
}
