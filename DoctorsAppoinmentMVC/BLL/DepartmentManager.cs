using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoctorsAppoinmentMVC.DAL;
using DoctorsAppoinmentMVC.Models;

namespace DoctorsAppoinmentMVC.BLL
{
    public class DepartmentManager
    {
        DepartmentGateway aDepartmentGateway=new DepartmentGateway();

        public List<Department> GetDepartments()
        {
            return (List<Department>) aDepartmentGateway.GetDepartments();
        } 
    }
}