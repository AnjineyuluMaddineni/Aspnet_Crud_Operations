using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Aspnet_Crud_Operations
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            //Step 01:Connect to db and open the connection
            string constring = "Data Source=DESKTOP-UP83FQL\\SQLEXPRESS; Initial catalog=ADO.NET;user ID=sa;Password=chandu12345678";
            SqlConnection sqlconn = new SqlConnection(constring);
            sqlconn.Open();
            //Step 02: Execute insertCommand by passing InsertQuery
            int studentID = int.Parse(TextBox1.Text);
            string studentName = TextBox2.Text.ToString();
            int firstYearmarks = int.Parse(TextBox3.Text);
            int secondYearmarks = int.Parse(TextBox4.Text);
            int totalMarks = firstYearmarks + secondYearmarks;
            
            string grade = "";
            
            if (totalMarks >= 900) 
            {
                //Label11.Text = "Distinction ";
                grade = "Distinction";

            }
            else if (totalMarks >= 700)
            {
                //Label11.Text="FirstClass";
                grade = "FirstClass";
            }
            else if(totalMarks>=600)
            {
                //Label11.Text="SecondClass";
                grade = "SecondClass";
            }
            else
            {
                grade = "Failed";
            }

            string insertQuery = "insert into Studentdetails(StudentID,StudentName,FirstYearmarks,SecondYearmarks,TotalMarks,Grade) values('" + studentID + "','" + studentName + "','" + firstYearmarks + "','" + secondYearmarks + "','"+totalMarks+"','" + grade + "')";
            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlconn);
            insertCommand.ExecuteNonQuery();
            //Step 03:Dispose the SqlCommand and close the sqlconnection
            insertCommand.Dispose();
            sqlconn.Close();
            Label6.Text = "Inserted Successfully";
           
            
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //Step 01:Connect to db and open the connection
            string constring = "Data Source=DESKTOP-UP83FQL\\SQLEXPRESS; Initial catalog=ADO.NET;user ID=sa;Password=chandu12345678";
            SqlConnection sqlconn = new SqlConnection(constring);
            sqlconn.Open();
            string selectQuery = "select * from Studentdetails ";
            SqlCommand selectCommand = new SqlCommand(selectQuery, sqlconn);
            SqlDataReader sqlReader = selectCommand.ExecuteReader();
            GridView1.DataSource = sqlReader;
            GridView1.DataBind();
            sqlconn.Close();
            Label7.Text = "Select Successfully";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Step 01:Connect to db and open the connection
            string constring = "Data Source=DESKTOP-UP83FQL\\SQLEXPRESS; Initial catalog=ADO.NET;user ID=sa;Password=chandu12345678";
            SqlConnection sqlconn = new SqlConnection(constring);
            sqlconn.Open();
            int studentID = int.Parse(TextBox1.Text);
            //string searchQuery = "select * from Studentdetails where studentID '"+TextBox1.Text+"'";
            string searchQuery = "select * from Studentdetails where studentID ='" + studentID + "'";
            SqlDataAdapter da = new SqlDataAdapter(searchQuery, sqlconn);
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            sqlconn.Close();
            Label8.Text = "search successfully";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Step 01:Connect to db and open the connection
            string constring = "Data Source=DESKTOP-UP83FQL\\SQLEXPRESS; Initial catalog=ADO.NET;user ID=sa;Password=chandu12345678";
            SqlConnection sqlconn = new SqlConnection(constring);
            sqlconn.Open();
            int studentID = int.Parse(TextBox1.Text);
            string studentName = TextBox2.Text.ToString();
            //int firstYearmarks = int.Parse(TextBox3.Text);
            //int secondYearmarks = int.Parse(TextBox4.Text);
            //int totalMarks = firstYearmarks + secondYearmarks;
            //string updateQuery = "Update Studentdetails set StudentName ='" + studentName + "','" + firstYearmarks + "','" + secondYearmarks + "' where studentID='" + studentID + "'";
            string updateQuery = "Update Studentdetails set StudentName = '"+studentName+"' where studentID = '"+studentID+"'";
            SqlCommand updateCommand = new SqlCommand(updateQuery, sqlconn);
            updateCommand.ExecuteNonQuery();
            updateCommand.Dispose();
            Label9.Text = "Updated Successfully";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //Step 01:Connect to db and open the connection
            string constring = "Data Source=DESKTOP-UP83FQL\\SQLEXPRESS; Initial catalog=ADO.NET;user ID=sa;Password=chandu12345678";
            SqlConnection sqlconn = new SqlConnection(constring);
            sqlconn.Open();
            int studentID = int.Parse(TextBox1.Text);
            string deleteQuery = "delete Studentdetails where StudentID ='"+studentID+"'";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlconn);
            deleteCommand.ExecuteNonQuery();
            deleteCommand.Dispose();
            sqlconn.Close();
            Label10.Text = "Deleted Successfull";
        }
    }
}