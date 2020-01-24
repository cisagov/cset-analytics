using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CsetAnalytics.DomainModels.Models
{
    [Table("PasswordHistory", Schema = "public")]
    public class PasswordHistory
    {
        public PasswordHistory() { }

        [Key]
        public int PasswordHistoryId { get; set; }
        public string AspNetUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUserId { get; set; }
        public string PasswordHash { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
