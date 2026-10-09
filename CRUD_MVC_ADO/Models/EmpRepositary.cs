using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUD_MVC_ADO.Models
{
    public class EmpRepositary
    {
        string constr=ConfigurationManager.ConnectionStrings["DBCS"].ToString();

        public void AddEmployee(EmpInfo obj)
        {
            SqlConnection cn = new SqlConnection(constr);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_add", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("empid", obj.EmpId);
                cmd.Parameters.AddWithValue("empname", obj.EmpName);
                cmd.Parameters.AddWithValue("city", obj.City);
                cmd.Parameters.AddWithValue("address", obj.Address);
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                throw new Exception("Records already exits", e);
            }
            finally
            {
                cn.Close();
            }
           
        }

        public List<EmpInfo> GetAllEmployeeDetails()
        {
            SqlConnection cn = new SqlConnection(constr);
            try
            {
                cn.Open ();
                SqlCommand cmd = new SqlCommand("sp_view", cn);
                List<EmpInfo> list=new List<EmpInfo>();
                cmd.CommandType= CommandType.StoredProcedure;
                SqlDataAdapter da= new SqlDataAdapter(cmd);
                DataTable dt=new DataTable(); 
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows )
                {
                    list.Add(new EmpInfo()
                    {
                        EmpId = Convert.ToInt32(dr["EmpId"]),
                        EmpName=Convert.ToString(dr["EmpName"]),
                        City = Convert.ToString(dr["City"]),
                        Address = Convert.ToString(dr["Address"])
                    }); 
                }
                return list;
            }
            catch (Exception e)
            {
                throw new Exception("error message", e);
            }
            finally
            {
                cn.Close(); 
            }
        }

        public void EditEmployee(EmpInfo obj)
        {
            SqlConnection con = new SqlConnection(constr);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_edit", con);
                cmd.CommandType  = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid", obj.EmpId);
                cmd.Parameters.AddWithValue("@empname", obj.EmpName);
                cmd.Parameters.AddWithValue("@city", obj.City);
                cmd.Parameters.AddWithValue("@address", obj.Address);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Edit Error Message", e);
            }
            finally
            {
                con.Close();
            }
        }

        public void DeleteEmployee(int id) 
        {
            SqlConnection con=new SqlConnection(constr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid",id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Delete Error Message", e);
            }
            finally 
            {
                con.Close();
            }
        }
    }
}