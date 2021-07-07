using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace OOM_Project_1
{
    public partial class book_store : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillAuthorPublisherValues();
            }
            GridView1.DataBind();
        }


        
        private void fillAuthorPublisherValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand("SELECT author_name from author_master_tbl",con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "author_name";
                DropDownList3.DataBind();

                cmd = new SqlCommand("SELECT publisher_name from publisher_master_tbl", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();


            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error in Button1 Click event');</script>");
            }
        }



        //go btn event
        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                getBookByID();
            }
            else
            {
                Response.Write("<script>alert('ID does not exists!');</script>");
            }
        }

        private void getBookByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl where book_id = '" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["book_name"].ToString();
                    TextBox10.Text = dt.Rows[0]["publish_date"].ToString();
                    TextBox3.Text = dt.Rows[0]["edition"].ToString();
                    TextBox4.Text = dt.Rows[0]["book_cost"].ToString();
                    TextBox5.Text = dt.Rows[0]["no_of_pages"].ToString();
                    TextBox6.Text = dt.Rows[0]["actual_stock"].ToString();
                    TextBox7.Text = dt.Rows[0]["current_stock"].ToString();
                    TextBox8.Text = "" + (Convert.ToInt32(TextBox6.Text.ToString()) - Convert.ToInt32(TextBox7.Text.ToString()));



                    DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();

                    ListBox1.ClearSelection();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');

                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genre[i])
                            {
                                ListBox1.Items[j].Selected = true;
                            }
                        }
                    }

                    global_actual_stock = Convert.ToInt32(TextBox6.Text.ToString().Trim());
                    global_current_stock = Convert.ToInt32(TextBox7.Text.ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid book ID');</script>");
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error in finding book by ID');</script>");
            }
        }





        private bool checkIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl where book_id = '" + TextBox1.Text.Trim() + "' OR book_name = '"+TextBox2.Text.Trim()+"' ", con);
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



        //add btn
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                Response.Write("<script>alert('Book ID already exists TRy with another ID');</script>");
            }
            else
            {
                addNewBook();
            }
        }

        private void addNewBook()
        {
            try
            {
                string genres = "";
                foreach(int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                genres = genres.Remove(genres.Length - 1);

                string filepath = "~/book_inventory/book1.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));

                if(filename != null)
                {
                    filepath = "~/book_inventory/" + filename;
                }

                //filepath = "~/book_inventory/" + filename;

                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl (book_id, book_name, genre, author_name, publisher_name, publish_date, language, edition, book_cost, no_of_pages, actual_stock, current_stock, book_img_link) values(@book_id, @book_name, @genre, @author_name, @publisher_name, @publish_date, @language, @edition, @book_cost, @no_of_pages, @actual_stock, @current_stock, @book_img_link)", con);

                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);

                cmd.Parameters.AddWithValue("@publish_date", TextBox10.Text.Trim());

                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox5.Text.Trim());
                //cmd.Parameters.AddWithValue("@book_description", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book added successfully!');</script>");
                GridView1.DataBind();
                clearForm();



            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error in adding book!');</script>");
            }
        }




        //update btn
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                updateBookByID2();
            }
            else
            {
                Response.Write("<script>alert('ID does not exists!');</script>");
            }
        }

        private void updateBookByID()
        {
            try
            {

                int actual_stock = Convert.ToInt32(TextBox6.Text.Trim());
                int current_stock = Convert.ToInt32(TextBox7.Text.Trim());

                if(global_actual_stock == actual_stock)
                {

                }
                else
                {
                    if(actual_stock < global_issued_books)
                    {
                        Response.Write("<script>alert('Actual stock value cannot be less than the Issued books');</script>");
                        return;
                    }
                    else
                    {
                        current_stock = actual_stock - global_issued_books;
                        TextBox7.Text = "" + current_stock;
                    }
                }

                string genres = "";
                foreach(int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                genres = genres.Remove(genres.Length - 1);

                string filepath = "~/book_inventory/book1";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                if(filename == null)
                {
                    filepath = global_filepath;
                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                    filepath = "~/book_inventory/" + filename;
                }

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl set book_name = @book_name, genre = @genre, author_name = @author_name, publisher_name = @publisher_name, publish_date = @publish_date, language = @language, edition = @edition, book_cost = @book_cost, no_of_pages = @no_of_pages, actual_stock = @actual_stock, current_stock = @current_stock, book_img_link = @book_img_link where book_id = '" + TextBox1.Text.Trim()+"'", con);

                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
               
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);

                cmd.Parameters.AddWithValue("@publish_date", TextBox10.Text.Trim());

                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());



                cmd.Parameters.AddWithValue("@book_img_link", filepath);



                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('Book Status Updated!');</script>");

            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error in update fun event');</script>");
            }
        }



        void updateBookByID2()
        {
            if (checkIfBookExists())
            {
                try
                {

                    int actual_stock = Convert.ToInt32(TextBox6.Text.Trim());
                    int current_stock = Convert.ToInt32(TextBox7.Text.Trim());

                    if (global_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if (actual_stock < global_issued_books)
                        {
                            Response.Write("<script>alert('Actual Stock value cannot be less than the Issued books');</script>");
                            return;


                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_books;
                            TextBox7.Text = "" + current_stock;
                        }
                    }

                    string genres = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genres = genres + ListBox1.Items[i] + ",";
                    }
                    genres = genres.Remove(genres.Length - 1);

                    string filepath = "~/book_inventory/book1";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;

                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                        filepath = "~/book_inventory/" + filename;
                    }


                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    SqlCommand cmd = new SqlCommand("update book_master_tbl set book_name = @book_name,genre = @genre,author_name = @author_name, publisher_name = @publisher_name,publish_date = @publish_date, language = @language,edition = @edition,book_cost = @book_cost,no_of_pages = @no_of_pages,actual_stock = @actual_stock, current_stock = @current_stock,book_img_link = @book_img_link where book_id = '" + TextBox1.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genres); cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value); 
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);

                    cmd.Parameters.AddWithValue("@publish_date", TextBox10.Text.Trim());

                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value); 
                    cmd.Parameters.AddWithValue("@edition", TextBox3.Text.Trim());

                    cmd.Parameters.AddWithValue("@book_cost", TextBox4.Text.Trim()); 
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBox5.Text.Trim()); 
                   
                    cmd.Parameters.AddWithValue("@actual_stock", TextBox6.Text.Trim()); cmd.Parameters.AddWithValue("@current_stock", TextBox7.Text.Trim()); cmd.Parameters.AddWithValue("@book_img_link", filepath);

                    cmd.ExecuteNonQuery();
                    GridView1.DataBind();
                    con.Close();
                    Response.Write("<script>alert('Book updated successfullly');</script>");
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('Error');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Cannot update!');</script>");
            }
        }







        //delete btn
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                deleteBook();
            }
            else
            {
                Response.Write("<script>alert('Does ! exists & there4 cannot be deleted!');</script>");
            }
        }

        private void deleteBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand("DELETE from book_master_tbl WHERE book_id = '"+TextBox1.Text.Trim()+"'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book removed successfully');</script>");
                clearForm();
                GridView1.DataBind();
                

            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error in deleting the book');</script>");
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
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox10.Text = "";
            ListBox1.ClearSelection();

        }
    }
}