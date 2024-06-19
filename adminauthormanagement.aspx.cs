using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class adminauthormanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
          if(ifAuthorexists())
            {
                Response.Write("<script>alert('Author existing');</script>");
            }
           else
            {
                addNewAuthor();
            }
           
            
        }
        bool ifAuthorexists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("exec dbo.Pro_authorView '" + TextBox1.Text.Trim() + "'", con);           
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
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }

            
        }
        void addNewAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("exec dbo.Pro_authorInsert '"+ TextBox1.Text.Trim()+"','"+ TextBox2.Text.Trim()+"' ", con);
              /*  cmd.Parameters.AddWithValue("@id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@name", TextBox2.Text.Trim());*/
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author added');</script>");
                GridView1.DataBind();
                clearform();          }
            catch(Exception Ex)
            {
                Response.Write("<script>alert('"+Ex.Message+"');</script>");
            }
        }
        void updateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("exec dbo.Pro_authorUpdate'" + TextBox1.Text.Trim() + "','"+ TextBox2.Text.Trim()+"'", con);
                //cmd.Parameters.AddWithValue("@name", TextBox2.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author Updated');</script>");
                GridView1.DataBind();
                clearform();
            }
            catch(Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script>");
            }
        }
        void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("dbo.Pro_authorDelete'" + TextBox1.Text.Trim()+"'",con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Deleted');</script>");
                GridView1.DataBind();
                clearform();
            }
            catch(Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script>");
            }
        }
        void getAuthorById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("exec dbo.Pro_authorView'" + TextBox1.Text.Trim() + "'", con); 
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text=dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Author ID');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                
            }
        }
        void clearform()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            if (ifAuthorexists())
            {
                updateAuthor();
            }
            else
            {
                Response.Write("<script>alert('Author does not exist');</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (ifAuthorexists())
            {
                deleteAuthor();
            }
            else
            {
                Response.Write("<script>alert('Author does not exist');</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            getAuthorById();
        }
    }
}