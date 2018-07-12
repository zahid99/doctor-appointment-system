using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DoctorsAppoinmentMVC.BLL;
using DoctorsAppoinmentMVC.DAL;
using DoctorsAppoinmentMVC.Models;

namespace DoctorsAppoinmentMVC.Controllers
{
    public class HomeController : Controller
    {
        private DoctorSearchGateway doctorSearchGateway=new DoctorSearchGateway();

        private DoctorAppoinmentDBContext db = new DoctorAppoinmentDBContext();
        public ActionResult Index()
        {
            AreaManager areaManager = new AreaManager();
            ViewBag.area = areaManager.GetAreas();
            return View();
        }

        [HttpPost]
        public ActionResult Index(int areaId,int departmentId )
        {
            AreaManager areaManager = new AreaManager();
            ViewBag.area = areaManager.GetAreas();
            return RedirectToAction("Search", "Home",new {areaId,departmentId});
            //return ActionResult("ho", "");
            return View();
        }


        public JsonResult GetDepartmentAndHospital(int typeId)
        {
            //var teachers = teacherManager.GetAllTeacher();
            //var teacherList = teachers.Where(t => t.DepartmentId == departmentId).ToList();

            //if (typeId==1)
            //{
                
            //}
            DepartmentManager departmentManager=new DepartmentManager();
            var list = departmentManager.GetDepartments();
            return Json(list);


        }





        public ActionResult Search(int areaId,int departmentId)
        {
            ViewBag.AreaList = db.Area.ToList();
            ViewBag.DoctorList = doctorSearchGateway.GetDoctor(departmentId, areaId);
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}