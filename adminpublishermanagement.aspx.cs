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
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        bool ifPublisherExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT *from publisher_master_tb where publisher_ID='"+TextBox1.Text.Trim()+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count>=1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
               
            }
            catch(Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script>");
                return false;
            }
        }
        void addNewPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tb(publisher_ID,publisher_name) values(@id,@name)", con);
                cmd.Parameters.AddWithValue("@id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@name", TextBox2.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<Script>alert('Added Successfully');</script>");
                GridView1.DataBind();
                clearForm();
            }
            catch (Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script>");
            }
        }
        void updatePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tb SET author_name=@name WHERE publisher_ID='" + TextBox1.Text.Trim() + "'", con);
                cmd.Parameters.AddWithValue("@name", TextBox2.Text.Trim());
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Updated Successfully');</script>");
                GridView1.DataBind();
                clearForm();
                con.Close();
            }
            catch(Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script)");
            }
        }
        void deletePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE from publisher_master_tb WHERE publisher_ID='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Deleted ');</script>");
                GridView1.DataBind();
                clearForm();
                con.Close();
            }
            catch (Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script)");
            }
        }
        void getPublisherById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from publisher_master_tb where publisher_ID='" + TextBox1.Text.Trim() + "'", con); SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Publisher ID');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ifPublisherExists())
                {
                    Response.Write("<script>alert('Publisher already existing');</script>");
                }
                else
                {
                    addNewPublisher();
                }
            }
            catch(Exception Ex)
            {
                Response.Write("<script>alert('"+Ex.Message+"');</script>");
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ifPublisherExists())
                {
                    updatePublisher();
            }
                else
                {
                    Response.Write("<script>alert('Publisher does not exist');</script>");
                }
            }
            catch(Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script>");

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if(ifPublisherExists())
            {
                deletePublisher();
            }
            else
            {
                Response.Write("<script>alert('No such Publisher');</script>");
            }
        }
    }
}