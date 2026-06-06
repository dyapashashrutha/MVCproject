using MVCproject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.WebPages;

namespace MVCproject.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        public ActionResult EmployeeRegistration()
        {

            return View();
        }
        public ActionResult ViewEmployeeData(string search)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd;
                if (search == null || search.IsEmpty())
                {
                    cmd = new SqlCommand("spGetEmployeeData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    cmd = new SqlCommand("spSearchResults", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@search", search);
                }
                SqlDataReader dr = cmd.ExecuteReader();
                List<Employee> emp = new List<Employee>();
                while (dr.Read())
                {
                    Employee e = new Employee();
                    e.empid = (int)dr["empid"];
                    e.empname = (string)dr["empname"];
                    e.mobilenumber = Convert.ToInt64(dr["mobilenumber"]);
                    e.doj = dr["doj"] == DBNull.Value
                            ? (DateTime?)null
                            : Convert.ToDateTime(dr["doj"]);
                    e.empfunction = (string)dr["empfunction"];
                    e.personalemail = (string)dr["personalemail"];
                    e.emailaddress = (string)dr["emailaddress"];
                    e.emppassword = (string)dr["emppassword"];
                    e.emptype = (string)dr["emptype"];
                    e.empstatus = (string)dr["empstatus"];
                    e.empaddress = (string)dr["empaddress"];
                    emp.Add(e);
                }

                ViewBag.empData = emp;
                return View();
            }   
        }
        [HttpPost]
        public JsonResult Insert(Employee emp)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spInsertEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empname", emp.empname);
                cmd.Parameters.AddWithValue("@mobilenumber", emp.mobilenumber);
                cmd.Parameters.AddWithValue("@doj", emp.doj);
                cmd.Parameters.AddWithValue("@empfunction", emp.empfunction);
                cmd.Parameters.AddWithValue("@personalemail", emp.personalemail);
                cmd.Parameters.AddWithValue("@emailaddress", emp.emailaddress);
                cmd.Parameters.AddWithValue("@emppassword", emp.emppassword);
                cmd.Parameters.AddWithValue("@emptype", emp.emptype);
                cmd.Parameters.AddWithValue("@empstatus", emp.empstatus);
                cmd.Parameters.AddWithValue("@empaddress", emp.empaddress);
                cmd.ExecuteNonQuery();
            }
            
            return Json("Success");
        }
        public JsonResult Update(Employee emp)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("spUpdateEmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid", emp.empid);
                cmd.Parameters.AddWithValue("@empname", emp.empname);
                cmd.Parameters.AddWithValue("@mobilenumber", emp.mobilenumber);
                cmd.Parameters.AddWithValue("@doj", emp.doj);
                cmd.Parameters.AddWithValue("@empfunction", emp.empfunction);
                cmd.Parameters.AddWithValue("@personalemail", emp.personalemail);
                cmd.Parameters.AddWithValue("@emailaddress", emp.emailaddress);
                cmd.Parameters.AddWithValue("@emppassword", emp.emppassword);
                cmd.Parameters.AddWithValue("@emptype", emp.emptype);
                cmd.Parameters.AddWithValue("@empstatus", emp.empstatus);
                cmd.Parameters.AddWithValue("@empaddress", emp.empaddress);

                cmd.ExecuteNonQuery();
            }   
            return Json("Success");
        }
        public JsonResult Delete(Employee emp)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid", emp.empid);
                cmd.ExecuteNonQuery();
            }
            return Json("Success");

        }

    }
}