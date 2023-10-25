using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentList.Models;
using System.Data;
using System.Data.SqlClient;

namespace StudentList.Repository
{
    public class StudentRepository
    {
        public List<StudentModel> GetAllStudents()
        {
            List<StudentModel> students = new List<StudentModel>();
            using (SqlConnection cn = new SqlConnection(Utility.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("GetStudents", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        cn.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            StudentModel student = new StudentModel();
                            student.Student_Id = Convert.ToInt32(sdr["Student_Id"]);
                            student.Student_Name = sdr["Student_Name"].ToString();
                            student.PhoneNumber = sdr["PhoneNumber"].ToString();
                            student.Email = sdr["Email"].ToString();
                            students.Add(student);
                        }
                        sdr.Close();
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }
                    finally
                    {
                        if (cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }
            return students;
        }

        public StudentModel GetStudentById(int id)
        {
            StudentModel student = new StudentModel();
            using(SqlConnection cn = new SqlConnection(Utility.GetConnection()))
            {
                using(SqlCommand cmd = new SqlCommand("GetStudentById", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@student_Id", id);
                    try
                    {
                        cn.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            student.Student_Id = Convert.ToInt32(sdr["Student_Id"]);
                            student.Student_Name = sdr["Student_Name"].ToString();
                            student.PhoneNumber = sdr["PhoneNumber"].ToString();
                            student.Email = sdr["Email"].ToString();
                        }
                        sdr.Close();
                    }
                    catch(SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if(cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }
            return student;
        }
        public int AddStudent(StudentModel student)
        {
            using(SqlConnection cn = new SqlConnection(Utility.GetConnection()))
            {
                using(SqlCommand cmd = new SqlCommand("AddStudent", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@studentName", student.Student_Name);
                    cmd.Parameters.AddWithValue("@phoneNumber", student.PhoneNumber);
                    cmd.Parameters.AddWithValue("@email", student.Email);
                    try
                    {
                        cn.Open();
                        int count = cmd.ExecuteNonQuery();
                        return count;
                    }
                    catch(SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if(cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }
        }
        public int UpdateStudent(StudentModel student)
        {
            using(SqlConnection cn = new SqlConnection(Utility.GetConnection()))
            {
                using(SqlCommand cmd = new SqlCommand("EditStudent", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@studentId", student.Student_Id);
                    cmd.Parameters.AddWithValue("@studentName", student.Student_Name);
                    cmd.Parameters.AddWithValue("@phoneNumber", student.PhoneNumber);
                    cmd.Parameters.AddWithValue("@email", student.Email);
                    try
                    {
                        cn.Open();
                        int count = cmd.ExecuteNonQuery();
                        return count;
                    }
                    catch(SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if(cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }
        }
        public int DeleteStudent(int id)
        {
            using(SqlConnection cn = new SqlConnection(Utility.GetConnection()))
            {
                using(SqlCommand cmd = new SqlCommand("EraseStudent", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@studentId", id);
                    try
                    {
                        cn.Open();
                        int count = cmd.ExecuteNonQuery();
                        return count;
                    }
                    catch(SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if(cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }
        }
    }
}
