using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Les8.Models;

namespace Les8.Models
{
    public class StudentMonipulation
    {

        public IEnumerable<Student> Students
        {
            get
            {
                string connectionstring = ConfigurationManager.ConnectionStrings["StudentContext"].ConnectionString;
                List<Student> st = new List<Student>();

                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand("spGetStudent", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Student student = new Student();
                        student.ID = Convert.ToInt32(rdr["ID"]);
                        student.FirstName = rdr["FirstName"].ToString();
                        student.LastName = rdr["LastName"].ToString();
                        student.Keyword = rdr["Keyword"].ToString();

                        st.Add(student);
                    }
                }
                return st;
            }
        }
        public void AddStudent(Student student)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["StudentContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("spAddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramFirstName = new SqlParameter();
                paramFirstName.ParameterName = "@firstname";
                paramFirstName.Value = student.FirstName;
                cmd.Parameters.Add(paramFirstName);

                SqlParameter paramLastName = new SqlParameter();
                paramLastName.ParameterName = "@lastname";
                paramLastName.Value = student.LastName;
                cmd.Parameters.Add(paramLastName);

                SqlParameter paramKeyword = new SqlParameter();
                paramKeyword.ParameterName = "@keyword";
                paramKeyword.Value = student.Keyword;
                cmd.Parameters.Add(paramKeyword);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SaveStudent(Student st)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["StudentContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("spUpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@id";
                paramId.Value = st.ID;
                cmd.Parameters.Add(paramId);

                SqlParameter paramFirstName = new SqlParameter();
                paramFirstName.ParameterName = "@firstname";
                paramFirstName.Value = st.FirstName;
                cmd.Parameters.Add(paramFirstName);

                SqlParameter paramLastName = new SqlParameter();
                paramLastName.ParameterName = "@lastname";
                paramLastName.Value = st.LastName;
                cmd.Parameters.Add(paramLastName);

                SqlParameter paramKeyword = new SqlParameter();
                paramKeyword.ParameterName = "@keyword";
                paramKeyword.Value = st.Keyword;
                cmd.Parameters.Add(paramKeyword);

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }
        public void DeleteStudent(int id)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["StudentContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("spDeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                cmd.Parameters.Add(paramId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}