using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using FirstWebApplication.Model;

namespace FirstWebApplication.DAL
{
    public class EmployeeGAteway
    {
        string connectionString = ConfigurationManager.ConnectionStrings["EmployeeConDB"].ConnectionString;
     
        public int Save(Student aStudent)
        {
            SqlConnection aConnection = new SqlConnection(connectionString);
            string query = string.Format(@"INSERT INTO Student VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", aStudent.Name,aStudent.Age,aStudent.Address,aStudent.ContactNo,aStudent.Department,aStudent.Marks);
            SqlCommand command = new SqlCommand(query, aConnection);
            aConnection.Open();
            int x = command.ExecuteNonQuery();
            aConnection.Close();
            return x;
        }

        public int Update(int id,string name,int age,string adrs,string cntct,string dept,int marks)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            string query = string.Format(@"Update Student Set Name=@name,Age=@age,Address=@adrs,ContactNo=@contact,Department=@dept,Marks=@mrks Where Id =@id");
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@age", age);
            command.Parameters.AddWithValue("@adrs", adrs);
            command.Parameters.AddWithValue("@contact", cntct);
            command.Parameters.AddWithValue("@dept", dept);
            command.Parameters.AddWithValue("@mrks", marks);
            Connection.Open();
            int x = command.ExecuteNonQuery();
            Connection.Close();
            return x; 
        }
        public bool IsStudentNameExists(Student aStudent)
        {
            bool isStudentExists = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select Name From Student where Name='" + aStudent.Name + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                isStudentExists = true;
                break;
            }
            reader.Close();
            connection.Close();
            return isStudentExists;

        }

        public List<Student> ShowAllStudents()
        {
            SqlConnection connection=new SqlConnection(connectionString);
            List<Student>studentList=new List<Student>();
            string query = "select * From Student order By Id DESC";
            SqlCommand command=new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Student aStudent=new Student();
                aStudent.Id = int.Parse(reader.GetValue(0).ToString());
                aStudent.Name = reader.GetValue(1).ToString();
                aStudent.Age = int.Parse(reader.GetValue(2).ToString());
                aStudent.Address = reader.GetValue(3).ToString();
                aStudent.ContactNo = reader.GetValue(4).ToString();
                aStudent.Department = reader.GetValue(5).ToString();
                aStudent.Marks = int.Parse(reader.GetValue(6).ToString());
                studentList.Add(aStudent);
            }
            reader.Close();
            connection.Close();
            return studentList;

        }
        public int Delete(int id)
        {
            SqlConnection aConnection = new SqlConnection(connectionString);
            string query = string.Format(@"Delete From Student Where Id ='"+id+"'");
            SqlCommand command = new SqlCommand(query, aConnection);
            aConnection.Open();
            int x = command.ExecuteNonQuery();
            aConnection.Close();
            return x;
        }
        public List<Student> ShowStudentsByName(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            List<Student> studentList = new List<Student>();
            string query = "select * From Student Where Name='"+name+"'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Student aStudent = new Student();
                aStudent.Id = int.Parse(reader.GetValue(0).ToString());
                aStudent.Name = reader.GetValue(1).ToString();
                aStudent.Age = int.Parse(reader.GetValue(2).ToString());
                aStudent.Address = reader.GetValue(3).ToString();
                aStudent.ContactNo = reader.GetValue(4).ToString();
                aStudent.Department = reader.GetValue(5).ToString();
                aStudent.Marks = int.Parse(reader.GetValue(6).ToString());
                studentList.Add(aStudent);
            }
            reader.Close();
            connection.Close();
            return studentList;

        }
    }
}