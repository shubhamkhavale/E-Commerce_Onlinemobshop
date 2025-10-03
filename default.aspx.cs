using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace VariableMobileShop
{
    public partial class _Default : Page
    {
        string im;
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VariableMobileShop\VariableMobileShop\App_Data\VMDB.mdf;Integrated Security=True");

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Add_product ORDER BY Id DESC", con);
                SqlDataReader dr = cmd.ExecuteReader();

                dlProducts.DataSource = dr;
                dlProducts.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error loading products: {ex.Message}')</script>");
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            im = e.CommandArgument.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal').modal('show');", true);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Add_product WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", im);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    ViewState["card"] = dr[0].ToString();
                    cat.Text = dr[1].ToString();
                    name.Text = dr[2].ToString();
                    clr.Text = dr[4].ToString();
                    ram.Text = dr[5].ToString();
                    rom.Text = dr[6].ToString();
                    price.Text = dr[8].ToString();
                    descripson.Text = dr[9].ToString();
                    Image1.ImageUrl = dr.GetValue(10).ToString();
                    Image2.ImageUrl = dr.GetValue(11).ToString();
                    Image3.ImageUrl = dr.GetValue(12).ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error loading product details: {ex.Message}')</script>");
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        protected void ck_Command(object sender, CommandEventArgs e)
        {
            string card = e.CommandArgument.ToString();
            if (Session["user"] != null)
            {
                string ss = Session["user"].ToString();
                AddToCart(card, ss);
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button1_Command(object sender, CommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (Session["user"] != null)
            {
                Response.Redirect("checkout.aspx?pd=" + id);
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void ck1_Click(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                string ss = Session["user"].ToString();
                AddToCart(ViewState["card"].ToString(), ss);
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        private void AddToCart(string productId, string username)
        {
            try
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM Add_product WHERE Id = @Id", con);
                cmd1.Parameters.AddWithValue("@Id", productId);

                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                    string id = dr1[0].ToString();
                    string cat = dr1[1].ToString();
                    string name = dr1[2].ToString();
                    string clr = dr1[4].ToString();
                    string ram = dr1[5].ToString();
                    string rom = dr1[6].ToString();
                    string price = dr1[8].ToString();
                    string img1 = dr1.GetValue(10).ToString();

                    con.Close();
                    con.Open();

                    SqlCommand cmd2 = new SqlCommand(
                        "INSERT INTO Cart (Id, Username, Category, Name, Ram, Rom, Color, Price, Image) " +
                        "VALUES (@Id, @Username, @Category, @Name, @Ram, @Rom, @Color, @Price, @Image)", con);

                    cmd2.Parameters.AddWithValue("@Id", id);
                    cmd2.Parameters.AddWithValue("@Username", username);
                    cmd2.Parameters.AddWithValue("@Category", cat);
                    cmd2.Parameters.AddWithValue("@Name", name);
                    cmd2.Parameters.AddWithValue("@Ram", ram);
                    cmd2.Parameters.AddWithValue("@Rom", rom);
                    cmd2.Parameters.AddWithValue("@Color", clr);
                    cmd2.Parameters.AddWithValue("@Price", price);
                    cmd2.Parameters.AddWithValue("@Image", img1);

                    cmd2.ExecuteNonQuery();
                    Response.Write("<script>alert('Product added to cart successfully.')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error adding to cart: {ex.Message}')</script>");
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}