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

        [StringLength(100)]
        public string Assets { get; set; }

        [StringLength(100)]
        public string Size { get; set; }

        public int? SectorId { get; set; }

        public int? IndustryId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnalyticQuestionAnswer> AnalyticQuestionAnswers { get; set; }

        public virtual Sector_Industry SECTOR_INDUSTRY { get; set; }
        
        public virtual ApplicationUser ApplicationUser { get; internal set; }
        public virtual ICollection<AnalyticQuestionAnswer> Questions { get; set; }
    }

    public partial class ANSWER_LOOKUP
    {        
        public ANSWER_LOOKUP()
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