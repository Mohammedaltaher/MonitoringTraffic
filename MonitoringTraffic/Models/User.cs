using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoringTraffic.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string IsDeleted { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}