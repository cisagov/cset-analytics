using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace CsetAnalytics.DomainModels.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool ChangePassword { get; set; }
        public virtual ICollection<PasswordHistory> PasswordHistories { get; set; }
    }
}
