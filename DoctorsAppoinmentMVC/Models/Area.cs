using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace DoctorsAppoinmentMVC.Models
{
    public class Area
    {
        public int Id { set; get; }
     
        public string Name { get; set; }
        public virtual List<DoctorModel> Doctor { get; set; }
    }
}