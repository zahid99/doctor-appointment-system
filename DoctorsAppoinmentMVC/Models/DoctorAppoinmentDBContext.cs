using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DoctorsAppoinmentMVC.Models
{
    public class DoctorAppoinmentDBContext:DbContext
    {
        public DoctorAppoinmentDBContext()
            : base("DoctorAppointment")
        {
            
        }
        public DbSet<DoctorModel> Doctor { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Area> Area { get; set; }

    }
}