using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace DoctorsAppoinmentMVC.Models
{
    public class Department
    {
        public int Id { get; set; }
       [Required(ErrorMessage = "Please Enter  Department Name!")]
        public string Name { get; set; }
       public virtual List<DoctorModel> Doctor { get; set; }
    }
}