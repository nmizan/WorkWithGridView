using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

using  System.Data.SqlClient;
using  System.Configuration;
using FirstWebApplication.BLL;
using FirstWebApplication.Model;

namespace FirstWebApplication
{
    public partial class MyFirstWebPage : System.Web.UI.Page
    {
        private bool isUpdateMode = false;
        EmployeeManager aManager = new EmployeeManager();
        Student aStudent=new Student();
        string connectionString = ConfigurationManager.ConnectionStrings["EmployeeConDB"].ConnectionString;
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
           PopulateGridView();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            aStudent.Name = nameTextBox.Text;
            aStudent.Age = Convert.ToInt32(ageTextBox.Text);
            aStudent.Address = addressTextBox.Text;
            aStudent.ContactNo = contactTextBox.Text;
            aStudent.Department = deptTextBox.Text;
            aStudent.Marks = Convert.ToInt32(TextBox.Text);
            if (isUpdateMode)
            {
                SqlConnection Connection = new SqlConnection(connectionString);
                string query = string.Format(@"Update Student Set Age='" + aStudent.Age + "' ,Address='" + aStudent.Address + "' ,ContactNo='" + aStudent.ContactNo + "' ,Department='" + aStudent.Department + "' ,Marks='" + aStudent.Marks + "' Where Name='" + aStudent.Name + "' ");
                SqlCommand command = new SqlCommand(query, Connection);
               
                Connection.Open();
                int x = command.ExecuteNonQuery();
                Connection.Close();
                if (x>0)
                {
                    Msglabel.Text = "Update Successfully!";
                    saveButton.Text = "Save";
                    id = 0;
                    isUpdateMode = false;
                    PopulateGridView();
                }
                else
                {
                    Msglabel.Text = "Update Failed!";
                }
            }
            else
            {
               

                Msglabel.Text = aManager.SaveStudent(aStudent);
                PopulateGridView();
                ClearTextBox();   
            }
           

        }

        public void ShowData()
        {
            DataTable dt =new DataTable();
            dt.Columns.Add("Name", typeof (string));
            dt.Columns.Add("Age", typeof (int));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("ContactNo", typeof(string));
            dt.Columns.Add("Department", typeof(string));
            dt.Columns.Add("Marks", typeof(int));

            DataRow dr = dt.NewRow();
            dr["Name"] = aStudent.Name;
            dr["Age"] = aStudent.Age;
            dr["Address"] = aStudent.Address;
            dr["ContactNo"] = aStudent.ContactNo;
            dr["Department"] = aStudent.Department;
            dr["Marks"] = aStudent.Marks;

            dt.Rows.Add(dr);

        }

        public void PopulateGridView()
        {
            studentGridView.DataSource = aManager.ShowAllStudents();
            studentGridView.DataBind();
        }

        public void ClearTextBox()
        {
            nameTextBox.Text = "";
            ageTextBox.Text = "";
            addressTextBox.Text = "";
            contactTextBox.Text = "";
            deptTextBox.Text = "";
            TextBox.Text = "";
        }

        protected void studentGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
            studentGridView.EditIndex = e.NewEditIndex;
            PopulateGridView();
            studentGridView.Visible = true;
        }

        protected void studentGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int r = e.RowIndex;

            TextBox lbl = (TextBox)studentGridView.Rows[r].FindControl("idTextBox");
            TextBox t1 = (TextBox) studentGridView.Rows[r].FindControl("nameTextBox");
            TextBox t2 = (TextBox)studentGridView.Rows[r].FindControl("ageTextBox");
            TextBox t3 = (TextBox)studentGridView.Rows[r].FindControl("addressTextBox");
            TextBox t4 = (TextBox)studentGridView.Rows[r].FindControl("contactTextBox");
            TextBox t5 = (TextBox)studentGridView.Rows[r].FindControl("deptTextBox");
            TextBox t6 = (TextBox)studentGridView.Rows[r].FindControl("marksTextBox");

            int a = Convert.ToInt32(lbl.Text);
            string b = t1.Text;
            int  c = Convert.ToInt32(t2.Text);
            string d = t3.Text;
            string ee = t4.Text;
            string f = t5.Text;
            int  g = Convert.ToInt32(t6.Text);

            bool flag = aManager.Update(a,b,c,d,ee,f,g);

            if (flag == true)
            {
                Msglabel.Text = "Update Successfully";
                studentGridView.DataSource = aManager.ShowAllStudents();
                studentGridView.EditIndex = -1;
                studentGridView.DataBind();
               
                
            }
            else
            {
                Msglabel.Text = "Update Failed!";
            }
        }

        protected void studentGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int row = e.RowIndex;
            Label lbl = (Label)studentGridView.Rows[row].FindControl("idLabel");
            int id = int.Parse(lbl.Text);
            bool flag = aManager.Delete(id);
            if (flag == true)
            {
                Msglabel.Text = "Delete Successfully";
                PopulateGridView();
            }
            else
            {
                Msglabel.Text = "Delete Failed!";
            }
        }

        protected void studentGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            
            studentGridView.EditIndex = -1;
            PopulateGridView();
        }

        protected void studentGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            studentGridView.PageIndex = e.NewPageIndex;

            PopulateGridView();
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            studentGridView.DataSource = aManager.ShowStudentsByName(name);
            studentGridView.DataBind();

            aStudent= aManager.ShowStudentsByName(name).FirstOrDefault();

            ageTextBox.Text = aStudent.Age.ToString();
            addressTextBox.Text = aStudent.Address;
            contactTextBox.Text = aStudent.ContactNo;
            deptTextBox.Text = aStudent.Department;
            TextBox.Text = aStudent.Marks.ToString();
            isUpdateMode = true;
            saveButton.Text = "Update";


        }
        

       
    }
}