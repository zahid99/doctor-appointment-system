using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DoctorsAppoinmentMVC.Models;

namespace DoctorsAppoinmentMVC.DAL
{
    public class DoctorSearchGateway
    {

        private string connectionString = WebConfigurationManager.ConnectionStrings["DoctorAppointment"].ConnectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public IEnumerable<DoctorModel> GetDoctor(int departmentId,int  areaId)
        {
            connection=new SqlConnection(connectionString);
            string query = "select DoctorModels.Name as dname,DoctorModels.Designation from DoctorModels,Area,Departments where DoctorModels.Department_Id=Departments.Id and DoctorModels.LocationId=Area.id ANd Departments.Id='"+departmentId+"' and Area.id='"+areaId+"'";
            command=new SqlCommand(query,connection);
            List<DoctorModel> doctorModels = new List<DoctorModel>();
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                DoctorModel doctor = new DoctorModel();
                //doctor.Id = (int)reader["id"];
                doctor.Name = reader["dname"].ToString();
                doctor.Description = reader["Designation"].ToString();
                doctorModels.Add(doctor);
            }
            reader.Close();
            connection.Close();
            return doctorModels;
        }
    
    }
}