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


            builder.Entity<Login>()
                .HasOne(p => p.Attendances)
                .WithOne(i => i.Logins)
                .HasForeignKey<Attendance>(b => b.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
    }
}
