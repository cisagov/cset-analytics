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
        public virtual ICollection<PasswordHistory> PasswordHistories { get; set; }        
        public virtual ICollection<Assessment> Assessments { get; internal set; }
    }
}
