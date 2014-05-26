using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace businesLayer
{
    public class EmployeebusinessLayer
    {
        public IEnumerable<Employee> Employee
        {

            get {
                List<Employee> empList=new List<Employee>();
                string cn = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
                using(SqlConnection con=new SqlConnection(cn))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr= cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Employee employee = new Employee();
                        employee.ID = Convert.ToInt32(rdr["Id"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.City = rdr["City"].ToString();
                        employee.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);

                        empList.Add(employee);
                    }
                    return empList;
                }
            }
            
        }
        public void AddEmployee(Employee employee) {
            
                string cn = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cn))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@City", employee.City);
                    cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            
        }
        public void updateEmployee(Employee employee)
        {
            string cn = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cn))
            {
                SqlCommand cmd = new SqlCommand("spSaveEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", employee.ID);

                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@City", employee.City);
                cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
