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
    public partial class adminbookissuing_page : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind(); }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                issueBook();
                  
            }
            catch(Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (ifissued())
                {
                    returnBook();
                }
                else
                {
                    Response.Write("<script>alert('Book is not issued for this member');</script>");
                }
            }
            catch(Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script>");
            }
        }
        //go button
        protected void Button4_Click(object sender, EventArgs e)
        {
            
                getMembBook();
            
        }
       
        void getMembBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tb where book_ID='" + TextBox2.Text.Trim() + "'AND curr_stock>0", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox5.Text = dt.Rows[0]["book_name"].ToString();
                    
                }
                else
                {
                    Response.Write("<script>alert('wrong book id/out of stock');</script>");
                }
                cmd = new SqlCommand("SELECT * FROM member_master_tb where memb_ID='" + TextBox1.Text.Trim() + "'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0]["full_name"].ToString();
                   
                }
                else
                {
                    Response.Write("<script>alert('wrong member id');</script>");
                }
            }
            catch(Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script>");
            }

        }
        void issueBook()
        {
            try
            {
                if (!ifissued())
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                   
                        SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tb(memb_ID,memb_name,book_ID," +
                            "book_name,issue_date,due_date)values(@memb_ID,@memb_name,@book_ID," +
                            "@book_name,@issue_date,@due_date)", con);
                        cmd.Parameters.AddWithValue("@memb_ID", TextBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@memb_name", TextBox4.Text.Trim());
                        cmd.Parameters.AddWithValue("@book_ID", TextBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@book_name", TextBox5.Text.Trim());
                        cmd.Parameters.AddWithValue("@issue_date", TextBox6.Text.Trim());
                        cmd.Parameters.AddWithValue("@due_date", TextBox7.Text.Trim());
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("UPDATE book_master_tb SET curr_stock=curr_stock-1 WHERE book_ID='" + TextBox2.Text.Trim() + "'", con);
                        cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Book Issued Successfully');</script>");
                        con.Close();
                        GridView1.DataBind();
                        clearForm();
                 
                }
                else
                {
                    Response.Write("<script>alert('already issued  book for this member');</script>");
                }
                 
            }
            catch(Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script>");
            }
        }
        void returnBook()
        {
            try
            {
                if (ifissued())
                {
                    SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                    SqlCommand cmd = new SqlCommand("DELETE FROM book_issue_tb WHERE book_ID='" + TextBox2.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    //curr1 = curr1 + 1;
                    cmd = new SqlCommand("UPDATE book_master_tb SET curr_stock=curr_stock+1 WHERE book_ID='" + TextBox2.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    clearForm();
                }
                else
                {
                    Response.Write("<script>alert('This book is not issued to this member');</script>");
                }

            }
            catch (Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script>");
            }
        }
           bool ifissued()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_issue_tb where memb_id='" + TextBox1.Text.Trim() + "'", con);
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
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7 .Text = "";
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
            catch(Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script>");
            }
        }
    }

       
    }