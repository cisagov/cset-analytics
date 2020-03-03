using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CsetAnalytics.DomainModels
{

    [Table("Assessments", Schema = "public")]
    public class Assessments
    {
        [Key]
        public int Assessment_Id { get; set; }
    }
}