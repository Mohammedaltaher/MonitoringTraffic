using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoringTraffic.Models
{
    public class Camera
    {
        public int Id { get; set; }
        public int StreetID { get; set; }
        public Street Street { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public string Diriction { get; set; }
        public bool? IsIn { get; set; }
        public bool? IsInStreetBegaining { get; set; }
        public string IpAddress { get; set; }
        public string IsDeleted { get; set; }
        public DateTime? Date { get; set; }
        public int? Count { get; set; }
    }
}