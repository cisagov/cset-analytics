using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CsetAnalytics.DomainModels.Models
{


    [Table("SECTOR")]
    public partial class SECTOR
    {

        public SECTOR()
        {
            Sector_Industry = new HashSet<Sector_Industry>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SectorId { get; set; }

        [Required]
        [StringLength(50)]
        public string SectorName { get; set; }


        public virtual ICollection<Sector_Industry> Sector_Industry { get; set; }
    }

    public partial class Sector_Industry
    {

        public Sector_Industry()
        {
            Assessments = new HashSet<Assessment>();
        }

        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SectorId { get; set; }

        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IndustryId { get; set; }

        [Required]
        [StringLength(150)]
        public string IndustryName { get; set; }


        public virtual ICollection<Assessment> Assessments { get; set; }

        public virtual SECTOR SECTOR { get; set; }
    }
}
