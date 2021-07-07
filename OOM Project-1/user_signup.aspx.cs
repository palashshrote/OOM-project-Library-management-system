using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OOM_Project_1
{
    public partial class user_signup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString; //declaring string variable which will hold the connection string from web. config file
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //go to login
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("user_login.aspx");
        }






        //Sign up button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(checkIfUserExists() == true)
            {
                Response.Write("<script>alert('User already exists with same ID!');</script>");
            }
            else
            {
                user_signUp();
            }
        }

        public bool checkIfUserExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);  //creating the object con of class sqlconnection which will be use for database connectivity

                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id = '"+TextBox8.Text.Trim()+"'", con);
                //cmd has 2 parameters(1st : query , 2nd : connection object(con))


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                
                //Inheritance object->MarshalByRefObject->Components->DataAdapter->DbDataAdapter->SqlDataAdapter
                DataTable dt = new DataTable();
                //SqlDataAdapter serves a channel bet datatable nd server

                da.Fill(dt);

                if(dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception)
            {
                Response.Write("<script>alert('Error in checking');</script>");   
            }
            return false;
        }

        private void user_signUp()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl (full_name,dob,contact_no,email,state,city,pincode,full_address,member_id,password,account_status) values (@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@member_id,@password,@account_status)", con);

                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@city", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@full_address", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());

                cmd.Parameters.AddWithValue("@account_status", "pending");

                cmd.ExecuteNonQuery();  //for executing the query
                con.Close();            //at the end when query gets executed we need to close the con (object) 

                Response.Write("<script>alert('Sign Up successfull U can Login');</script>");

            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error in signup!');</script>");
            }
        }
    }
}