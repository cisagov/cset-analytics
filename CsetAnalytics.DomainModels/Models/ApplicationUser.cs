using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public bool IsSuperUser { get; set; }

        public bool PasswordResetRequired { get; set; }

        [StringLength(150)]
        public string FirstName { get; set; }

        [StringLength(150)]
        public string LastName { get; set; }

        public Guid? Guid_Id { get; set; }
    }
}
