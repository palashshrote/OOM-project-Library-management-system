using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OOM_Project_1
{
    public partial class user_login : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        //declaring string variable which will hold the connection string from web. config file
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("user_signup.aspx");
        }


        //login button event
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                //creating the object con of class sqlconnection which will be use for database connectivity
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl where member_id = '"+TextBox8.Text.Trim()+"' AND password = '"+TextBox9.Text.Trim()+"'", con);
                
                //connection oriented archi
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count >= 1)
                {
                    Response.Write("<script>alert('Welcome " + dt.Rows[0]["full_name"].ToString() + "');</script>");

                    Session["username"] = dt.Rows[0]["member_id"].ToString();
                    Session["full_name"] = dt.Rows[0]["full_name"].ToString();
                    Session["role"] = "user";
                    Session["status"] = dt.Rows[0]["account_status"].ToString();

                    Response.Redirect("homepage.aspx");
                }

                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }

            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error in Button1 Click event');</script>");
            }

            

            
        }
    }
}