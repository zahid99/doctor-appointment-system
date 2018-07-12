using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorsAppoinmentMVC.Models
{
    public class DoctorModel
    {
        public int Id { get; set; }
        [Required]
        public int LocationId { get; set; }
        [Required]
        public int HospitalId { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public Department Department { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string BMDCRegNo { get; set; }
        [Required]
        public string Description { get; set; }

        public int Fees { get; set; }
        public string Image { get; set; }
        
    }
}