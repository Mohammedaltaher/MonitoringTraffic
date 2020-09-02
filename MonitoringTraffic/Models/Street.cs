using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoringTraffic.Models
{
    public class Street
    {
        public int Id { get; set; }
        public int CityID { get; set; }
        public City City { get; set; }
        public string Name { get; set; }
        public string IsDeleted { get; set; }
    }
}