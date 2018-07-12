using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DoctorsAppoinmentMVC.Models;

namespace DoctorsAppoinmentMVC.DAL
{
    public class AreaGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DoctorAppointment"].ConnectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public IEnumerable<Area> GetAreas()
        {
            connection=new SqlConnection(connectionString);
            string query = "SELECT * FROM Area";
            command=new SqlCommand(query,connection);
            List<Area>areas=new List<Area>();
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Area area=new Area();
                area.Id = (int) reader["id"];
                area.Name = reader["name"].ToString();
                areas.Add(area);
            }
            reader.Close();
            connection.Close();
            return areas;
        }
    }
}