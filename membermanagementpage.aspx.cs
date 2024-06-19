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
    public partial class membermanagementpage : System.Web.UI.Page
        {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           GridView2.DataBind();

        }
        //active button
        protected void Button1_Click(object sender, EventArgs e)
        {
            updateStatus("active");
        }
        //pending button
        protected void Button2_Click(object sender, EventArgs e)
        {
            updateStatus("pending");
        }
        //deactivate button
        protected void Button3_Click(object sender, EventArgs e)
        {
            updateStatus("deactivate");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (ifuserExists())
                {
                    deleteUser();
                }
                else
                {
                    Response.Write("<script>alert('User does not exist');</script");
                }
            }
            catch(Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script>");
            }
        }
        bool  ifuserExists()      
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tb WHERE memb_ID='" + TextBox1.Text.Trim() + "'", con);
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
            catch(Exception Ex)
            {
                Response.Write("<script>alert('"+Ex.Message+"');</script>");
                return false;
            }

        }
        void deleteUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM member_master_tb WHERE memb_ID='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                GridView2.DataBind();
                
            }

            catch(Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script>");
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tb WHERE memb_ID='" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["full_name"].ToString().Trim();
                    TextBox3.Text = dt.Rows[0]["acct_status"].ToString().Trim();
                    TextBox4.Text = dt.Rows[0]["dob"].ToString().Trim();
                    TextBox5.Text = dt.Rows[0]["contact_no"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["email"].ToString().Trim();
                    TextBox7.Text = dt.Rows[0]["state"].ToString().Trim();
                    TextBox8.Text = dt.Rows[0]["city"].ToString().Trim();
                    TextBox9.Text = dt.Rows[0]["pincode"].ToString().Trim();
                    TextBox10.Text = dt.Rows[0]["full_address"].ToString().Trim();
                   
                }
                else
                {
                    Response.Write("<script>alert('User does not exist');</script>");
                }
            }
            catch (Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script>");
            }
        }
        void updateStatus(string sts)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE member_master_tb SET acct_status='" + sts + "' WHERE memb_ID='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                GridView2.DataBind();
                TextBox3.Text =sts;
            }
            catch (Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script>");
            }
        }
    }
}