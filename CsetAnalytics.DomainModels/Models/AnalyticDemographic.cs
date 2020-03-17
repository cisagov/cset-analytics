using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CsetAnalytics.DomainModels.Models
{
    public partial class AnalyticDemographic
    {
     
        public AnalyticDemographic()
        {
            Assessments = new HashSet<Assessment>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnalyticDemographicId { get; set; }

        public int SectorId { get; set; }

        public int IndustryId { get; set; }

        [StringLength(100)]
        public string Assets { get; set; }

        [StringLength(100)]
        public string Size { get; set; }

        public virtual Sector_Industry Sector_Industry { get; set; }

        public virtual ICollection<Assessment> Assessments { get; set; }
    }
}
