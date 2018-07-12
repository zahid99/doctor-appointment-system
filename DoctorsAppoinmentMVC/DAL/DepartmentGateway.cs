using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DoctorsAppoinmentMVC.Models;

namespace DoctorsAppoinmentMVC.DAL
{
    public class DepartmentGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DoctorAppointment"].ConnectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public IEnumerable<Department> GetDepartments()
        {
            connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Departments";
            command = new SqlCommand(query, connection);
            List<Department> departments = new List<Department>();
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Department department = new Department();
                department.Id = (int)reader["id"];
                department.Name = reader["name"].ToString();
                departments.Add(department);
            }
            reader.Close();
            connection.Close();
            return departments;
        }
    }
}