using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoctorsAppoinmentMVC.DAL;
using DoctorsAppoinmentMVC.Models;

namespace DoctorsAppoinmentMVC.BLL
{
    public class AreaManager
    {
        AreaGateway areaGateway=new AreaGateway();

        public IEnumerable<Area> GetAreas()
        {
            return areaGateway.GetAreas();
        } 
    }
}