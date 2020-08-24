using AlexLandscapeV0._1.Models;
using AlexLandscapeV0._1.RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace AlexLandscapeV0._1.RepositoryLayer
{
    public class AdminRepository : IAdminRepository
    {
        private Admin ad;
        private string _connectionString;
        public AdminRepository(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("DefaultConnection");
            ad = new Admin();
        }

        public DataTable Login(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_Admin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flag", "adLogin");
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                con.Open();
                var adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                if(ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
                
            }
        }
    }
}
