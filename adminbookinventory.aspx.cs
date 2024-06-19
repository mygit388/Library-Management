using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace WebApplication2
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string genrestr;
        static string filepath;
        static string filename;
        static int actual_stock;
        static int curr_stock;
        static int issued_books;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                AuthorPublisherFill();
            }
            
            GridView2.DataBind();
        }
        //add books
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ifbookexists())
                {
                    Response.Write("<script>alert('book already existing');</script>");
                }
                else
                {
                    TextBox8.Text =TextBox7.Text.Trim();
                    addNewBook();
                }
            }
            catch(Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script>");
            }
        }
        //update
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ifbookexists())
                {
                    updateBook();
                }
                else
                {
                    Response.Write("<script>alert('Invalid book id');</script>");
                }
            }
            catch(Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');<.script>");
            }
        }
        //Delete
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (ifbookexists())
                {
                    deleteBook();
                }
                else
                {
                    Response.Write("<script>alert('No such book');</script>");
                }
            }
            catch (Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');<.script>");
            }
        }
        void AuthorPublisherFill()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
                SqlCommand cmd = new SqlCommand("SELECT *from publisher_master_tb", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "publisher_name";
                DropDownList3.DataBind();
                cmd = new SqlCommand("SELECT *from author_master_tb", con);
                dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                DropDownList4.DataSource = dt;
                DropDownList4.DataValueField = "author_name";
                DropDownList4.DataBind();
            
        }
        bool ifbookexists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT *from book_master_tb WHERE book_ID='" + TextBox1.Text.Trim() + "'", con);
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
            }
            return false; 
        }
        void addNewBook()
        {
            try
            {
                genrestr = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genrestr = genrestr + ListBox1.Items[i]+",";
                }
                genrestr = genrestr.Remove(genrestr.Length - 1);
                filepath = "~book_inventory/books1.png";
                filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                filepath = "~/book_inventory/" + filename;
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tb(book_ID,book_name,genre," +
                    "author_name,publisher_name,publish_date,language,edition,book_cost,no_page,book_desc," +
                    "actual_stock,curr_stock,bool_img_link)VALUES(@book_ID,@book_name,@genre," +
                    "@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@no_page,@book_desc," +
                    "@actual_stock,@curr_stock,@bool_img_link)", con);
                cmd.Parameters.AddWithValue("@book_ID", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre",genrestr);
                cmd.Parameters.AddWithValue("@author_name", DropDownList4.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@no_page", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@book_desc", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@curr_stock", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@bool_img_link", filepath);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('added successfully');</script");
                con.Close();
                GridView2.DataBind();
                clearForm();
                
            }
            catch(Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script>");
            }
        }
        void updateBook()
        {
            try
            {
                int textActual_Stock = Convert.ToInt32(TextBox7.Text.Trim());
                int textCurr_stock = Convert.ToInt32(TextBox9.Text.Trim());
                if (textActual_Stock==actual_stock)
                {
                 
                }
                else if (textActual_Stock < issued_books)
                {
                    Response.Write("<script>alert('actual stock can not be less than issued book');");

                }
                else
                {
                    textCurr_stock = textActual_Stock - issued_books;
                    TextBox8.Text = ""+ textCurr_stock;
                }
                     genrestr = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genrestr = genrestr + ListBox1.Items[i] + ",";
                    }
                    genrestr = genrestr.Remove(genrestr.Length - 1);
                    filepath = "~book_inventory/books1.png";
                    filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                    filepath = "~/book_inventory/" + filename;
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE book_master_tb SET book_ID=@book_ID,book_name=@book_name,genre=@genre," +
                        "author_name=@author_name,publisher_name=@publisher_name,publish_date=@publish_date,language=@language,edition=@edition,book_cost=@book_cost,no_page=@no_page,book_desc=@book_desc," +
                        "actual_stock=@actual_stock,curr_stock=@curr_stock,bool_img_link=@bool_img_link WHERE book_ID='" + TextBox1.Text.Trim() + "'", con); cmd.Parameters.AddWithValue("@book_ID", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genrestr);
                    cmd.Parameters.AddWithValue("@author_name", DropDownList4.Text.Trim());
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList3.Text.Trim());
                    cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", DropDownList1.Text.Trim());
                    cmd.Parameters.AddWithValue("@edition", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_page", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_desc", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@curr_stock", TextBox8.Text.Trim());
                    cmd.Parameters.AddWithValue("@bool_img_link", filepath);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView2.DataBind();
                    clearForm();
                
                
                
            }
            catch (Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script>");
            }
        }
        void deleteBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM book_master_tb where book_ID='" + TextBox1.Text.Trim() + "'", con); cmd.Parameters.AddWithValue("@book_ID", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", ListBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", DropDownList4.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList3.Text.Trim());
                cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.Text.Trim());
                cmd.Parameters.AddWithValue("@edition", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@no_page", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@book_desc", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@curr_stock", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@bool_img_link", TextBox9.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                GridView2.DataBind();
                clearForm();
            }
            catch (Exception Ex)
            {
                Response.Write("<script>alert('" + Ex.Message + "');</script>");
            }
        }
        void getBookById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tb WHERE book_ID='" + TextBox1.Text.Trim()+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["book_name"].ToString();
                   
                    DropDownList4.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();

                    DropDownList3.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    TextBox3.Text = dt.Rows[0]["publish_date"].ToString();
                    DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString().Trim(); 
                    TextBox4.Text = dt.Rows[0]["edition"].ToString();
                    TextBox5.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["no_page"].ToString().Trim();

                    TextBox10.Text = dt.Rows[0]["book_desc"].ToString();
                    TextBox7.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox8.Text = dt.Rows[0]["curr_stock"].ToString().Trim();
                    ListBox1.ClearSelection();
                    string[] genre= dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    for (int i = 0; i < genre.Length;i++)
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString()==genre[i])
                            {
                                ListBox1.Items[j].Selected = true;
                            }
                        }
                                 
                      
                    }
                    TextBox9.Text =""+(Convert.ToInt32(dt.Rows[0]["actual_Stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["curr_stock"].ToString()));
                    filepath =dt.Rows[0]["bool_img_link"].ToString();
                    curr_stock = Convert.ToInt32( dt.Rows[0]["curr_stock"].ToString().Trim());
                    actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    issued_books = Convert.ToInt32(dt.Rows[0]["issued_books"].ToString().Trim());

                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
        void clearForm()
        {
            TextBox2.Text = "";
            ListBox1.Text = "";
            DropDownList4.Text = "";

            DropDownList3.Text = "";
            TextBox3.Text = "";
            DropDownList1.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox10.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {

                if (ifbookexists())
                {
                    getBookById();
                }
                else
                {
                    Response.Write("<script>alert('Does not exist');</script>");
                }
            }
            catch(Exception Ex)
            {
                Response.Write("<script>alert('"+Ex.Message+"');</script>");
            }
             
        }

       
    }

    

}