using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorsAppoinmentMVC.Models
{
    public class PatientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

    }
}