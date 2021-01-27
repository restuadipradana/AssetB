using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetB.Models
{
    [Table("Asset_Kind1")]
    public class Asset_Kind1
    {
        [Key]
        [StringLength(5)]
        public string kind { get; set; }

        [StringLength(50)]
        public string kindna { get; set; }

        public DateTime intime { get; set; }

        public DateTime uptime { get; set; }

        public string image_src { get; set; }
    }
}