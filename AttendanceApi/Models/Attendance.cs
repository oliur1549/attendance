using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceApi.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string PicBack { get; set; }
        public string PicFront { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string LocationName { get; set; }
        public DateTime? InTime { get; set; }
        public DateTime? OutTime { get; set; }
        public int UserId { get; set; }
        public Login Logins { get; set; }

    }
}
