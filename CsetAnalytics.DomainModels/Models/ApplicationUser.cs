using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace CsetAnalytics.DomainModels.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool ChangePassword { get; set; }
        [ForeignKey("AnalyticDemographicFK")]
        public AnalyticDemographic AnalyticDemographic { get; set; }
        public virtual ICollection<PasswordHistory> PasswordHistories { get; set; }
        public ICollection<AnalyticDemographic> AnalyticDemographics { get; set; }
    }
}
