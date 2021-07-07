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
    public partial class author_management : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        //declaring string variable which will hold the connection string from web. config file
        protected void Page_Load(object sender, EventArgs e)
        {

            
        }


        //add btn
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExists())
            {
                Response.Write("<script>alert('Author with same ID exists!');</script>");
            }
            else
            {
                addAuthor();
            }
        }

        private void addAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl (author_id, author_name) values(@author_id, @author_name)", con);
                //cmd has 2 parameters(1st : query , 2nd : connection object(con))


                cmd.Parameters.AddWithValue("@author_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();      //for executing the query
                con.Close();                //at the end when query gets executed we need to close the con (object) 
                Response.Write("<script>alert('Author Added successfully');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error in Adding author');</script>");
            }
        }




        private bool checkIfAuthorExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from author_master_tbl where author_id = '"+TextBox1.Text.Trim()+"'", con);
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




        //update btn
        protected void Button3_Click(object sender, EventArgs e)
        {
            if(checkIfAuthorExists())
            {
                updateAuthorDetails();
            }
            else
            {
                Response.Write("<script>alert('Does not exists and there4 cannot update!');</script>");
            }
        }

        private void updateAuthorDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name = @author_name WHERE author_id = '"+TextBox1.Text.Trim()+"'", con);
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Updated successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error in Updating author');</script>");
            }
        
        }




        //delete author
        protected void Button4_Click(object sender, EventArgs e)
        {
            if(checkIfAuthorExists())
            {
                deleteAuthor();
            }
            else
            {
                Response.Write("<script>alert('Does not exists and there4 cannot b deleted!');</script>");
            }
        }

        private void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("DELETE from author_master_tbl where author_id ='"+TextBox1.Text.Trim()+"'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Deleted successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error in deleting author!!');</script>");
            }
        }




        //go btn
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(checkIfAuthorExists())
            {
                goEvent();
            }
            else
            {
                
                Response.Write("<script>alert('Author doesn't exists!');</script>");
                clearForm();
            }
        }

        private void goEvent()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from author_master_tbl where author_id = '" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error in srching');</script>");
                
            }
        }




        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}