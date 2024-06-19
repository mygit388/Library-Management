using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Site3 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"]==null)
                {
                    LinkButton1.Visible = true;//login
                    LinkButton2.Visible = true;//sign up
                    LinkButton3.Visible = false;//logout
                    LinkButton7.Visible = false;//hello
                    LinkButton6.Visible = true;//admin login
                    LinkButton8.Visible = false;//book inventory
                    LinkButton9.Visible = false;//book issue
                    LinkButton10.Visible = false;//member management
                    LinkButton11.Visible = false;//author management
                    LinkButton12.Visible = false;//publisher management

                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false;//login
                    LinkButton2.Visible = false;//sign up
                    LinkButton3.Visible = true;//logout
                    LinkButton7.Visible = true;//hello
                    LinkButton7.Text = "Hello " + Session["username"].ToString();
                    LinkButton6.Visible = true;//admin login
                    LinkButton8.Visible = false;//book inventory
                    LinkButton9.Visible = false;//book issue
                    LinkButton10.Visible = false;//member management
                    LinkButton11.Visible = false;//author management
                    LinkButton12.Visible = false;//publisher management
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false;//login
                    LinkButton2.Visible = false;//sign up
                    LinkButton3.Visible = true;//logout
                    LinkButton7.Visible = true;//hello
                    LinkButton7.Text = "Hello admin ";
                    LinkButton6.Visible = false;//admin login
                    LinkButton8.Visible = true;//book inventory
                    LinkButton9.Visible = true;//book issue
                    LinkButton10.Visible = true;//member management
                    LinkButton11.Visible = true;//author management
                    LinkButton12.Visible = true;//publisher management
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void LinkButton6_Click1(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click1(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void LinkButton12_Click1(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void LinkButton8_Click1(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventory.aspx");
        }

        protected void LinkButton9_Click1(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuingpage.aspx");
        }

        protected void LinkButton10_Click1(object sender, EventArgs e)
        {
            Response.Redirect("membermanagementpage.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {

            Session["username"] ="";
            Session["fullname"] ="";
            Session["role"] ="";
            Session["status"] ="";
            LinkButton1.Visible = true;//login
            LinkButton2.Visible = true;//sign up
            LinkButton3.Visible = false;//logout
            LinkButton7.Visible = false;//hello
            LinkButton6.Visible = true;//admin login
            LinkButton8.Visible = false;//book inventory
            LinkButton9.Visible = false;//book issue
            LinkButton10.Visible = false;//member management
            LinkButton11.Visible = false;//author management
            LinkButton12.Visible = false;//publisher management
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("view_books.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }
    }
}