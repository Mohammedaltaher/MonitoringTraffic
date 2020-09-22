using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoringTraffic.Models
{
    public class StreetPosstions
    {
        public int Id { get; set; }
        public int StreetID { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public Street Street { get; set; }
        public string Name { get; set; }
        public string IsDeleted { get; set; }
    }
}