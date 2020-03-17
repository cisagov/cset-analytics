using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CsetAnalytics.DomainModels.Models
{

    [Table("Assessment", Schema = "public")]
    public class Assessment
    {
        [Key]
        public int Assessment_Id { get; set; }
        [ForeignKey("AnalyticDemographicId")]
        public int AnalyticDemographicId { get; set; }
        public virtual AnalyticDemographic AnalyticDemographic { get; set; }
        public string ApplicationUser_Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; internal set; }
        public virtual ICollection<AnalyticQuestionAnswer> Questions { get; set; }
    }
}