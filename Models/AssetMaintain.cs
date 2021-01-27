using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AssetB.Models
{
    [Table("AssetMaintain")]
    public class AssetMaintain
    {
        [Key]
        [StringLength(10)]
        public string Asset_ID { get; set; }

        [StringLength(5)]
        public string AssetKind { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Spec { get; set; }

        [StringLength(5)]
        public string Locat { get; set; }
        
        [StringLength(1)]
        public string Stat { get; set; }

        [Column(Order = 6, TypeName = "date")]
        public DateTime recdate { get; set; }

        [Column(Order = 7)]
        public DateTime intime { get; set; }

        [Column(Order = 8)]
        public DateTime uptime { get; set; }
    }
}