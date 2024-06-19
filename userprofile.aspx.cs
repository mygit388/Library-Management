using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class userprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(Session["username"].ToString()==""||Session["username"]==null)
                {
                    Response.Write("<script>alert('Session Expired.Login again');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        getUser();
                        getUserBookData();
                    }

                }
            }
            catch (Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["username"].ToString() == "" || Session["username"] == null)
            {
                Response.Write("<script>alert('Session Expired.Login again');</script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                updateUser();
            }
        }
        void getUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tb where memb_ID='" + Session["username"].ToString() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                    TextBox1.Text = dt.Rows[0]["full_name"].ToString().Trim();
                    TextBox2.Text = dt.Rows[0]["dob"].ToString().Trim();
                    TextBox3.Text = dt.Rows[0]["contact_no"].ToString().Trim();
                    TextBox4.Text = dt.Rows[0]["email"].ToString().Trim();
                    DropDownList1.SelectedValue= dt.Rows[0]["state"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["city"].ToString().Trim();
                    TextBox7.Text = dt.Rows[0]["pin"].ToString().Trim();
                    TextBox10.Text = dt.Rows[0]["full_address"].ToString().Trim();
                    TextBox5.Text = dt.Rows[0]["memb_ID"].ToString().Trim();
                    TextBox8.Text = dt.Rows[0]["password"].ToString().Trim();
                    Label1.Text = dt.Rows[0]["acct_status"].ToString().Trim();
                    if(dt.Rows[0]["acct_status"].ToString().Trim()=="active")
                    {
                        Label1.Attributes.Add("class", "badge badge.pill badge-success");
                    }
                    else if (dt.Rows[0]["acct_status"].ToString().Trim() == "pending")
                    {
                        Label1.Attributes.Add("class", "badge badge.pill badge-warning");
                    }
                    else if (dt.Rows[0]["acct_status"].ToString().Trim() == "deactive")
                    {
                        Label1.Attributes.Add("class", "badge badge.pill badge-danger");
                        
                    }
                    else
                    {
                        Label1.Attributes.Add("class", "badge badge.pill badge-info");
                    }
                              
            }
            catch (Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script>");
            }

        }
        void getUserBookData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from book_issue_tb where memb_ID='" + Session["username"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
        void updateUser()
        {
            try
            {
                string pwd = "";
                if (TextBox9.Text =="")
                {
                    pwd = TextBox8.Text.Trim();                }
                else
                {
                    pwd = TextBox9.Text.Trim();

                }
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE member_master_tb SET full_name=@full_name,dob=@dob,contact_no=@contact_no,email=@email,state=@state,city=@city,pincode=@pincode,full_address=@full_address," +
                    "password=@password,acct_status=@acct_status WHERE memb_ID='" + TextBox5.Text.Trim() + "'", con); cmd.Parameters.AddWithValue("@book_ID", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.Text.Trim());
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@password",pwd.ToString());
                cmd.Parameters.AddWithValue("@acct_status","pending");
                
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                



            }
            catch (Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script>");
            }
        }
    }
}