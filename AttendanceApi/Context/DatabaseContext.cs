using AttendanceApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceApi.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder.Entity<Attendance>()
                .HasOne(p => p.Login)
                .WithMany(i => i.Attendances)
                .HasForeignKey(p => p.UserId);

            base.OnModelCreating(builder);
        }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
    }
}
