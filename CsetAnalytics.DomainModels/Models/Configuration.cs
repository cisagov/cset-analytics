using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CsetAnalytics.DomainModels.Models
{
    [Table("Configuration", Schema = "public")]
    public class Configuration
    {
        public Configuration()
        { }

        [Key]
        public int ConfigurationId { get; set; }
        public string ConfigurationKey { get; set; }
        public string ConfigurationValue { get; set; }
}
}
