using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OOM_Project_1
{
    public partial class master_page_web_form_ : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    
                    LinkButton4.Visible = true;     //view books
                    LinkButton1.Visible = true;     //user login
                    LinkButton2.Visible = true;     //sign up

                    LinkButton3.Visible = false;    //logout
                    LinkButton7.Visible = false;    //hello

                    LinkButton5.Visible = true;     //admin login
                    LinkButton6.Visible = false;   //author man 
                    LinkButton8.Visible = false;   //publisher man
                    LinkButton9.Visible = false;    //book inventory
                    LinkButton10.Visible = false;   //book issuing
                    LinkButton11.Visible = false;   //member mana
                }
                else if(Session["role"].Equals("user"))
                {
                    LinkButton4.Visible = true;     //view books
                    LinkButton1.Visible = false;     //user login
                    LinkButton2.Visible = false;     //sign up

                    LinkButton3.Visible = true;    //logout
                    LinkButton7.Visible = true;    //hello
                    LinkButton7.Text = "Hello " + Session["username"].ToString();

                    LinkButton5.Visible = true;     //admin login
                    LinkButton6.Visible = false;   //author man 
                    LinkButton8.Visible = false;   //publisher man
                    LinkButton9.Visible = false;    //book inventory
                    LinkButton10.Visible = false;   //book issuing
                    LinkButton11.Visible = false;   //member mana
                }

                else if (Session["role"].Equals("admin"))
                {
                    LinkButton4.Visible = true;     //view books
                    LinkButton1.Visible = false;     //user login
                    LinkButton2.Visible = false;     //sign up

                    LinkButton3.Visible = true;    //logout
                    LinkButton7.Visible = true;    //hello
                    LinkButton7.Text = "Hello Admin";

                    LinkButton5.Visible = false;     //admin login
                    LinkButton6.Visible = true;   //author man 
                    LinkButton8.Visible = true;   //publisher man
                    LinkButton9.Visible = true;    //book inventory
                    LinkButton10.Visible = true;   //book issuing
                    LinkButton11.Visible = true;   //member mana
                }
            }
            catch (Exception)
            {

            }
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_login.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("author_management.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("publisher_management.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("book_store.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("book_issuing.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("member_management.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("view_books.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("user_login.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("user_signup.aspx");
        }


        //logout btn event
        protected void LinkButton3_Click(object sender, EventArgs e)
        {

            Session["username"] = "";
            Session["full_name"] = "";
            Session["role"] = "";
            Session["status"] = "";

            LinkButton4.Visible = true;     //view books
            LinkButton1.Visible = true;     //user login
            LinkButton2.Visible = true;     //sign up

            LinkButton3.Visible = false;    //logout
            LinkButton7.Visible = false;    //hello

            LinkButton5.Visible = true;     //admin login
            LinkButton6.Visible = false;   //author man 
            LinkButton8.Visible = false;   //publisher man
            LinkButton9.Visible = false;    //book inventory
            LinkButton10.Visible = false;   //book issuing
            LinkButton11.Visible = false;   //member mana

            Response.Write("<script>alert('Logout SS');</script>");
            Response.Redirect("homepage.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("user_profile.aspx");
        }
    }
}