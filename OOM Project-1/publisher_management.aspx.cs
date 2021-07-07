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

    public partial class publisher_management : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        //declaring string variable which will hold the connection string from web. config file


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //add btn
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExists())
            {
                Response.Write("<script>alert('Publisher with same ID exists!');</script>");
            }
            else
            {
                addPublisher();
            }
        }

        private void addPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                //creating the object con of class sqlconnection which will be use for database connectivity


                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl (publisher_id, publisher_name) values(@publisher_id, @publisher_name)", con);
                //cmd has 2 parameters(1st : query , 2nd : connection object(con))


                cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();      //for executing the query
                con.Close();                //at the end when query gets executed we need to close the con (object)

                Response.Write("<script>alert('Publisher Added successfully');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error in Adding Publisher');</script>");
            }
        }




        private void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }




        private bool checkIfPublisherExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tbl where publisher_id = '" + TextBox1.Text.Trim() + "'", con);
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





        //Update btn
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExists())
            {
                updatePublisherDetails();
            }
            else
            {
                Response.Write("<script>alert('Does not exists and there4 cannot update!');</script>");
            }
        }

        private void updatePublisherDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl SET publisher_name = @publisher_name WHERE publisher_id = '" + TextBox1.Text.Trim() + "'", con);
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());

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





        //delete btn
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExists())
            {
                deletePublisher();
            }
            else
            {
                Response.Write("<script>alert('Does not exists and there4 cannot b deleted!');</script>");
            }
        }

        private void deletePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("DELETE from publisher_master_tbl where publisher_id ='" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Deleted successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error in deleting publisher!!');</script>");
            }
        }





        //go btn
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExists())
            {
                goEvent();
            }
            else
            {

                Response.Write("<script>alert('Publisher doesn't exists!');</script>");
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
                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tbl where publisher_id = '" + TextBox1.Text.Trim() + "'", con);
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

    }
}