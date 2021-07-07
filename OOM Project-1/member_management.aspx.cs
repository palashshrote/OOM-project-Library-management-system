using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OOM_Project_1
{
    public partial class member_management : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        //declaring string variable which will hold the connection string from web. config file

        
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }


        //Go btn
        protected void Button1_Click(object sender, EventArgs e)
        {
            getMemberByID();
        }

        private void getMemberByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                //creating the object con of class sqlconnection which will be use for database connectivity


                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl where member_id = '" + TextBox1.Text.Trim() + "'", con);
                //cmd has 2 parameters(1st : query , 2nd : connection object(con))

                /*SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox2.Text = dr.GetValue(0).ToString();
                        TextBox3.Text = dr.GetValue(10).ToString();
                        TextBox4.Text = dr.GetValue(1).ToString();
                        TextBox5.Text = dr.GetValue(2).ToString();
                        TextBox6.Text = dr.GetValue(3).ToString();
                        TextBox7.Text = dr.GetValue(5).ToString();
                        TextBox8.Text = dr.GetValue(6).ToString();
                        TextBox9.Text = dr.GetValue(4).ToString();
                        TextBox10.Text = dr.GetValue(7).ToString();
                    }
                    
                }*/
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["full_name"].ToString();
                    TextBox3.Text = dt.Rows[0]["account_status"].ToString();
                    TextBox4.Text = dt.Rows[0]["dob"].ToString();
                    TextBox5.Text = dt.Rows[0]["contact_no"].ToString();
                    TextBox6.Text = dt.Rows[0]["email"].ToString();
                    TextBox7.Text = dt.Rows[0]["city"].ToString();
                    TextBox8.Text = dt.Rows[0]["pincode"].ToString();
                    TextBox9.Text = dt.Rows[0]["state"].ToString();
                    TextBox10.Text = dt.Rows[0]["full_address"].ToString();

                }

                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                    clearForm();
                }

            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error in Button1 Click event');</script>");
            }
        }





        //update btn
        private void updateMemberStatusByID(string status)
        {
            if (checkIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status = '" + status + "' WHERE member_id = '" + TextBox1.Text.Trim() + "' ", con);

                    cmd.ExecuteNonQuery();
                    //for executing the query

                    con.Close();
                    //at the end when query gets executed we need to close the con (object) 

                    GridView1.DataBind();
                    Response.Write("<script>alert('Status Updated!');</script>");
                    clearForm();

                }
                catch (Exception)
                {
                    Response.Write("<script>alert('Error in Button1 Click event');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Cannot update UID');</script>");
            }
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("active");
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("pending");
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("deactive");
        }





        //delete_user btn
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteUserByID();
        }


        private void deleteUserByID()
        {
            if (checkIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE from member_master_tbl where member_id ='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('User Deleted successfully');</script>");
                    clearForm();
                    GridView1.DataBind();
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('Error in deleting the user!!');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('UID cannot be deleted');</script>");
            }

        }





        private bool checkIfMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id = '" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error in Checking');</script>");
                return false;
            }

        }


        private void clearForm()
        {
           
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
        }
    }
}