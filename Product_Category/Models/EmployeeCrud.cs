using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Category.Models
{
    public class EmployeeCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public EmployeeCrud()
        {
            string connstr = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            con = new SqlConnection(connstr);
        }

        public List<Department> GetDepartments()
        {
            List<Department> list = new List<Department>();

            string qry = "select * from Department";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Department c = new Department();
                    c.D_id = Convert.ToInt32(dr["D_id"]);
                    c.D_name = dr["D_name"].ToString();
                    list.Add(c);
                }
            }
            con.Close();
            return list;
        }

        public int AddEmployee(Employee emp)
        {
         
            string qry = "insert into Employee values(@E_name,@E_salary,@D_id)";
      
            cmd = new SqlCommand(qry, con);
         
            cmd.Parameters.AddWithValue("@E_name", emp.E_name);
            cmd.Parameters.AddWithValue("@E_salary", emp.E_salary);
            cmd.Parameters.AddWithValue("@D_id", emp.D_id);
       
            con.Open();

            int result = cmd.ExecuteNonQuery();

            con.Close();
            return result;
        }
        public int UpdateEmployee(Employee emp)
        {
        
            string qry = "update Employee set E_name=@name,E_salary=@salary,D_id=@did where E_id=@id";
            
            cmd = new SqlCommand(qry, con);
            
            cmd.Parameters.AddWithValue("@name", emp.E_name);
            cmd.Parameters.AddWithValue("@salary", emp.E_salary);
            cmd.Parameters.AddWithValue("@did", emp.D_id);
            cmd.Parameters.AddWithValue("@id", emp.D_id);
            
            con.Open();
            
            int result = cmd.ExecuteNonQuery();
            
            con.Close();
            return result;
        }

        public int DeleteEmployee(int id)
        {
           
            string qry = "delete from Employee where E_id=@id";
           
            cmd = new SqlCommand(qry, con);
            
            cmd.Parameters.AddWithValue("@id", id);
           
            con.Open();
          
            int result = cmd.ExecuteNonQuery();
           
            con.Close();
            return result;
        }
        public Employee GetEmployeeById(int id)
        {
            Employee employee = new Employee();
            string qry = "select * from Employee where E_id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    employee.E_id = Convert.ToInt32(dr["E_id"]);
                    employee.E_name = dr["E_name"].ToString();
                    employee.E_salary= Convert.ToInt32(dr["E_salary"]);
                    employee.D_id = Convert.ToInt32(dr["D_id"]);
                }
            }
            con.Close();
            return employee;
        }

        public DataTable GetAllEmployees()
        {
            DataTable dt = new DataTable();
            string qry = "select * from Employee";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dt.Load(dr);
            }
            con.Close();
            return dt;
        }

    }
}
