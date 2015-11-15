using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FirstWebApplication.DAL;
using FirstWebApplication.Model;

namespace FirstWebApplication.BLL
{
    public class EmployeeManager
    {
        EmployeeGAteway aGAteway = new EmployeeGAteway();

        public string SaveStudent(Student aStudent)
        {
            if (aGAteway.IsStudentNameExists(aStudent))
            {
                return "Student Exists";
            }
            else
            {
                if (aGAteway.Save(aStudent)>0)
                {
                    return "SuccessFully Saved";

                }
                else
                {
                    return "Save Failed";
                }
            }
           
        }

        public bool Update( int id,string name, int age, string adrs, string cntct, string dept, int marks)
        {

            if (aGAteway.Update(id,name, age, adrs, cntct, dept, marks) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
           
        }

        public List<Student> ShowAllStudents()
        {
            return aGAteway.ShowAllStudents();
        }
        public bool Delete(int id)
        {

            if (aGAteway.Delete(id) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Student> ShowStudentsByName(string name)
        {
            return aGAteway.ShowStudentsByName(name);
        }
    }
}