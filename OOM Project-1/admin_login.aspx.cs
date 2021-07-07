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
    public partial class admin_login : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //Admin login btn
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM admin_login_tbl where username = '" + TextBox8.Text.Trim() + "' AND password = '" + TextBox9.Text.Trim() + "'", con);

                

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count >= 1)
                {
                    Response.Write("<script>alert('Hello " + dt.Rows[0]["full_name"].ToString() + "');</script>");

                    Session["username"] = dt.Rows[0]["username"].ToString();
                    Session["full_name"] = dt.Rows[0]["full_name"].ToString();
                    Session["role"] = "admin";

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