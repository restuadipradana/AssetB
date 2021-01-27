using System;

namespace AssetB.DTO
{
    public class AssetMaintainDTO
    {
        public string Asset_ID { get; set; }
        public string AssetKind { get; set; }
        public string KindName { get; set; }
        public string Name { get; set; }
        public string Spec { get; set; }
        public string Locat { get; set; }
        public string Stat { get; set; }
        public DateTime recdate { get; set; }
        public DateTime intime { get; set; }
        public DateTime uptime { get; set; }
        public AssetMaintainDTO()
        {
            this.uptime = DateTime.Now;
        }


    }
}