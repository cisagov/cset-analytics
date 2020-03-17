using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CsetAnalytics.DomainModels.Models
{

    [Table("Assessments", Schema = "public")]
    public class Assessment
    {
        public Assessment()
        {
            AnalyticQuestionAnswers = new HashSet<AnalyticQuestionAnswer>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Assessment_Id { get; set; }

        [Column(TypeName = "timestamptz")]
        public DateTime AssessmentCreatedDate { get; set; }

        public string AssessmentCreatorId { get; set; }

        [Column(TypeName = "timestamptz")]
        public DateTime? LastAccessedDate { get; set; }

        [StringLength(50)]
        public string Alias { get; set; }

        public string Assessment_GUID { get; set; }

        [Column(TypeName = "timestamptz")]
        public DateTime Assessment_Date { get; set; }

        public int AnalyticDemographicId { get; set; }

        public virtual ICollection<AnalyticQuestionAnswer> AnalyticQuestionAnswers { get; set; }
        public virtual ApplicationUser ApplicationUser { get; internal set; }
        public virtual ICollection<AnalyticQuestionAnswer> Questions { get; set; }
        public virtual AnalyticDemographic AnalyticDemographic { get; set; }
    }
}