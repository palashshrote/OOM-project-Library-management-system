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
    public partial class book_issuing : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        //declaring string variable which will hold the connection string from web. config file

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //Go btn
        protected void Button1_Click(object sender, EventArgs e)
        {
            getNames();
        }
        private void getNames()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("SELECT book_name from book_master_tbl where book_id = '"+TextBox2.Text.Trim()+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong book ID');</script>");
                }

                cmd = new SqlCommand("SELECT full_name from member_master_tbl where member_id = '" + TextBox1.Text.Trim() + "'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong user ID');</script>");
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error in getting names');</script>");
            }
        }


        //issue btn
        protected void Button2_Click(object sender, EventArgs e)
        {
            if(checkIfBookExists() && checkIfUserExists())
            {
                if (checkIfIssueEntryExists())
                {
                    Response.Write("<script>alert('Already has the book');</script>");
                }
                else
                {
                    issueBook();
                }
            }
            else
            {
                Response.Write("<script>alert('Wrong book ID or User ID');</script>");
            }
        }
        private bool checkIfIssueEntryExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from book_issue_tbl WHERE member_id = '" + TextBox1.Text.Trim() + "' AND book_id = '" + TextBox2.Text.Trim() + "'  ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error in checking user');</script>");
            }
            return false;
        }
        private void issueBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl (member_id, member_name, book_id, book_name, issue_date, due_date) values (@member_id, @member_name, @book_id, @book_name, @issue_date, @due_date) ", con);

                cmd.Parameters.AddWithValue("@member_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());

                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("UPDATE book_master_tbl set current_stock = current_stock-1 where book_id ='"+TextBox2.Text.Trim()+"'", con);
                cmd.ExecuteNonQuery();


                con.Close();
                Response.Write("<script>alert('Book Issued ');</script>");
                GridView1.DataBind();
                clearForm();

            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error!!');</script>");
            }
        }




        private void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
        }

       
        private bool checkIfUserExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("SELECT full_name from member_master_tbl where member_id = '" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error in checking user');</script>");
            }
            return false;
        }
        private bool checkIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl where book_id = '" + TextBox2.Text.Trim() + "' AND current_stock > 0 ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error in checking book');</script>");
            }
            return false;
        }


        //return btn
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists() && checkIfUserExists())
            {
                if (checkIfIssueEntryExists())
                {
                    returnBook();
                }
                else
                {
                    Response.Write("<script>alert('Record not found!');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Wrong book ID or User ID');</script>");
            }
        }
        private void returnBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("DELETE from book_issue_tbl WHERE book_id = '"+TextBox2.Text.Trim()+"' AND member_id = '"+TextBox1.Text.Trim()+"'", con);

                int result = cmd.ExecuteNonQuery();

                if(result > 0)
                {
                    
                    cmd = new SqlCommand("UPDATE book_master_tbl set current_stock = current_stock + 1 WHERE book_id = '"+TextBox2.Text.Trim()+"'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();

                    Response.Write("<script>alert('Book returned !');</script>");
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error in returning book');</script>");
            }
        }



        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}