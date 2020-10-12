using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoringTraffic.Models
{
    public class Street
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public int CityID { get; set; }
        public City City { get; set; }
        public string Name { get; set; }

        public float? StartLatitude { get; set; }
        public float? StartLongitude { get; set; }

        public float? EndLatitude { get; set; }
        public float? EndLongitude { get; set; }

        public int? DiractionsID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string IsDeleted { get; set; }
    }
}